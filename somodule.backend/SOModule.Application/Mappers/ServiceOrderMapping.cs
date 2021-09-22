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
                .ForMember(dest => dest.ServiceOrderNumber, opt => opt.MapFrom(c => c.ServiceOrderNumber))
                .ForMember(dest => dest.ServiceDescription, opt => opt.MapFrom(c => c.ServiceDescription))
                .ForMember(dest => dest.CustomerCnpj, opt => opt.MapFrom(c => c.CustomerCnpj))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(c => c.CustomerName))
                .ForMember(dest => dest.ProfessionalCpf, opt => opt.MapFrom(c => c.ProfessionalCpf))
                .ForMember(dest => dest.ProfessionalName, opt => opt.MapFrom(c => c.ProfessionalName))
                .ForMember(dest => dest.ExecutionDate, opt => opt.MapFrom(c => c.ExecutionDate))
                .ForMember(dest => dest.ServiceValue, opt => opt.MapFrom(c => c.ServiceValue))
                .ReverseMap();
        }
    }
}