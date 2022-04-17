using RentGo.Application.IService;
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
