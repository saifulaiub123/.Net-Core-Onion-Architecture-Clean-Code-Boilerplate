using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentGo.Domain.Model
{
    public class UserGeoLocation : BaseIdentityModel<int>
    {
        public string UserId { get; set; }
        public string Location { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
