using System.Collections.Generic;
using SOModule.Application.Dtos;

namespace SOModule.Application.Interfaces
{
    public interface IServiceOrderApplicationService
    {
        bool Add(ServiceOrderDto documentDto);
        bool Update(ServiceOrderDto documentDto);
        void Remove(int id);
        IEnumerable<ServiceOrderDto> GetAll();
        ServiceOrderDto GetById(int id);
    }
}