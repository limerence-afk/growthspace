using EndavaGrowthSpace.BLL.Interfaces;
using EndavaGrowthSpace.BLL.Models.Courses;
using EndavaGrowthSpace.DAL.Interfaces;
using EndavaGrowthSpace.Domain.Entities;

namespace EndavaGrowthSpace.BLL.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IAuthenticationProvider _authenticationProvider;

    public CourseService(ICourseRepository courseRepository, IAuthenticationProvider authenticationProvider
    )
    {
        _courseRepository = courseRepository;
        _authenticationProvider = authenticationProvider;
    }

    public Course Add(CreateCourseDto createCourseDto)
    {
        var userId = _authenticationProvider.GetUserId();
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

    public GetCourseDto GetById(int id)
    {
        var userId = _authenticationProvider.GetUserId();
        var course = _courseRepository.GetById(id);
        if (course is null)
        {
            throw new Exception();
        }

        if (course.CreatedBy?.Id == userId ||
            course.Enrollments.All(u => u.Id != userId) ||
            course.Contributors.All(u => u.Id != userId))
        {
            throw new Exception();
        }

        return CourseToDto(course);
    }

    private static GetCourseDto CourseToDto(Course course)
    {
        return new GetCourseDto()
        {
            Id = course.Id,
            Title = course.Title,
            CreatedBy = course.CreatedBy,
            Discipline = course.Discipline,
            Description = course.Description,
            Difficulty = course.Difficulty,
            CreatedAt = course.CreatedAt,
            UpdatedAt = course.UpdatedAt,
            Modules = course.Modules.Select(m => new GetModuleDto() {Title = m.Title})
        };
    }

    public void Delete(int id)
    {
        var userId = _authenticationProvider.GetUserId();
        var course = _courseRepository.GetById(id);
        if (course is null)
        {
            throw new Exception();
        }

        if (course.CreatedBy?.Id != userId)
        {
            throw new Exception();
        }

        _courseRepository.Delete(id);
    }
  
    public void EnrollUser(int courseId)
    {
        var userId = _authenticationProvider.GetUserId();
        var course = _courseRepository.GetById(courseId);
        if (course is null)
        {
            throw new Exception();
        }

        course.Enrollments.Add(new User() {Id = userId});
    }

    public GetCourseDto Update(UpdateCourseDto updateCourseDto, int id)
    {
        var userId = _authenticationProvider.GetUserId();
        var course = _courseRepository.GetById(id);
        if (course is null)
        {
            throw new Exception();
        }

        if (userId != course.CreatedBy?.Id) throw new Exception();
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
        return CourseToDto(course);
    }
}