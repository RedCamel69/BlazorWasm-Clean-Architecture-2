using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Employees
{
    public class CreateEmployeeCommand :IRequest<ServiceResponse>
    {
        public Employee? Employee { get; set; }
    }
}
