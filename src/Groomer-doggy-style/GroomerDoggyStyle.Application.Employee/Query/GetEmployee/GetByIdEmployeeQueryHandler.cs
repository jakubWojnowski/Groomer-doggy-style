using GroomerDoggyStyle.Application.Employee.DTO;
using GroomerDoggyStyle.Application.Employee.Mappings;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Employee.Query.GetEmployee;

public class GetByIdEmployeeQueryHandler : IRequestHandler<GetByIdEmployeeQuery, EmployeeDto>
{
    private readonly IGenericRepository<Domain.Entities.Employee, int> _genericRepository;
    private static readonly EmployeeMapper _mapper = new();

    public GetByIdEmployeeQueryHandler(IGenericRepository<Domain.Entities.Employee, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<EmployeeDto> Handle(GetByIdEmployeeQuery request, CancellationToken cancellationToken)
    {
        var employee = await _genericRepository.GetById(request.Id);
        if (employee is null) throw new NotFoundException("Employee doesn't exist");
       var employeeDto = _mapper.MapEmployeeToEmployeeDto(employee);
        return employeeDto;
    }
}