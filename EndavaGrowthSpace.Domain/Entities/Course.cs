using EndavaGrowthSpace.Domain.Enums;

namespace EndavaGrowthSpace.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string? Title { get; set; }
        public User? CreatedBy { get; set; }
        public Discipline Discipline { get; set; }
        public string? Description { get; set; }
        public Difficulty Difficulty { get; set; }
        public List<User> Contributors { get; set; } = new List<User>();
        public List<Module> Modules { get; set; } = new List<Module>();
        public List<User> Enrollments { get; set; } = new List<User>();
    }
}