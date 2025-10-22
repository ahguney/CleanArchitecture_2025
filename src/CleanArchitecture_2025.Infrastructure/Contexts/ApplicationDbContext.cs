using CleanArchitecture_2025.Domain.Abstractions;
using CleanArchitecture_2025.Domain.Employees;
using GenericRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_2025.Infrastructure.Contexts
{
    public sealed class ApplicationDbContext : DbContext , IUnitOfWork
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly); // otomatik olarak tüm konfigürasyonları uygular
        }

        override public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Entity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(p=>p.CreatedAt)
                        .CurrentValue = DateTimeOffset.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    if(entry.Property(p=>p.IsDeleted).CurrentValue == true)
                    {
                        entry.Property(p => p.DeletedAt)
                            .CurrentValue = DateTimeOffset.Now;
                    }
                    else
                    {
                        entry.Property(p => p.UpdatedAt)
                             .CurrentValue = DateTimeOffset.Now;
                    }
                }

                if(entry.State == EntityState.Deleted)
                {
                    throw new ArgumentException("Db'den silme islemi yapılamaz");
                }

            }
            return base.SaveChangesAsync(cancellationToken);
        
        }
    }
}
