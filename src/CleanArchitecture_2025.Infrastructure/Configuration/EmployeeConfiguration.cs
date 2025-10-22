using CleanArchitecture_2025.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_2025.Infrastructure.Configuration
{
    internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Employee> builder)
        {
            builder.OwnsOne(p=>p.PersonelInformation,builder => {
            builder.Property(p => p.TCNO).HasColumnName("TCNo");
            builder.Property(p => p.PhoneNumber1).HasColumnName("PhoneNumber1");
            builder.Property(p => p.PhoneNumber2).HasColumnName("PhoneNumber2");
            builder.Property(p => p.Email).HasColumnName("Email");
            });

            builder.OwnsOne(p=>p.Adress, builder =>
            {
                builder.Property(p => p.City).HasColumnName("City");
                builder.Property(p => p.Town).HasColumnName("Town");
                builder.Property(p => p.Country).HasColumnName("Country");
                builder.Property(p => p.FullAdress).HasColumnName("FullAdress");  
            });
            builder.Property(p => p.Salary).HasColumnType("money");
        }
    }
}
