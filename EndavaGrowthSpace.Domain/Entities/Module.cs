namespace EndavaGrowthSpace.Domain.Entities
{


    public class Module : BaseEntity
    {
        public string? Title { get; set; }
        public User? CreatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public int Order { get; set; }

    }
}