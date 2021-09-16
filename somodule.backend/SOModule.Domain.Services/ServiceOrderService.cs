using SOModule.Domain.Core.Interfaces.Repositories;
using SOModule.Domain.Core.Interfaces.Services;
using SOModule.Domain.Models;

namespace SOModule.Domain.Services
{
    public class ServiceOrderService : BaseService<ServiceOrder>, IServiceOrderService
    {
        private readonly IServiceOrderRepository _repository;

        public ServiceOrderService(IServiceOrderRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

    }
}