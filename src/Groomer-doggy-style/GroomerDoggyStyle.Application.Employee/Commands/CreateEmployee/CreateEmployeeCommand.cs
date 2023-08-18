using GroomerDoggyStyle.Application.Employee.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Employee.Commands.CreateEmployee;

public record CreateEmployeeCommand(EmployeeDto EmployeeDto, int Id) : IRequest<int>;
