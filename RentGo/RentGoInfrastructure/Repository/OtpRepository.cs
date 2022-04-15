using RentGo.Application.IRepository;
using RentGo.Domain.DBModel;
using RentGoInfrastructure.DBContext;

namespace RentGo.Infrastructure.Repository
{
    public class OtpRepository : Repository<Otp, int>, IOtpRepository
    {
        public OtpRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
