using GroomerDoggyStyle.Application.Employee.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Employee.Query.GetEmployees;

public record GetAllEmployeesQuery() : IRequest<IEnumerable<EmployeeDto>>;
