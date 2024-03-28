using Domain.Entities;
using MediatR;

namespace Application.Queries.Employees
{
    public class GetEmployeeByIdQuery(int id) : IRequest<Employee>
    {
        public int Id { get; } = id;
    }

}
