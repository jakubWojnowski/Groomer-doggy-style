using GroomerDoggyStyle.Application.Employee.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Employee.Query.GetEmployee;

public record GetByIdEmployeeQuery(int Id) : IRequest<EmployeeDto>;