using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SOModule.Application.Dtos;
using SOModule.Application.Interfaces;
using SOModule.Application.Mappers;
using SOModule.Domain.Core.Interfaces.Services;
using SOModule.Domain.Models;

namespace SOModule.Application
{
    public class ServiceOrderApplicationService : IServiceOrderApplicationService
    {
        private readonly IServiceOrderService _serviceOrderService;
        private readonly IMapper _mapper;
        
        public ServiceOrderApplicationService(IServiceOrderService serviceOrderService, IMapper mapper)
        {
            _serviceOrderService = serviceOrderService;
            _mapper = mapper;
        }
        
        public void Add(ServiceOrderDto serviceOrderDto)
        {
            _serviceOrderService.Add(_mapper.Map<ServiceOrder>(serviceOrderDto));
        }

        public void Update(ServiceOrderDto serviceOrderDto)
        {
            _serviceOrderService.Update(_mapper.Map<ServiceOrder>(serviceOrderDto));
        }

        public void Remove(int id)
        {
            _serviceOrderService.Remove(_serviceOrderService.GetById(id));
        }

        public IEnumerable<ServiceOrderDto> GetAll()
        {
            return _mapper.Map<IEnumerable<ServiceOrderDto>>(_serviceOrderService.GetAll().Where(c => c.IsActive));
        }

        public ServiceOrderDto GetById(int id)
        {
            return _mapper.Map<ServiceOrderDto>(_serviceOrderService.GetById(id));
        }
    }
}