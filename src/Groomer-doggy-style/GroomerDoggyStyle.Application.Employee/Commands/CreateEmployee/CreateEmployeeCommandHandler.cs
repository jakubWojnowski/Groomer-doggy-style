using GroomerDoggyStyle.Application.Employee.Mappings;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GroomerDoggyStyle.Application.Employee.Commands.CreateEmployee;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IGenericRepository<Domain.Entities.Employee, int> _genericEmployeeRepository;
    private readonly IPasswordHasher<Domain.Entities.Employee> _passwordHasher;
    private static readonly EmployeeMapper _employeeMapper = new();


    public CreateEmployeeCommandHandler(IGenericRepository<Domain.Entities.Employee, int> genericEmployeeRepository, IPasswordHasher<Domain.Entities.Employee> passwordHasher)
    {
        _genericEmployeeRepository = genericEmployeeRepository;
        _passwordHasher = passwordHasher;
    }
    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = _employeeMapper.MapEmployeeDtoToEmployee(request.EmployeeDto);
        employee.Id = request.Id;
        var hashedPassword = _passwordHasher.HashPassword(employee, request.EmployeeDto.Password);
        employee.HashedPassword = hashedPassword;

       var id = await _genericEmployeeRepository.Add(employee);

       return id;
    }
}