using MediatR;

namespace GroomerDoggyStyle.Application.Employee.Commands.DeleteEmployee;

public record DeleteEmployeeCommand(int Id) : IRequest;
