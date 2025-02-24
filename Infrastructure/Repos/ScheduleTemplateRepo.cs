
using Domain.Entities;
using Domain.IRepos;

namespace Infrastructure.Repos
{
    public class ScheduleTemplateRepo : GenericRepo<ScheduleTemplate>, IScheduleTemplateRepo
    {
        private readonly AppDbContext _appDbContext;

        public ScheduleTemplateRepo(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }
    }
}
