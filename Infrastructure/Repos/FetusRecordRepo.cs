
using Domain.Entities;
using Domain.IRepos;

namespace Infrastructure.Repos
{
    public class FetusRecordRepo : GenericRepo<FetusRecord>, IFetusRecordRepo
    {
        private readonly AppDbContext _appDbContext;

        public FetusRecordRepo(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }
    }
}
