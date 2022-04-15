using RentGo.Domain.Model;

namespace RentGo.Infrastructure.DBModel
{
    public class Otp : BaseIdentityModel<int>
    {
        public string MobileNumber { get; set; }
        public string VerificationCode { get; set; }
        public DateTime ExpiredAt { get; set; }
        public bool IsVerified { get; set; }
    }
}
