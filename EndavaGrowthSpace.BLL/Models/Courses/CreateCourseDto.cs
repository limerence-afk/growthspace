using EndavaGrowthSpace.Domain.Entities;
using EndavaGrowthSpace.Domain.Enums;

namespace EndavaGrowthSpace.BLL.Models.Courses;

public class CreateCourseDto
{
    public string? Title { get; set; }
    public Discipline Discipline { get; set; }
    public string? Description { get; set; }
    public Difficulty Difficulty { get; set; }
    public List<Module>? Modules { get; set; }
}