using GroomerDoggyStyle.Application.GroomerShops.Mappings;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.GroomerShops.Commands.CreateGroomerShops;

public class CreateGroomerShopCommandHandler : IRequestHandler<CreateGroomerShopCommand, int>
{
    private readonly IGenericRepository<GroomerShop, int> _genericRepository;
    private static readonly GroomerShopMapper _mapper = new();

    public CreateGroomerShopCommandHandler(IGenericRepository<GroomerShop, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<int> Handle(CreateGroomerShopCommand request, CancellationToken cancellationToken)
    {
        var groomerShop = _mapper.MapGroomerShopDtoToGroomerShop(request.GroomerShopDto);
        var id = await _genericRepository.Add(groomerShop);
        return id;

    }
}