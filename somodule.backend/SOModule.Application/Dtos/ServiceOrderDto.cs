using System;

namespace SOModule.Application.Dtos
{
    public class ServiceOrderDto
    {
        public int Id { get; set; }
        public string ServiceOrderNumber { get; set; }
        public string ServiceDescription { get; set; }
        public string CustomerCnpj { get; set; }
        public string CustomerName { get; set; }
        public string ProfessionalCpf { get; set; }
        public string ProfessionalName { get; set; }
        public DateTime ExecutionDate { get; set; }
        public decimal ServiceValue { get; set; }

        public ServiceOrderDto()
        { }
    }
}