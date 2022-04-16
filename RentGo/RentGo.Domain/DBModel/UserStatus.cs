using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentGo.Domain.Model;

namespace RentGo.Domain.DBModel
{
    public class UserStatus : BaseIdentityModel<int>
    {
        public string Name { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
