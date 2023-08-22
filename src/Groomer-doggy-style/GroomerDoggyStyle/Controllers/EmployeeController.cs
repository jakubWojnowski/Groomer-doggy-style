using GroomerDoggyStyle.Application.Employee.Commands.CreateEmployee;
using GroomerDoggyStyle.Application.Employee.DTO;
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
  
    
}