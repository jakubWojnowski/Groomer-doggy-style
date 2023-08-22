using GroomerDoggyStyle.Application.Employee.DTO;
using GroomerDoggyStyle.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Riok.Mapperly.Abstractions;

namespace GroomerDoggyStyle.Application.Employee.Mappings;
[Mapper]
public partial class EmployeeMapper
{
    
    //RegisterEmployeeDto
    public partial Domain.Entities.Employee MapRegisterEmployeeDtoToEmployee(RegisterEmployeeDto registerEmployeeDto);
    public partial RegisterEmployeeDto MapEmployeeToRegisterEmployeeDto(Domain.Entities.Employee employee);
    
    public partial IEnumerable<RegisterEmployeeDto> MapEmployeesToRegisterEmployeesDto(IEnumerable<Domain.Entities.Employee> employees);
    
    public Domain.Entities.Employee MapAndUpdateRegisterEmployee(RegisterEmployeeDto registerEmployeeDto, Domain.Entities.Employee employee)
    {
    employee.Name = registerEmployeeDto.Name;
    employee.LastName = registerEmployeeDto.LastName;
    employee.Mail = registerEmployeeDto.Mail;
    employee.PhoneNumber = registerEmployeeDto.PhoneNumber;
    employee.GroomerShopId = registerEmployeeDto.GroomerShopId;



    return employee;
    }
    
    //EmployeeDto
    public partial Domain.Entities.Employee MapEmployeeDtoToEmployee(EmployeeDto employeeDto);
    public partial EmployeeDto MapEmployeeToEmployeeDto(Domain.Entities.Employee employee);

}