using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.GroomerShops.Commands.GroomerShopDelete;

public class DeleteGroomerShopCommandHandler : IRequestHandler<DeleteGroomerShopCommand>
{
    private readonly IGenericRepository<GroomerShop, int> _genericRepository;
    

    public DeleteGroomerShopCommandHandler(IGenericRepository<GroomerShop, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task Handle(DeleteGroomerShopCommand request, CancellationToken cancellationToken)
    {
        var groomerShop = await _genericRepository.GetById(request.Id);
        if (groomerShop is null) throw new NotFoundException("Groomer shop doesn't exist");

        await _genericRepository.Delete(groomerShop);
    }
}