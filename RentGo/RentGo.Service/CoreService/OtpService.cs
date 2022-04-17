using RentGo.Application.Enum;
using RentGo.Application.IRepository;
using RentGo.Application.IService;
using RentGo.Application.Response;
using RentGo.Domain.Constant;
using RentGo.Domain.DBModel;
using RentGo.Domain.Model;

namespace RentGo.Service.CoreService
{
    public class OtpService : IOtpService
    {
        private readonly ISmsHelper _smsHelper;
        private readonly IOtpRepository _otpRepository;

        public OtpService(
        ISmsHelper smsHelper,
        IOtpRepository otpRepository
        )
        {
            _smsHelper  = smsHelper;
            _otpRepository = otpRepository;
        }
        public async Task SendOtp(string mobieNumber)
        {
            try
            {
                var otpObj = new Otp
                {
                    MobileNumber = mobieNumber,
                    VerificationCode = Convert.ToString(await _smsHelper.SendSms(mobieNumber)),
                    ExpiredAt = DateTime.Now.AddMinutes(10)
                };
                await _otpRepository.Insert(otpObj);
                await _otpRepository.SaveAsync();
            }
            catch (Exception e)
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
