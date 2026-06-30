using Demo.Application.Commands;
using Demo.Application.Queries;
using Demo.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clean_architecture_demo_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IMediator mediator) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] Employee employee)
        {
            var result = await mediator.Send(new AddEmployeeCommand(employee));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeAsync()
        {
            var result = await mediator.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllEmployeeByIdAsync([FromRoute] Guid id)
        {
            var result = await mediator.Send(new GetEmployeeByIdQuery(id));
            return Ok(result);
        }

        [HttpPut("{employeeid}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] Guid id, [FromBody] Employee employee)
        {
            var result = await mediator.Send(new UpdateEmployeeCommand(id,employee));
            return Ok(result);
        }


        [HttpDelete("{employeeid}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] Guid id)
        {
            var result = await mediator.Send(new DeleteEmployeeCommand(id));
            return Ok(result);
        }
    }
}
