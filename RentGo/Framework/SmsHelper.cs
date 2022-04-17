using RentGo.Application.IService;

namespace RentGo.Framework
{
    public class SmsHelper : ISmsHelper
    {
        public async Task<int> SendSms(string mobileNumber)
        {
            try
            {
                var verificationCode = 1234;
                return verificationCode;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
