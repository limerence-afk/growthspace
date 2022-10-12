using EndavaGrowthSpace.DAL.Interfaces;
using EndavaGrowthSpace.Domain.Entities;

namespace EndavaGrowthSpace.DAL.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly List<Course> _entities = new();

    public Course Add(Course entity)
    {
        entity.Id = new Random().Next();
        _entities.Add(entity);
        return entity;
    }

    public IEnumerable<Course> Get()
    {
        return _entities;
    }

    public IEnumerable<Course> Find(Func<Course, bool> predicate)
    {
        return _entities.Where(predicate);
    }

    public void Delete(int id)
    {
        var index = _entities.FindIndex(e => e.Id == id);
        if (index == -1) throw new Exception();

        _entities.RemoveAt(index);
    }

    public Course? GetById(int id)
    {
        return _entities.FirstOrDefault(entity => entity.Id == id);
    }
}