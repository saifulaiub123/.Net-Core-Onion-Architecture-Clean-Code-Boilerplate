

namespace RentGo.Application.IRepository
{
    public interface IRepository<TModel, TId>
    {
        Task Insert(TModel entity);
        Task SaveAsync();
    }
}
