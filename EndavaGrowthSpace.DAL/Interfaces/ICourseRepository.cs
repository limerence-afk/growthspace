using EndavaGrowthSpace.Domain.Entities;

namespace EndavaGrowthSpace.DAL.Interfaces;

public interface ICourseRepository
{
    Course Add(Course entity);
    IEnumerable<Course> Get();
    IEnumerable<Course> Find(Func<Course, bool> predicate);
    void Delete(int id);
    Course? GetById(int id);
}