﻿using System.ComponentModel.DataAnnotations;

namespace Mentor.Web.Models.Catalog
{
    public class CourseUpdateInput
    {
        [Required]
        public string Id { get; set; }

        public string? UserId { get; set; }

        [Display(Name = "Category")]
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        public FeatureViewModel Feature { get; set; }

        [Display(Name = "Picture")]
        public IFormFile PhotoFormFile { get; set; }
    }
}
