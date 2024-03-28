using Application.Queries.Employees;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Handlers.EmployeesHandler
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery,List<Employee>>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public GetEmployeeListHandler(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        
        public async Task<List<Employee>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
            => await applicationDbContext.Employees.AsNoTracking().ToListAsync<Employee>();
        

       
      
    }
}
