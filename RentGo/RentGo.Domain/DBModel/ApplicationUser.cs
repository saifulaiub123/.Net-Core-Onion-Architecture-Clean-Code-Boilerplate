using Microsoft.AspNetCore.Identity;

namespace RentGo.Domain.DBModel
{
    public class ApplicationUser : IdentityUser<int>
    {
        public int Status { get; set; }
        public string DeviceToken { get; set; }

        public virtual UserStatus UserStatus { get; set; }
    }
}
