using CleanArchitecture_2025.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_2025.Domain.Employees
{
    public class Employee : Entity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string FullName => string.Join(" ", FirstName, LastName);
        public DateOnly BirthOfDate{ get; set; }
        public decimal Salary { get; set; }
        public Adress? Adress { get; set; }
        public PersonelInformation PersonelInfo { get; set; } = default!;
    }
}
