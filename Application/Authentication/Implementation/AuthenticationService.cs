using Application.Authentication.Interfaces;
using Application.ViewModels.Authentication;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DatabaseSettings _dbSettings;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IMapper _mapper;

        public AuthenticationService(
            IUnitOfWork unitOfWork,
            IJwtTokenService jwtTokenService,
            ILogger<AuthenticationService> logger,
            IMapper mapper,
            IOptions<DatabaseSettings> dbSettings)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenService = jwtTokenService;
            _logger = logger;
            _mapper = mapper;
            _dbSettings = dbSettings.Value;
        }

        public async Task<LoginResponseDTO> RegisterAsync(AccountRegistrationDTO registrationDto)
        {
            _logger.LogInformation("Using Database Collation: {Collation}", _dbSettings.Collation);

            // Validate inputs
            if (string.IsNullOrWhiteSpace(registrationDto.AccountEmail) ||
                string.IsNullOrWhiteSpace(registrationDto.AccountUserName) ||
                string.IsNullOrWhiteSpace(registrationDto.AccountPassword))
            {
                return new LoginResponseDTO { Success = false, Message = "Invalid registration data." };
            }

            // Check if account already exists (by Email or Username)
            var accountExists = await _unitOfWork.GetRepository<Account>().AnyAsync(u =>
                EF.Functions.Collate(u.AccountEmail, _dbSettings.Collation) == registrationDto.AccountEmail ||
                EF.Functions.Collate(u.AccountUserName, _dbSettings.Collation) == registrationDto.AccountUserName);

            if (accountExists)
            {
                _logger.LogWarning("User already exists with the provided email or username.");
                return new LoginResponseDTO { Success = false, Message = "User already exists." };
            }

            // Validate role
            var allowedRoles = new List<string> { "Member", "Admin", "Manager" };
            if (string.IsNullOrWhiteSpace(registrationDto.AccountRole) ||
                !allowedRoles.Contains(registrationDto.AccountRole, StringComparer.OrdinalIgnoreCase))
            {
                _logger.LogError("Invalid or missing role provided.");
                return new LoginResponseDTO { Success = false, Message = "Invalid or missing role provided." };
            }

            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    var account = new Account
                    {
                        AccountUserName = registrationDto.AccountUserName,
                        AccountFullName = registrationDto.AccountFullName,
                        AccountEmail = registrationDto.AccountEmail,
                        AccountPassword = BCrypt.Net.BCrypt.HashPassword(registrationDto.AccountPassword, workFactor: 12),
                        AccountPhoneNumber = registrationDto.AccountPhoneNumber,
                        AccountRole = registrationDto.AccountRole,
                        AccountStatus = "Active",
                        AccountIsExternal = registrationDto.AccountIsExternal,
                        AccountExternalProvider = registrationDto.AccountIsExternal ? registrationDto.AccountExternalProvider : null
                    };

                    await _unitOfWork.GetRepository<Account>().AddAsync(account);
                    await _unitOfWork.CompleteAsync();

                    // Tạo token
                    var accessToken = _jwtTokenService.GenerateJwtToken(
                        account.AccountId,
                        account.AccountUserName,
                        account.AccountRole ?? "Customer",
                        account.AccountStatus
                    );

                    await _unitOfWork.CompleteAsync();
                    await transaction.CommitAsync();

                    _logger.LogInformation("User registration successful.");
                    return new LoginResponseDTO
                    {
                        Success = true,
                        Message = "Registration successful.",
                        JWTToken = accessToken,
                        Role = account.AccountRole
                    };
                }
                catch (SqlException ex)
                {
                    _logger.LogError(ex, "Database connection error.");
                    await transaction.RollbackAsync();
                    return new LoginResponseDTO { Success = false, Message = "A database connection error occurred. Please try again later." };
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An unexpected error occurred during registration.");
                    await transaction.RollbackAsync();
                    return new LoginResponseDTO { Success = false, Message = "An unexpected error occurred. Please try again." };
                }
            }
        }

        public async Task<LoginResponseDTO> LoginAsync(AccountLoginDTO loginDto)
        {
            _logger.LogInformation("Using Database Collation: {Collation}", _dbSettings.Collation);

            // Validate inputs
            if (string.IsNullOrWhiteSpace(loginDto.EmailOrUsername) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return new LoginResponseDTO { Success = false, Message = "Invalid login data." };
            }

            var emailOrUsername = loginDto.EmailOrUsername.Trim();

            try
            {
                var account = await _unitOfWork.GetRepository<Account>().GetAsync(u =>
                    EF.Functions.Collate(u.AccountEmail, _dbSettings.Collation) == emailOrUsername ||
                    EF.Functions.Collate(u.AccountUserName, _dbSettings.Collation) == emailOrUsername);

                if (account == null || !string.Equals(account.AccountStatus, "Active", StringComparison.OrdinalIgnoreCase))
                {
                    _logger.LogWarning("Invalid credentials or account is banned.");
                    return new LoginResponseDTO { Success = false, Message = "Invalid credentials or account is banned." };
                }

                if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, account.AccountPassword))
                {
                    _logger.LogWarning("Invalid credentials provided.");
                    return new LoginResponseDTO { Success = false, Message = "Invalid credentials." };
                }

                var accessToken = _jwtTokenService.GenerateJwtToken(account.AccountId, account.AccountUserName, account.AccountRole, account.AccountStatus);

                _logger.LogInformation("User login successful for AccountId: {AccountId}", account.AccountId);

                return new LoginResponseDTO
                {
                    Success = true,
                    JWTToken = accessToken,
                    Message = "Login successful.",
                    Role = account.AccountRole
                };
            }
            catch (SqlException sqlEx)
            {
                _logger.LogError(sqlEx, "Database connection error occurred during login.");
                return new LoginResponseDTO { Success = false, Message = "Login failed due to a database connection issue." };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during login.");
                return new LoginResponseDTO { Success = false, Message = "Login failed. Please try again." };
            }
        }
    }
}
