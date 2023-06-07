using GroomerDoggyStyle.Application.DTO;
using MediatR;
using System.ComponentModel;

namespace GroomerDoggyStyle.Application.Commands.UpdateOwner
{
    public class UpdateOwnerCommand : OwnerDto, IRequest
    {
        public int Id { get; set; }

        public UpdateOwnerCommand(int id, string name, string lastName, string mail, string phoneNumber)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Mail = mail;
            PhoneNumber = phoneNumber;
        }
    }
}
