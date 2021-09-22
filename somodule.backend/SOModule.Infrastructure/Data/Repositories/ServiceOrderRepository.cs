using SOModule.Domain.Core.Interfaces.Repositories;
using SOModule.Domain.Models;

namespace SOModule.Infrastructure.Data.Repositories
{
    public class ServiceOrderRepository : BaseRepository<ServiceOrder>, IServiceOrderRepository
    {
        private readonly AppDbContext _dbContext;

        public ServiceOrderRepository(AppDbContext context) 
            : base(context)
        {
            _dbContext = context;
        }
    }
}