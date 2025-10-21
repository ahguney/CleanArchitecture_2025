using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_2025.Domain.Employees
{
    public sealed record Adress
    {
      public string? Country { get; set; }
      public string? City { get; set; }
      public string? Town { get; set; }
      public string? FullAdress { get; set; }
    }
}
