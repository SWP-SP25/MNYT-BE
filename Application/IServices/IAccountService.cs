﻿using Application.Utils.Implementation;
using Application.ViewModels;
using Application.ViewModels.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IAccountService
    {
        Task<AccountDTO?> GetAccountByIdAsync(int id);
        Task<IEnumerable<AccountDTO>> GetAllAccountsAsync();
        Task<PaginatedList<AccountDTO>> GetAllAccountsPaginatedAsync(QueryParameters queryParameters);
        Task<AccountDTO?> UpdateAccountAsync(int accountId, UpdateAccountDTO updateDto);
        Task<bool> BanAccountAsync(int accountId);
        Task<bool> UnbanAccountAsync(int accountId);
    }
}
