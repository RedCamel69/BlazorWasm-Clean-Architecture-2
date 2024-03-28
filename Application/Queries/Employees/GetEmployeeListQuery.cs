using Domain.Entities;
using MediatR;

namespace Application.Queries.Employees
{
    public class GetEmployeeListQuery : IRequest<List<Employee>>{}
}
