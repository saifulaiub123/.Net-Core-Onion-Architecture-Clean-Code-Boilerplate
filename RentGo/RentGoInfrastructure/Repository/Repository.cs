using Microsoft.EntityFrameworkCore;
using RentGo.Application.IRepository;
using RentGoInfrastructure.DBContext;

namespace RentGo.Infrastructure.Repository
{
    public class Repository<TModel, TId> : IRepository<TModel, TId> where TModel: class
    {
        protected DbSet<TModel> DbSet;
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            DbSet = _context.Set<TModel>();
        }

        public async Task Insert(TModel entity)
        {
            await DbSet.AddAsync(entity);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
