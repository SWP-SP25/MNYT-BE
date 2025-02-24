
namespace Domain.IRepos
{
    public interface IGenericRepo<TModel> where TModel : BaseEntity
    {
        Task AddAsync(TModel model);
        void Update(TModel model);
        void Delete(TModel model);
        void SoftDelete(TModel model);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> GetAsync(int id);

    }
}
