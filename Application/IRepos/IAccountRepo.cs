using Domain.Entities;
using System.Linq.Expressions;

namespace Application.IRepos
{
    public interface IAccountRepo : IGenericRepo<Account>
    {
        Task<Account> GetByUsernameOrEmail(string email, string Username);
        Task<bool> AnyAsync(Expression<Func<Account, bool>> predicate);
    }
}
