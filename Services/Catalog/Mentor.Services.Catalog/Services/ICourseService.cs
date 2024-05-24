﻿using Mentor.Services.Catalog.Dtos;
using Mentor.Shared.Dtos;

namespace Mentor.Services.Catalog.Services
{
    internal interface ICourseService
    {
        Task<Response<CourseDto>> GetByIdAsync(string id);
        Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId);
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto);
        Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
