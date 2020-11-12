using System;

namespace Core.ViewModels
{
    public sealed class PermitCreateOrEditViewModel
    {
        public int Id { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeLastName { get; set; }

        public int PermitType { get; set; }

        public DateTime Date { get; set; }
    }
}
