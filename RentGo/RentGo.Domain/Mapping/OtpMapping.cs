using AutoMapper;
using RentGo.Domain.DBModel;
using RentGo.Domain.ViewModel;

namespace RentGo.Domain.Mapping
{
    public class OtpMapping : Profile
    {
        public OtpMapping()
        {
            CreateMap<OtpViewModel,Otp>()
                .ReverseMap();
        }
    }
}
