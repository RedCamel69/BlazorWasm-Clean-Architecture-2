using Application.Queries.Employees;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Handlers.EmployeesHandler
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {

        private readonly ApplicationDbContext applicationDbContext;

        public GetEmployeeByIdHandler(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
            => await applicationDbContext.Employees.FindAsync(request.Id);
        
    }
}
