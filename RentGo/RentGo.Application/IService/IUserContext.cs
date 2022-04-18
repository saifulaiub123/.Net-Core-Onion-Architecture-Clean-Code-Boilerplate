using RentGo.Domain.DBModel;

namespace RentGo.Application.IService
{
    public interface IUserContext
    {
        ApplicationUser User { get; }
    }
}
