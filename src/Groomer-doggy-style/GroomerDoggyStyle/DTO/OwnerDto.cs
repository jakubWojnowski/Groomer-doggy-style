﻿using GroomerDoggyStyle.Domain.Entities;

namespace GroomerDoggyStyle.Api.DTO
{
    public class OwnerDto
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Mail { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
