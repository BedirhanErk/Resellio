using AutoMapper;
using Resellio.Services.Catalog.Dtos;
using Resellio.Services.Catalog.Models;

namespace Resellio.Services.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();

            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CourseCreateDto>().ReverseMap();
            CreateMap<Course, CourseUpdateDto>().ReverseMap();

            CreateMap<Feature, FeatureDto>().ReverseMap();
        }
    }
}
