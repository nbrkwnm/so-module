using AutoMapper;
using SOModule.Application.Dtos;
using SOModule.Domain.Models;

namespace SOModule.Application.Mappers
{
    public class ServiceOrderMapping : Profile
    {
        public ServiceOrderMapping()
        {
            ServiceOrderMap();
        }

        private void ServiceOrderMap()
        {
            CreateMap<ServiceOrder, ServiceOrderDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dest => dest.CustomerCnpj, opt => opt.MapFrom(c => c.CustomerCnpj))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(c => c.CustomerName))
                .ReverseMap();
        }
    }
}