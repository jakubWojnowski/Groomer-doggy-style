using GroomerDoggyStyle.Domain.Entities;

namespace GroomerDoggyStyle.Application.Service
{
    public interface IOwnerService
    {
        Task CreateOwnerAsync(Owner owner);
    }
}