using EndavaGrowthSpace.Domain.Entities;

namespace EndavaGrowthSpace.BLL.Models.Modules;

public class CreateModuleDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public int Order { get; set; }
    public int CourseId { get; set; }
    
    
}