using Domain.Entities;
using Domain.IRepos;

namespace Infrastructure.Repos
{
    public class AccountMembershipRepo : GenericRepo<AccountMembership>, IAccountMembershipRepo
    {
        private readonly AppDbContext _appDbContext;
        public AccountMembershipRepo(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }
    }
}
