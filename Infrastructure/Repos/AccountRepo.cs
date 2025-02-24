using Domain.Entities;
using Domain.IRepos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repos
{
    public class AccountRepo : GenericRepo<Account>, IAccountRepo
    {
        private readonly AppDbContext _appDbContext;
        public AccountRepo(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task<Account> GetAsync(Expression<Func<Account, bool>> predicate, string includeProperties = "")
        {
            IQueryable<Account> query = _dbSet;

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<Account, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<Account> GetAsync(string username, string password)
        {
            var result = await _appDbContext.Accounts.FirstOrDefaultAsync(x => x.Email == username && x.Password == password);
            return result;
        }
    }
}
