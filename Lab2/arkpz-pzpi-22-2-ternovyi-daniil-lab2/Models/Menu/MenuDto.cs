﻿using System.Text.Json.Serialization;

namespace ChefMate_backend.Models
{
    public class MenuDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
