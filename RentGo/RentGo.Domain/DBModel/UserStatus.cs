
using RentGo.Domain.Model;

namespace RentGo.Domain.DBModel
{
    public class UserStatus : BaseIdentityModel<int>
    {
        public string Name { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
