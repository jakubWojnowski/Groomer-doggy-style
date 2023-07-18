using GroomerDoggyStyle.Application.GroomerShops.DTO;
using GroomerDoggyStyle.Application.GroomerShops.Mappings;
using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.GroomerShops.Query.GroomerShopGetById;

public class GetByIdGroomerShopQueryHandler : IRequestHandler<GetByIdGroomerShopQuery, GroomerShopDto>
{
    private readonly IGenericRepository<GroomerShop, int> _genericRepository;
    private static readonly GroomerShopMapper _mapper = new();

    public GetByIdGroomerShopQueryHandler(IGenericRepository<GroomerShop, int> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<GroomerShopDto> Handle(GetByIdGroomerShopQuery request, CancellationToken cancellationToken)
    {
        var groomerShop = await _genericRepository.GetById(request.Id);
        if (groomerShop is null) throw new NotFoundException("GroomerShop doesn't exist");

        var groomerShopDto =  _mapper.MapGroomerShopToGroomerShopDto(groomerShop);
       
        return groomerShopDto;
    }
}