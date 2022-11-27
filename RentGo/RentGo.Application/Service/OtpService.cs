using RentGo.Application.Enum;
using RentGo.Application.IService;
using RentGo.Application.Response;
using RentGo.Domain.Constant;
using RentGo.Domain.DBModel;
using RentGo.Domain.IRepository;
using RentGo.Domain.Model;

namespace RentGo.Application.Service
{
    public class OtpService : IOtpService
    {
        private readonly IOtpRepository _otpRepository;

        public OtpService(IOtpRepository otpRepository)
        {
            _otpRepository = otpRepository;
        }
        public async Task SendOtp(string mobieNumber)
        {
            try
            {
                var otpObj = new Otp
                {
                    MobileNumber = mobieNumber,
                    VerificationCode = "",
                    ExpiredAt = DateTime.Now.AddMinutes(10)
                };
                await _otpRepository.Insert(otpObj);
                await _otpRepository.SaveAsync();
            }
            catch (System.Exception e)
            {
                throw;
            }
        }

        public async Task<OtpResponse> VerifyOtp(VerifyOtp verifyOtp)
        {
            try
            {
                var otp = await _otpRepository.GetLatestOtp(verifyOtp.MobileNumber);
                if (otp.ExpiredAt < DateTime.Now)
                {
                    return new OtpResponse(OtpResponseEnum.EXPIRED, Message.OTP_EXPIRED);
                }
                return otp.VerificationCode == verifyOtp.Code ? new OtpResponse(OtpResponseEnum.OK, Message.OTP_VERIFIED) : new OtpResponse(OtpResponseEnum.UNVERIFIED, Message.OTP_VERIFICATION_FAILED);
            }
            catch (System.Exception e)
            {
                throw;
            }
        }
    }
}
