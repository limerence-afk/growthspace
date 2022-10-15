using EndavaGrowthSpace.BLL.Interfaces;
using EndavaGrowthSpace.BLL.Models.Courses;
using EndavaGrowthSpace.DAL.Interfaces;
using EndavaGrowthSpace.Domain.Entities;

namespace EndavaGrowthSpace.BLL.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public Course Add(CreateCourseDto createCourseDto, int userId)
    {
        var course = new Course()
        {
            Title = createCourseDto.Title,
            CreatedBy = new User() {Id = userId},
            Description = createCourseDto.Description,
            Discipline = createCourseDto.Discipline,
            Difficulty = createCourseDto.Difficulty,
        };

        return _courseRepository.Add(course);
    }


    public Course GetById(int id)
    {
        var course = _courseRepository.GetById(id);
        if (course is null)
        {
            throw new Exception();
        }

        return course;
    }

    public void Delete(int id)
    {
        _courseRepository.Delete(id);
    }

    public void EnrollUser(int courseId, int userId)
    {
        var course = _courseRepository.GetById(courseId);
        if (course is null)
        {
            throw new Exception();
        }

        course.Enrollments.Add(new User() {Id = userId});
    }

    public void Update(UpdateCourseDto updateCourseDto, int id, int userId)
    {
        var course = _courseRepository.GetById(id);
        if (course is null)
        {
            throw new Exception();
        }

        if (userId != course.CreatedBy?.Id) return;
        if (updateCourseDto.Title is not null)
        {
            course.Title = updateCourseDto.Title;
        }

        if (updateCourseDto.Description is not null)
        {
            course.Description = updateCourseDto.Description;
        }

        if (updateCourseDto.Difficulty is not null)
        {
            course.Difficulty = updateCourseDto.Difficulty.Value;
        }

        if (updateCourseDto.Discipline is not null)
        {
            course.Discipline = updateCourseDto.Discipline.Value;
        }

        course.NotifyUpdated();
    }
}