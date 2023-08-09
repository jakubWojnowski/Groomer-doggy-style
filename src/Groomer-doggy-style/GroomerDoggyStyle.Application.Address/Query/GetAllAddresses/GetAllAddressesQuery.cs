using GroomerDoggyStyle.Application.Address.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Address.Query.GetAllAddresses;

public record GetAllAddressesQuery : IRequest<IEnumerable<AddressDto>>;
