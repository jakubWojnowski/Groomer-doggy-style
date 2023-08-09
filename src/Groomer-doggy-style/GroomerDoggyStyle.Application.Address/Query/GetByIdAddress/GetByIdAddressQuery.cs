using GroomerDoggyStyle.Application.Address.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Address.Query.GetByIdAddress;

public record GetByIdAddressQuery(int Id) : IRequest<AddressDto>;