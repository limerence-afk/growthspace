using EndavaGrowthSpace.BLL.Models.Courses;
using EndavaGrowthSpace.Domain.Entities;

namespace EndavaGrowthSpace.BLL.Interfaces;

public interface ICourseService
{
    Course Add(CreateCourseDto createCourseDto, int userId);
    Course GetById(int id);
    void Delete(int id);
    void Update(UpdateCourseDto updateCourseDto, int id, int userId);
    void EnrollUser(int courseId, int userId);
}