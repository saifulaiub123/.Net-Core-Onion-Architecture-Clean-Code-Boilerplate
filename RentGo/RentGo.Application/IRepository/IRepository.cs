

using System.Linq.Expressions;
using RentGo.Domain.Model;

namespace RentGo.Application.IRepository
{
    public interface IRepository<TModel, TId> where TModel : BaseModel<TId>
    {
        Task<IReadOnlyList<TModel>> GetAll();
        Task<IReadOnlyList<TModel>> GetAllAsTracking();
        Task<IReadOnlyList<TModel>> GetAll(params Expression<Func<TModel, object>>[] includes);
        Task<IReadOnlyList<TModel>> GetAllAsTracking(params Expression<Func<TModel, object>>[] includes);

        Task<IReadOnlyList<TModel>> GetAll(
            Expression<Func<TModel, bool>> filter,
            params Expression<Func<TModel, object>>[] includes);

        Task<IReadOnlyList<TModel>> GetAllAsTracking(
            Expression<Func<TModel, bool>> filter,
            params Expression<Func<TModel, object>>[] includes);

        //Task<IReadOnlyList<TModel>> GetAllPaged(
        //    Expression<Func<TModel, bool>> filter, IPagination pagination,
        //    params Expression<Func<TModel, object>>[] includes);
        Task<TModel> GetById(TId id);
        Task<TModel> FindBy(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes);
        Task<TModel> FindByAsTracking(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes);
        Task Insert(TModel entity);
        Task<TModel> InsertReturn(TModel entity);
        Task InsertRange(IEnumerable<TModel> entity);
        Task Update(TModel entity);
        Task UpdateRange(IEnumerable<TModel> entity);
        Task Delete(TId id);
        Task Delete(TModel id);
        Task DeleteRange(IEnumerable<TModel> entities);

        Task<TModel> GetByIdThrowIfNotFound(TId id);
        Task<int> Count(Expression<Func<TModel, bool>> filter);
        Task SaveAsync();
    }
}
