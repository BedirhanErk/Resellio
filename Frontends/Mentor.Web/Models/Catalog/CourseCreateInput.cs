﻿namespace Mentor.Web.Models.Catalog
{
    public class CourseCreateInput
    {
        public string UserId { get; set; }

        public string CategoryId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        public FeatureViewModel Feature { get; set; }
    }
}
