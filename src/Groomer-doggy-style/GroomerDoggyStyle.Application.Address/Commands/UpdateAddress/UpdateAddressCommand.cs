using GroomerDoggyStyle.Application.Address.DTO;
using MediatR;

namespace GroomerDoggyStyle.Application.Address.Commands.UpdateAddress;

public record UpdateAddressCommand(AddressDto AddressDto, int Id) : IRequest;
