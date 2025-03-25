﻿namespace Application.ViewModels.Media
{
    public class ReadMediaDTO
    {
        public int Id { get; set; }

        public string? EntityType { get; set; }

        public int? EntityId { get; set; }

        public string? Type { get; set; }

        public string? Url { get; set; }
    }
}
