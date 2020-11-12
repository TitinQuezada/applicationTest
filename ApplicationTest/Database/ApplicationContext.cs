using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Database
{
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ApplicationContext)));
        }

        public DbSet<Permit> Permit { get; set; }

        public DbSet<PermitType> PermitType { get; set; }
    }
}
