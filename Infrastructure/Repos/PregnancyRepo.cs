
using Domain.Entities;
using Domain.IRepos;

namespace Infrastructure.Repos
{
    public class PregnancyRepo : GenericRepo<Pregnancy>, IPregnancyRepo
    {
        private readonly AppDbContext _appDbContext;

        public PregnancyRepo(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }
    }
}
