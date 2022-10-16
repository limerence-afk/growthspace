using EndavaGrowthSpace.BLL.Models.Courses;
using EndavaGrowthSpace.Domain.Entities;

namespace EndavaGrowthSpace.BLL.Interfaces;

public interface ICourseService
{
    Course Add(CreateCourseDto createCourseDto);
    GetCourseDto GetById(int id);
    void Delete(int id);
    GetCourseDto Update(UpdateCourseDto updateCourseDto, int id);
    void EnrollUser(int courseId);
}