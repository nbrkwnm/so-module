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
        
        public bool Add(ServiceOrderDto serviceOrderDto)
        {
            if (ValidateEntity(serviceOrderDto))
            {
                return false;
            }
            
            _serviceOrderService.Add(_mapper.Map<ServiceOrder>(serviceOrderDto));
            
            return true;
        }

        public bool Update(ServiceOrderDto serviceOrderDto)
        {
            if (ValidateEntity(serviceOrderDto))
            {
                return false;
            }
            
            _serviceOrderService.Update(_mapper.Map<ServiceOrder>(serviceOrderDto));
            
            return true;
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

        private bool ValidateEntity(ServiceOrderDto serviceOrderDto)
        {
            if (serviceOrderDto.CustomerCnpj.Length != 14 ||
                serviceOrderDto.ProfessionalCpf.Length != 11 ||
                serviceOrderDto.CustomerName == null ||
                serviceOrderDto.ServiceDescription == null ||
                serviceOrderDto.ServiceValue < 0 ||
                serviceOrderDto.ServiceOrderNumber == null
            )
            {
                return false;
            }

            return true;
        }
    }
}