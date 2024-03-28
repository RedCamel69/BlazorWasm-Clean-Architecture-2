using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //not particularly ideal but the only workaround I've found successful to enable migrations etc
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BlazorWasmCleanArch;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public DbSet<Employee> Employees { get; set; }      
    }
}
