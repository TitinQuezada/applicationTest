using System;

namespace Core.ViewModels
{
    public sealed class PermitViewModel
    {
        public int Id { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeLastName { get; set; }

        public string PermitType { get; set; }

        public DateTime Date { get; set; }
    }
}
