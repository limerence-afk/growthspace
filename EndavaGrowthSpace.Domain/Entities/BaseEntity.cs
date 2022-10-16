namespace EndavaGrowthSpace.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = CreatedAt;
        }
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; }
        public DateTimeOffset UpdatedAt { get; protected set; }

        public void NotifyUpdated()
        {
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}