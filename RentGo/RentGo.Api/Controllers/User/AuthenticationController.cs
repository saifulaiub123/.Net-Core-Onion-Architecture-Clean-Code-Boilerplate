using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentGo.Application.Response;
using RentGo.Domain.DBModel;
using RentGo.Domain.Model;

namespace RentGo.Api.Controllers.User
{
    public class AuthenticationController : ControllerBaseUser
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.MobileNumber);
            if (userExists != null)
            {
                userExists.DeviceToken = model.DeviceToken;
                await userManager.UpdateAsync(userExists);
                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Ok", Message = "Successfully Login" });
            }
                //return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.MobileNumber,
                DeviceToken = model.DeviceToken,
                Status = 1
            };
            var result = await userManager.CreateAsync(user);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

    }
}
