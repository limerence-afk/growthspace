using EndavaGrowthSpace.Domain.Entities;
using EndavaGrowthSpace.Domain.Enums;

namespace EndavaGrowthSpace.BLL.Models.Courses;

public class GetCourseDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public User? CreatedBy { get; set; }
    public Discipline Discipline { get; set; }
    public string? Description { get; set; }
    public Difficulty Difficulty { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public IEnumerable<GetModuleDto> Modules { get; set; }
}

public class GetModuleDto
{
    public string? Title { get; set; }
}