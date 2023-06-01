using GroomerDoggyStyle.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroomerDoggyStyle.Domain.Interfaces
{
    public interface IOwnerRepository
    {
        Task CreateOwnerAsync(Owner owner);
    }
}
