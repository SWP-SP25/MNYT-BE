using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepos
{
    public interface IAccountRepo : IGenericRepo<Account>
    {
        Task<Account> GetAsync(Expression<Func<Account, bool>> predicate, string includeProperties = "");
        Task<bool> AnyAsync(Expression<Func<Account, bool>> predicate);

        Task<Account> GetAsync(string username, string password);
    }
}
