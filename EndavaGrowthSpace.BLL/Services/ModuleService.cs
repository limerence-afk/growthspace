using EndavaGrowthSpace.BLL.Interfaces;
using EndavaGrowthSpace.BLL.Models.Modules;
using EndavaGrowthSpace.DAL.Interfaces;
using EndavaGrowthSpace.Domain.Entities;

namespace EndavaGrowthSpace.BLL.Services;

public class ModuleService : IModuleService
{
    private readonly IModuleRepository _moduleRepository;

    public ModuleService(IModuleRepository moduleRepository)
    {
        _moduleRepository = moduleRepository;
    }

    public Module Add(CreateModuleDto createModuleDto, int userId)
    {
        var module = new Module()
        {
            Title = createModuleDto.Title,
            CreatedBy = new User() { Id = userId },
            CreatedAt = createModuleDto.CreatedAt,
            UpdatedAt = createModuleDto.UpdatedAt,
            Description = createModuleDto.Description,
            Content = createModuleDto.Content,
            Order = createModuleDto.Order
        };
        return _moduleRepository.Add(module);
    }

    public Module GetById(int id)
    {
        return _moduleRepository.GetById(id);
    }

    public void Delete(int id)
    {
        _moduleRepository.Delete(id);
    }

    public void Put(UpdateModuleDto updateModuleDto, int id, int userId)
    {
        var module = _moduleRepository.GetById(id);
        if (userId == module.CreatedBy.Id)
        {
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

            module.UpdatedAt = updateModuleDto.UpdatedAt;
        }
    }
}