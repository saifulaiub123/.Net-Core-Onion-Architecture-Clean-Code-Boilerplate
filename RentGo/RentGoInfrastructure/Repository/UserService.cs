using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentGo.Application.IService;
using RentGo.Domain.DBModel;
using RentGoInfrastructure.DBContext;

namespace RentGo.Infrastructure.Repository
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {

        }
       
    }
}
