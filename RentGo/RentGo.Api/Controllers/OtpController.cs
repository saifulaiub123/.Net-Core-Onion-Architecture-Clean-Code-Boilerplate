using Microsoft.AspNetCore.Mvc;
using RentGo.Application.IService;

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
    }
}
