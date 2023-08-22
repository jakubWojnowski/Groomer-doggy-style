using GroomerDoggyStyle.Application.Employee.Commands.CreateEmployee;
using GroomerDoggyStyle.Application.Employee.Commands.DeleteEmployee;
using GroomerDoggyStyle.Application.Employee.DTO;
using GroomerDoggyStyle.Application.Employee.Query.GetAllEmployeesQuery;
using GroomerDoggyStyle.Application.Employee.Query.GetByIdEmployeeQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GroomerDoggyStyle.Api.Controllers;

public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("employee")]
    public async Task<ActionResult> Create([FromBody] RegisterEmployeeDto registerEmployeeDto)
    {
        var id = await _mediator.Send(new CreateEmployeeCommand(registerEmployeeDto));

        return Created($"employee/{id}", null);

    }
    [HttpGet("employee/{id}")]
    public async Task<ActionResult<EmployeeDto>> GetById(int id)
    {
        var employee = await _mediator.Send(new GetByIdEmployeeQuery(id));
        return Ok(employee);
    }
    [HttpGet("employees")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
    {
        var employees = await _mediator.Send(new GetAllEmployeesQuery());
        return Ok(employees);
    }

    [HttpDelete("employee/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteEmployeeCommand(id));
        return NoContent();
    }


}