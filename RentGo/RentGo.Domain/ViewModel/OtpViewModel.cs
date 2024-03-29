﻿using RentGo.Domain.Model;

namespace RentGo.Domain.ViewModel
{
    public class OtpViewModel : BaseIdentityModel<int>
    {
        public string MobileNumber { get; set; }
        public int VerificationCode { get; set; }
        public DateTime ExpiredAt { get; set; }
        public bool IsVerified { get; set; }
    }
}
