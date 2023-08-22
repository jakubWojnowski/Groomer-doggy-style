using FluentValidation;
using GroomerDoggyStyle.Application.Employee.DTO;
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
    private readonly IValidator<RegisterEmployeeDto> _validator;
    private static readonly EmployeeMapper _employeeMapper = new();


    public CreateEmployeeCommandHandler(IGenericRepository<Domain.Entities.Employee, int> genericEmployeeRepository, IPasswordHasher<Domain.Entities.Employee> passwordHasher,
        IValidator<RegisterEmployeeDto> validator)
    {
        _genericEmployeeRepository = genericEmployeeRepository;
        _passwordHasher = passwordHasher;
        _validator = validator;
    }
    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.RegisterEmployeeDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var employee = _employeeMapper.MapRegisterEmployeeDtoToEmployee(request.RegisterEmployeeDto);
        var hashedPassword = _passwordHasher.HashPassword(employee, request.RegisterEmployeeDto.Password);
        employee.HashedPassword = hashedPassword;

       var id = await _genericEmployeeRepository.Add(employee);

       return id;
    }
}