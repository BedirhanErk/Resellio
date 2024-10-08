﻿namespace Resellio.Web.Models.Catalog
{
    public class ProductViewModel
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string CategoryId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string PictureUrl { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get => Description.Length > 100 ? Description.Substring(0, 100) + "..." : Description; }

        public DateTime CreatedDate { get; set; }

        public CategoryViewModel Category { get; set; }
    }
}
