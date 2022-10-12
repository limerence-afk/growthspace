namespace EndavaGrowthSpace.BLL.Models.Modules;

public class UpdateModuleDto
{
    public string? Title { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
}