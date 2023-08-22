using GroomerDoggyStyle.Application.Employee.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Employee.Commands.CreateEmployee;

public record CreateEmployeeCommand(RegisterEmployeeDto RegisterEmployeeDto) : IRequest<int>;
