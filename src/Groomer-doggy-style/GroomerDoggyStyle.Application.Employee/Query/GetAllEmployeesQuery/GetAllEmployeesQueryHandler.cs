﻿using GroomerDoggyStyle.Application.Employee.DTO;
using GroomerDoggyStyle.Application.Employee.Mappings;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Employee.Query.GetAllEmployeesQuery;

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
{
    private readonly IGenericRepository<Domain.Entities.Employee, int> _genericRepository;
    private static readonly EmployeeMapper _mapper = new();

    public GetAllEmployeesQueryHandler(IGenericRepository<Domain.Entities.Employee, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _genericRepository.GetAll();
        return _mapper.MapEmployeesToEmployeesDto(employees);
    }
}