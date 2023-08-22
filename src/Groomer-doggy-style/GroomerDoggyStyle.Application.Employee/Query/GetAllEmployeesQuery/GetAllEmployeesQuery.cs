using GroomerDoggyStyle.Application.Employee.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Employee.Query.GetAllEmployeesQuery;

public record GetAllEmployeesQuery() : IRequest<IEnumerable<EmployeeDto>>;
