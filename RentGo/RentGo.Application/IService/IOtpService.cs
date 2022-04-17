using RentGo.Application.Response;
using RentGo.Domain.Model;

namespace RentGo.Application.IService
{
    public interface IOtpService
    {
        Task SendOtp(string mobileNumber);
        Task<OtpResponse> VerifyOtp(VerifyOtp verifyOtp);
    }
}
