using EndavaGrowthSpace.BLL.Interfaces;
using EndavaGrowthSpace.BLL.Models.Courses;
using Microsoft.AspNetCore.Mvc;

namespace EndavaGrowthSpace.Controllers;

[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpPost]
    public IActionResult Add(CreateCourseDto createCourseDto)
    {
        return StatusCode(201, _courseService.Add(createCourseDto));
    }

    [HttpGet("{id}")]
    public ActionResult<GetCourseDto> GetById(int id)
    {
        return _courseService.GetById(id);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id)
    {
        _courseService.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<GetCourseDto> Update(UpdateCourseDto updateCourseDto, int id)
    {
        return _courseService.Update(updateCourseDto, id);
    }

    [HttpPost("{id}/enrollUser")]
    public IActionResult EnrollUser(int id)
    {
        _courseService.EnrollUser(id);
        return Ok();
    }
}