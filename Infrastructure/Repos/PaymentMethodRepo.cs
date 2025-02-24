
using Domain.Entities;
using Domain.IRepos;

namespace Infrastructure.Repos
{
    public class PaymentMethodRepo : GenericRepo<PaymentMethod>, IPaymentMethodRepo
    {
        private readonly AppDbContext _appDbContext;
        public PaymentMethodRepo(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }
    }
}
