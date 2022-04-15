using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentGo.Application.IService
{
    public interface IOtpService
    {
        Task SendOtp(string mobileNumber);
    }
}
