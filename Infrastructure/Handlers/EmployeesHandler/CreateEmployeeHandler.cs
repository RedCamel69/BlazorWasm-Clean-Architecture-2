using Application.Commands.Employees;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.EmployeesHandler
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, ServiceResponse>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CreateEmployeeHandler(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<ServiceResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            //handler expand the create employee logic in a more manageable way
            var check = await applicationDbContext.Employees
                .FirstOrDefaultAsync(_ => _.Name!.ToLower() == request!.Employee!.Name!.ToLower());

            if (check != null)
            {
                return new ServiceResponse(false, "Employee already exists");
            }

            applicationDbContext.Add(request.Employee);
            await applicationDbContext.SaveChangesAsync();
            return new ServiceResponse(true, $"Added Employee {request.Employee.Name}"); ;
        }
    }
}
