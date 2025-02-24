
using Domain.Entities;
using Domain.IRepos;

namespace Infrastructure.Repos
{
    public class ScheduleUserRepo : GenericRepo<ScheduleUser>, IScheduleUserRepo
    {
        private readonly AppDbContext _appDbContext;

        public ScheduleUserRepo(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }
    }
}
