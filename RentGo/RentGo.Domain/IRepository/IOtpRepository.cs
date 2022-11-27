using RentGo.Domain.DBModel;

namespace RentGo.Domain.IRepository
{
    public interface IOtpRepository : IRepository<Otp, int>
    {
        Task<Otp> GetLatestOtp(string mobileNumber);
    }
}
