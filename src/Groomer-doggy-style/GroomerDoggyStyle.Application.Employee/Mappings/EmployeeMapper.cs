using GroomerDoggyStyle.Application.Employee.DTO;
using GroomerDoggyStyle.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace GroomerDoggyStyle.Application.Employee.Mappings;
[Mapper]
public partial class EmployeeMapper
{
    public partial Domain.Entities.Employee MapEmployeeDtoToEmployee(EmployeeDto employeeDto);
    public partial EmployeeDto MapEmployeeToEmployeeDto(Domain.Entities.Employee employee);
    
    public partial IEnumerable<EmployeeDto> MapEmployeesToEmployeesDto(IEnumerable<Domain.Entities.Employee> employees);
    
    public Domain.Entities.Employee MapAndUpdate(EmployeeDto employeeDto, Domain.Entities.Employee employee)
    {
  

        return employee;
    }

}