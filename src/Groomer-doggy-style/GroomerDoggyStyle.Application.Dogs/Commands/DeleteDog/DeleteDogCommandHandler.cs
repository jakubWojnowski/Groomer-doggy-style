using GroomerDoggyStyle.Domain.Entities;
using GroomerDoggyStyle.Domain.Exceptions;
using GroomerDoggyStyle.Domain.Interfaces;
using MediatR;

namespace GroomerDoggyStyle.Application.Dogs.Commands.DeleteDog;

public class DeleteDogCommandHandler : IRequestHandler<DeleteDogCommand>
{
    private readonly IDogRepository _dogRepository;
    private readonly IGenericRepository<Dog, int> _genericRepository;

    public DeleteDogCommandHandler(IDogRepository dogRepository, IGenericRepository<Dog,int> genericRepository)
    {
        _dogRepository = dogRepository;
        _genericRepository = genericRepository;
    }

    public async Task Handle(DeleteDogCommand request, CancellationToken cancellationToken)
    {
        var dog = await _genericRepository.GetById(request.Id);
        if (dog is null) throw new NotFoundException("dogo is not there");

        await _genericRepository.Delete(dog);
    }
}