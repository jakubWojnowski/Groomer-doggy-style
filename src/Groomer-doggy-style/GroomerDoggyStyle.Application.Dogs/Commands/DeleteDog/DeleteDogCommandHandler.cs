using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Dogs.Commands.DeleteDog;

public class DeleteDogCommandHandler : IRequestHandler<DeleteDogCommand>
{
    private readonly IDogRepository _dogRepository;

    public DeleteDogCommandHandler(IDogRepository dogRepository)
    {
        _dogRepository = dogRepository;
    }

    public async Task Handle(DeleteDogCommand request, CancellationToken cancellationToken)
    {
        var dog = await _dogRepository.GetDogByIdAsync(request.Id);
        if (dog is null) throw new NotFoundException("dogo is not there");

        await _dogRepository.DeleteDogAsync(dog);
    }
}