namespace EndavaGrowthSpace.Domain.Entities
{
    public class Module : BaseEntity
    {
        public string? Title { get; set; }
        public User? CreatedBy { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public int Order { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}