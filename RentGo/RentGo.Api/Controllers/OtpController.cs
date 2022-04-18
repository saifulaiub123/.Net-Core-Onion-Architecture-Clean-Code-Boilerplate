using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentGo.Application.IService;
using RentGo.Domain.Model;

namespace RentGo.Api.Controllers
{
    
    public class OtpController : ControllerBase
    {
        private readonly IOtpService _otpService;
        private readonly IUserContext _userContext;

        public OtpController(IOtpService otpService, IUserContext userContext)
        {
            _otpService = otpService;
            _userContext = userContext;
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

        [Authorize(Roles = "User")]
        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            
            var p = _userContext;
            return Ok("Ok");
        }
    }
}
