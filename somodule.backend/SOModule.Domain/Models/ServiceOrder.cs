using System;

namespace SOModule.Domain.Models
{
    public class ServiceOrder : BaseEntity
    {
        public string ServiceOrderNumber { get; set; }
        public string ServiceDescription { get; set; }
        public string CustomerCnpj { get; set; }
        public string CustomerName { get; set; }
        public string ProfessionalCpf { get; set; }
        public DateTime ExecutionDate { get; set; }
        public decimal ServiceValue { get; set; }

        public ServiceOrder()
        { }
    }
}