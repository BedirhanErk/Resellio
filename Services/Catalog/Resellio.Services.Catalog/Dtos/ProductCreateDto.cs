﻿namespace Resellio.Services.Catalog.Dtos
{
    public class ProductCreateDto
    {
        public string? UserId { get; set; }

        public string CategoryId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }
    }
}
