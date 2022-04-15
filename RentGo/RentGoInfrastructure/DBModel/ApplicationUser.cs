using Microsoft.AspNetCore.Identity;

namespace RentGo.Infrastructure.DBModel
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
