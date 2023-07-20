using GroomerDoggyStyle.Application.Address.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Address.Commands.CreateAddress;

public record CreateAddressCommand(AddressDto AddressDto, int AddressId) : IRequest<int>;