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
            await _otpService.SendOtp(mobileNumber);
            ;
        }
        [HttpGet("VerifyOtp")]
        public async Task VerifyOtp([FromQuery] VerifyOtp verifyOtp)
        {
            await _otpService.VerifyOtp(verifyOtp);
            ;
        }
    }
}
