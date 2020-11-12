using System;

namespace Core.Models
{
    public sealed class Permit : BaseModel
    {
        public string EmployeeName { get; set; }

        public string EmployeeLastName { get; set; }

        public PermitType PermitType { get; set; }

        public DateTime Date { get; set; }
    }
}
