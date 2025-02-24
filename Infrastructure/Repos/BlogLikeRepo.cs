using Domain.Entities;
using Domain.IRepos;

namespace Infrastructure.Repos
{
    public class BlogLikeRepo : GenericRepo<BlogLike> , IBlogLikeRepo
    {
        private readonly AppDbContext _appDbContext;

        public BlogLikeRepo(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }
    }
}
