
using Domain.Entities;
using Domain.IRepos;

namespace Infrastructure.Repos
{
    public class FetusRepo : GenericRepo<Fetus>, IFetusRepo
    {
        private readonly AppDbContext _appDbContext;

        public FetusRepo(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }
    }
}
