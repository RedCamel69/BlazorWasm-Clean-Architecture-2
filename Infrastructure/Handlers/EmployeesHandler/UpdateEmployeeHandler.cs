using Application.Commands.Employees;
using Application.DTOs;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Handlers.EmployeesHandler
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, ServiceResponse>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UpdateEmployeeHandler(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<ServiceResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            //handler expand the create employee logic in a more manageable way
            var check = await applicationDbContext.Employees.AsNoTracking()
                .FirstOrDefaultAsync(_ => _.Name!.ToLower() == request!.Employee!.Name!.ToLower());

            if (check == null)
            {
                return new ServiceResponse(false, "Employee not found");
            }

            try
            {

                applicationDbContext.Update(request.Employee);
                await applicationDbContext.SaveChangesAsync();
                return new ServiceResponse(true, $"Updated Employee {request.Employee.Name}");
            }
            catch(Exception ex)
            {
                return new ServiceResponse(false, $"Failed to updated Employee {request.Employee.Name}");
            }
           
        }
    }
}
