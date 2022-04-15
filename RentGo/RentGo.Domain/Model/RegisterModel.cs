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
        public string VerificationCode { get; set; }
    }
}
