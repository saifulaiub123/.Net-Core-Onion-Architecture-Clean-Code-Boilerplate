using Microsoft.EntityFrameworkCore;
using RentGo.Application.IRepository;
using RentGo.Domain.DBModel;
using RentGoInfrastructure.DBContext;

namespace RentGo.Infrastructure.Repository
{
    public class OtpRepository : Repository<Otp, int>, IOtpRepository
    {
        private readonly ApplicationDbContext _context;
        public OtpRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Otp> GetLatestOtp(string mobileNumber)
        {
            return await _context.Otps.Where(x => x.MobileNumber == mobileNumber)
                .OrderByDescending(x => x.DateCreated).FirstOrDefaultAsync();
        }
    }
}
