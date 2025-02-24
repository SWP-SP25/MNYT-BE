using Domain.Entities;
using Domain.IRepos;

namespace Infrastructure.Repos
{
    public class CommentRepo : GenericRepo<Comment>, ICommentRepo
    {
        private readonly AppDbContext _appDbContext;

        public CommentRepo(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }
    }
}
