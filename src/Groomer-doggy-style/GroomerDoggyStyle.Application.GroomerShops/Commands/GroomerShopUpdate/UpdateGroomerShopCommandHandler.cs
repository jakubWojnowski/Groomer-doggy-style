using GroomerDoggyStyle.Application.GroomerShops.Mappings;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.GroomerShops.Commands.GroomerShopUpdate;

public class UpdateGroomerShopCommandHandler : IRequestHandler<UpdateGroomerShopCommand>
{
    private readonly IGenericRepository<GroomerShop, int> _genericRepository;
    private static readonly GroomerShopMapper _mapper = new();

    public UpdateGroomerShopCommandHandler(IGenericRepository<GroomerShop, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task Handle(UpdateGroomerShopCommand request, CancellationToken cancellationToken)
    {
        var groomerShop = await _genericRepository.GetById(request.Id);
        if (groomerShop is null) throw new NotFoundException("Groomer shop doesn't exist");

        var groomerShopUpdate = _mapper.MapAndUpdate(request.GroomerShopDto, groomerShop);
        await _genericRepository.Update(groomerShopUpdate);

    }
}