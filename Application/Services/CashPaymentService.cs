using Domain.Entities;
using Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IServices;

namespace Application.Services
{
    public class CashPaymentService : ICashPaymentService
    {
        private readonly IAccountMembershipService _membershipService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CashPaymentService> _logger;

        public CashPaymentService(
            IAccountMembershipService membershipService,
            IUnitOfWork unitOfWork,
            ILogger<CashPaymentService> logger)
        {
            _membershipService = membershipService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<AccountMembership> CreateCashPaymentAsync(int accountId, int membershipPlanId)
        {
            _logger.LogInformation("CashPayment: Checking membership for account #{AccountId}, plan #{PlanId}",
                                   accountId, membershipPlanId);

            // 1) Kiểm tra gói Active
            var currentActive = await _membershipService.GetActiveMembershipAsync(accountId);

            AccountMembership newMembership;

            // 2) Nếu chưa có => Tạo mới
            if (currentActive == null)
            {
                _logger.LogInformation("No active membership => create new membership for Account #{AccountId}", accountId);
                newMembership = await _membershipService.CreateNewMembershipAsync(accountId, membershipPlanId);
            }
            else
            {
                // 3) Nếu đã có => Nâng cấp
                _logger.LogInformation("Active membership #{MembershipId} found => upgrade to plan #{PlanId}.",
                    currentActive.Id, membershipPlanId);
                newMembership = await _membershipService.UpgradeMembershipAsync(accountId, membershipPlanId);
            }

            // 4) Set Paid, Active ngay
            var plan = await _unitOfWork.MembershipPlanRepo.GetByIdAsync(newMembership.MembershipPlanId ?? 0);
            if (plan == null)
                throw new Exception("Membership plan not found.");

            newMembership.PaymentStatus = "Paid";
            newMembership.Status = "Active";
            newMembership.StartDate = DateOnly.FromDateTime(DateTime.Now);
            newMembership.EndDate = newMembership.StartDate.Value.AddDays(plan.Duration);

            // 5) Lưu DB
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("CashPayment done. Membership #{NewId} => Active, PaymentStatus=Paid.", newMembership.Id);

            return newMembership;
        }
    }
}