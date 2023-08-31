using GroomerDoggyStyle.Application.Employee.Mappings;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Employee.Commands.DeleteEmployee;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IGenericRepository<Domain.Entities.Employee, int> _genericRepository;
    private static readonly EmployeeMapper _mapper = new();
    
    public DeleteEmployeeCommandHandler(IGenericRepository<Domain.Entities.Employee, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
       var employee = await _genericRepository.GetById(request.Id);
         if (employee is null) throw new NotFoundException("Employee doesn't exist");
         await _genericRepository.Delete(employee);
    }
}