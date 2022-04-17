using Microsoft.AspNetCore.Mvc;
using RentGo.Application.IService;
using RentGo.Domain.Model;

namespace RentGo.Api.Controllers
{
    
    public class OtpController : ControllerBase
    {
        private readonly IOtpService _otpService;

        public OtpController(IOtpService otpService)
        {
            _otpService = otpService;
        }

        [HttpGet("SendOtp")]
        public async Task SendOtp([FromQuery] string mobileNumber)
        {
            try
            {
                await _otpService.SendOtp(mobileNumber);
            }
            catch (Exception e)
            {
                throw;
            }
            
        }
        [HttpGet("VerifyOtp")]
        public async Task VerifyOtp([FromQuery] VerifyOtp verifyOtp)
        {
            try
            {
                await _otpService.VerifyOtp(verifyOtp);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
