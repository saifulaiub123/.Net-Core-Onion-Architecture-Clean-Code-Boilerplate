
using AutoMapper;
using RentGo.Domain.DBModel;
using RentGo.Domain.ViewModel;

namespace RentGo.Infrastructure.Mapping
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
