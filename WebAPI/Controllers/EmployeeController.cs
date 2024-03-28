using Application.Commands.Employees;
using Application.Interfaces;
using Application.Queries.Employees;
using Application.Services;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// private readonly IEmployee employee;
        /// </summary>
        private readonly IMediator mediator;

        public EmployeeController(
            //IEmployee employee, 
            IMediator mediator)
        {
           // this.employee = employee;
            this.mediator = mediator;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await mediator.Send(new GetEmployeeListQuery()));

        //public async Task<IActionResult> Get()
        //{
        //    return Ok(await employee.GetAsync());
        //}

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //return Ok(await employee.GetByIdAsync(id));
            return Ok(await mediator.Send(new GetEmployeeByIdQuery(id)));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employeeDto)
        {
            //var result = await employee.AddAsync(employeeDto);
            var result = await mediator.Send(new CreateEmployeeCommand()
            {
                Employee = employeeDto
            });

            return Ok(result);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employee employeeDto)
        {
            //var result = await employee.UpdateAsync(employeeDto);
            var result = await mediator.Send(new UpdateEmployeeCommand()
            {
                Employee = employeeDto
            });

            return Ok(result);
          
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var result = await employee.DeleteAsync(id);
            var result = await mediator.Send(new DeleteEmployeeCommand(id));
            return Ok(result);
        }
    }
}
