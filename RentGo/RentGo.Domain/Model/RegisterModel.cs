using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentGo.Domain.Model
{
    public class RegisterModel
    {
        public string MobileNumber { get; set; }
        public string Code { get; set; }
        public string DeviceToken { get; set; }
        public string IPAddress { get; set; }
        public UserGeoLocation UserGeoLocation { get; set; }
    }
}
