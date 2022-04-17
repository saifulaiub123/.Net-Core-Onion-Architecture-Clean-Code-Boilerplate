using RentGo.Domain.Model;

namespace RentGo.Domain.DBModel
{
    public class Otp : BaseModel<int>
    {
        public string MobileNumber { get; set; }
        public string VerificationCode { get; set; }
        public DateTime ExpiredAt { get; set; }
        public bool IsVerified { get; set; }
    }
}
