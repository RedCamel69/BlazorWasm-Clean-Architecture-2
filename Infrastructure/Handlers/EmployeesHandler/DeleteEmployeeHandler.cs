using Application.Commands.Employees;
using Application.DTOs;
using Infrastructure.Data;
using MediatR;

namespace Infrastructure.Handlers.EmployeesHandler
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, ServiceResponse>
    {
        private readonly ApplicationDbContext applicationDbContext;
        
        public DeleteEmployeeHandler(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<ServiceResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await applicationDbContext.Employees.FindAsync(request.Id);
            if (employee == null)
                return new ServiceResponse(false, "Employee not found");

            applicationDbContext.Employees.Remove(employee);
            await applicationDbContext.SaveChangesAsync();
            return new ServiceResponse(true, "Deleted");
        }
    }
}
