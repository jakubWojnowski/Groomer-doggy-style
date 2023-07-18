using GroomerDoggyStyle.Application.GroomerShops.DTO;
using GroomerDoggyStyle.Application.GroomerShops.Mappings;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.GroomerShops.Query.GetAllGroomerShops;

public class GetAllGroomerShopsQueryHandler : IRequestHandler<GetAllGroomerShopsQuery, IEnumerable<GroomerShopDto>>
{
    private readonly IGenericRepository<GroomerShop, int> _genericRepository;
    private static readonly GroomerShopMapper _mapper = new();

    public GetAllGroomerShopsQueryHandler(IGenericRepository<GroomerShop, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<IEnumerable<GroomerShopDto>> Handle(GetAllGroomerShopsQuery request, CancellationToken cancellationToken)
    {
        var groomerShops = await _genericRepository.GetAll();

        return _mapper.MapGroomerShopsToGroomerShop(groomerShops);
    }
}