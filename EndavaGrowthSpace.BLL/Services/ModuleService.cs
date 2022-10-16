using EndavaGrowthSpace.BLL.Interfaces;
using EndavaGrowthSpace.BLL.Models.Modules;
using EndavaGrowthSpace.DAL.Interfaces;
using EndavaGrowthSpace.Domain.Entities;

namespace EndavaGrowthSpace.BLL.Services;

public class ModuleService : IModuleService
{
    private readonly IModuleRepository _moduleRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IAuthenticationProvider _authenticationProvider;

    public ModuleService(IModuleRepository moduleRepository, ICourseRepository courseRepository,
        IAuthenticationProvider authenticationProvider)
    {
        _moduleRepository = moduleRepository;
        _courseRepository = courseRepository;
        _authenticationProvider = authenticationProvider;
    }

    public Module Add(CreateModuleDto createModuleDto)
    {
        var userId = _authenticationProvider.GetUserId();
        var course = _courseRepository.GetById(createModuleDto.CourseId);
        if (course is null)
        {
            throw new Exception();
        }

        var module = new Module()
        {
            Title = createModuleDto.Title,
            CreatedBy = new User() {Id = userId},
            Description = createModuleDto.Description,
            Content = createModuleDto.Content,
            Order = createModuleDto.Order,
            CourseId = createModuleDto.CourseId,
            Course = course
        };

        course.Modules.Add(module);

        return _moduleRepository.Add(module);
    }

    public Module GetById(int id)
    {
        var userId = _authenticationProvider.GetUserId();
        var module = _moduleRepository.GetById(id);
        if (module is null)
        {
            throw new Exception();
        }

        var course = module.Course;
        if (course is null)
        {
            throw new Exception();
        }

        if (course.Enrollments.All(u => u.Id != userId))
        {
            throw new Exception();
        }

        return module;
    }

    public void Delete(int id)
    {
        var userId = _authenticationProvider.GetUserId();
        var module = _moduleRepository.GetById(id);
        if (module is null)
        {
            throw new Exception();
        }

        if (module.CreatedBy?.Id != userId)
        {
            throw new Exception();
        }

        var course = module.Course;
        if (course is null)
        {
            throw new Exception();
        }

        course.Modules.Remove(module);
        _moduleRepository.Delete(id);
    }

    public Module Update(UpdateModuleDto updateModuleDto, int id)
    {
        var userId = _authenticationProvider.GetUserId();
        var module = _moduleRepository.GetById(id);
        if (module is null)
        {
            throw new Exception();
        }

        if (userId != module.CreatedBy?.Id) throw new Exception();
        if (updateModuleDto.Title is not null)
        {
            module.Title = updateModuleDto.Title;
        }

        if (updateModuleDto.Description is not null)
        {
            module.Description = updateModuleDto.Description;
        }

        if (updateModuleDto.Content is not null)
        {
            module.Content = updateModuleDto.Content;
        }

        module.NotifyUpdated();
        return module;
    }
}