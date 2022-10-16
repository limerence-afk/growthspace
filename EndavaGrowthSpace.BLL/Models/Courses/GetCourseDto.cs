using EndavaGrowthSpace.Domain.Entities;

namespace EndavaGrowthSpace.BLL.Models.Courses;

public class GetCourseDto
{
    public IEnumerable<GetModuleDto> Modules { get; set; } 
}

public class GetModuleDto
{
    public string? Title { get; set; }
}