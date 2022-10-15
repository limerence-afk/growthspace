using EndavaGrowthSpace.BLL.Interfaces;
using EndavaGrowthSpace.BLL.Models.Modules;
using EndavaGrowthSpace.DAL.Interfaces;
using EndavaGrowthSpace.Domain.Entities;

namespace EndavaGrowthSpace.BLL.Services;

public class ModuleService : IModuleService
{
    private readonly IModuleRepository _moduleRepository;
    private readonly ICourseRepository _courseRepository;

    public ModuleService(IModuleRepository moduleRepository, ICourseRepository courseRepository)
    {
        _moduleRepository = moduleRepository;
        _courseRepository = courseRepository;
    }

    public Module Add(CreateModuleDto createModuleDto, int userId)
    {
        var module = new Module()
        {
            Title = createModuleDto.Title,
            CreatedBy = new User() {Id = userId},
            Description = createModuleDto.Description,
            Content = createModuleDto.Content,
            Order = createModuleDto.Order,
            CourseId = createModuleDto.CourseId
        };

        var course = _courseRepository.GetById(createModuleDto.CourseId);
        if (course is null)
        {
            throw new Exception();
        }

        course.Modules.Add(module);


        return _moduleRepository.Add(module);
    }

    public Module GetById(int id)
    {
        var module = _moduleRepository.GetById(id);
        if (module is null)
        {
            throw new Exception();
        }

        return module;
    }

    public void Delete(int id)
    {
        var module = _moduleRepository.GetById(id);
        if (module is null)
        {
            throw new Exception();
        }

        var course = _courseRepository.GetById(module.CourseId);
        if (course is null)
        {
            throw new Exception();
        }

        course.Modules.Remove(module);
        _moduleRepository.Delete(id);
    }

    public void Update(UpdateModuleDto updateModuleDto, int id, int userId)
    {
        var module = _moduleRepository.GetById(id);
        if (module is null)
        {
            throw new Exception();
        }

        if (userId != module.CreatedBy?.Id) return;
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
    }
}