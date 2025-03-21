﻿using MediatR;

namespace Products_Management_API.Server.CQRS.Command.Category
{
    public class UpdateCategory : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
