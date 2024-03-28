using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Employees
{
    public class DeleteEmployeeCommand(int Id) : IRequest<ServiceResponse>
    {
        public int Id { get; } = Id;
    }
}
