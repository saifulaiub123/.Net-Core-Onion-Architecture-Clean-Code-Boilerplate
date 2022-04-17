using RentGo.Domain.DBModel;

namespace RentGo.Application.IRepository
{
    public interface IOtpRepository : IRepository<Otp, int>
    {
        Task<Otp> GetLatestOtp(string mobileNumber);
    }
}
