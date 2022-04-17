namespace RentGo.Domain.Model
{
    public class VerifyOtp
    {
        public VerifyOtp(){}

        public VerifyOtp(string mobileNumber, string code)
        {
            MobileNumber = mobileNumber;
            Code = code;
        }
        public string MobileNumber { get; set; }
        public string Code { get; set; }
    }
}
