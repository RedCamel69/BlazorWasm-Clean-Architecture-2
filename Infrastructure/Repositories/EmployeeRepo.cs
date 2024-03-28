using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EmployeeRepo : IEmployee
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationDbContext Context { get; }

        public async Task<ServiceResponse> AddAsync(Employee employee)
        {
            _context.Add(employee);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Added");
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee == null)
                return new ServiceResponse(false, "User not found");
            
            _context.Employees.Remove(employee);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Deleted");
        }
     

        public async Task<List<Employee>> GetAsync() =>
            await _context.Employees.AsNoTracking().ToListAsync<Employee>();
        

        public async Task<Employee> GetByIdAsync(int id) =>
            await _context.Employees.FindAsync(id);


        public async Task<ServiceResponse> UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Updated");
        }

        private async Task SaveChangesAsync()=>await _context.SaveChangesAsync();
    }
}
