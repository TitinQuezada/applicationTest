using System;

namespace Core.ViewModels
{
    public sealed class PermitViewModel
    {
        public int Id { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeLastName { get; set; }

        public PermitTypeViewModel PermitType { get; set; }

        public string Date { get; set; }
    }
}
