using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentGo.Api.Authentication;
using RentGo.Application.Enum;
using RentGo.Application.IService;
using RentGo.Application.Response;
using RentGo.Domain.Constant;
using RentGo.Domain.DBModel;
using RentGo.Domain.Model;

namespace RentGo.Api.Controllers.User
{
    public class AuthenticationController : ControllerBaseUser
    {

        private readonly JWTExtensions _jwtExt;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IOtpService _otpService;
        private readonly IConfiguration _configuration;

        public AuthenticationController(
            JWTExtensions jwtExt,
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IOtpService otpService,
            IConfiguration configuration)
        {
            _jwtExt = jwtExt;
            _userManager = userManager;
            _roleManager = roleManager;
            _otpService = otpService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] RegisterModel model)
        {
            try
            {
                var user = new ApplicationUser();
                var otpResponse = await _otpService.VerifyOtp(new VerifyOtp(model.MobileNumber, model.Code));

                if(otpResponse.Status != OtpResponseEnum.OK)
                    return StatusCode(StatusCodes.Status500InternalServerError, otpResponse);

                var userExists = await _userManager.FindByNameAsync(model.MobileNumber);
                if (userExists == null)
                {
                    user = new ApplicationUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = model.MobileNumber,
                        DeviceToken = model.DeviceToken,
                        Status = (int)UserStatusEnum.Active
                    };
                    var result = await _userManager.CreateAsync(user);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, RoleConst.USER);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new Response(ResponseStatus.FAILED, Message.USER_REGISTRATION_FAILED));
                    }
                }
                else
                {
                    user = userExists;
                    userExists.DeviceToken = model.DeviceToken;
                    await _userManager.UpdateAsync(userExists);
                }

                var userRoles = await _userManager.GetRolesAsync(user);

                var token = await _jwtExt.GetToken(user, userRoles);
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
