using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SOModule.Domain.Models
{
    [Table("TBSERVICEORDER")]
    public class ServiceOrder : BaseEntity
    {
        public string ServiceOrderNumber { get; set; }
        public string ServiceDescription { get; set; }
        public string CustomerCnpj { get; set; }
        public string CustomerName { get; set; }
        public string ProfessionalCpf { get; set; }
        public string ProfessionalName { get; set; }
        public DateTime ExecutionDate { get; set; }
        public decimal ServiceValue { get; set; }

        public ServiceOrder()
        { }
    }
}