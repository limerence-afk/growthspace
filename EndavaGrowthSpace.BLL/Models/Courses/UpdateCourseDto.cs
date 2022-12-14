using EndavaGrowthSpace.Domain.Enums;

namespace EndavaGrowthSpace.BLL.Models.Courses;

public class UpdateCourseDto
{
    public string? Title { get; set; }
    public Discipline? Discipline { get; set; }
    public string? Description { get; set; }
    public Difficulty? Difficulty { get; set; }
}