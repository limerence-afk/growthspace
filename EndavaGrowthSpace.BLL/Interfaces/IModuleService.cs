using EndavaGrowthSpace.BLL.Models.Modules;
using EndavaGrowthSpace.Domain.Entities;

namespace EndavaGrowthSpace.BLL.Interfaces;

public interface IModuleService
{
    Module Add(CreateModuleDto createModuleDto, int userId);
    Module GetById(int id);
    void Delete(int id);
    void Update(UpdateModuleDto updateModuleDto, int id, int userId);
}