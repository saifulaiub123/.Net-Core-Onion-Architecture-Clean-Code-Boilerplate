using AutoMapper;
using RentGo.Application.IRepository;
using RentGo.Application.IService;
using RentGo.Domain.DBModel;

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
                var otpObj = new Otp();

                otpObj.MobileNumber = mobieNumber;
                otpObj.VerificationCode = Convert.ToString(await _smsHelper.SendSms(mobieNumber));
                otpObj.ExpiredAt = DateTime.Now.AddMinutes(5);
                await _otpRepository.Insert(otpObj);
                await _otpRepository.SaveAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
