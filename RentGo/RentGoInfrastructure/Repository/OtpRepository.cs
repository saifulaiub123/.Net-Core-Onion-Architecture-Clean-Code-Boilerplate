﻿using Microsoft.EntityFrameworkCore;
using RentGo.Domain.DBModel;
using RentGo.Domain.IRepository;
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
            try
            {
                return await _context.Otps.Where(x => x.MobileNumber == mobileNumber)
                    .OrderByDescending(x => x.DateCreated).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
