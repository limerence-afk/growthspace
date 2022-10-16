using EndavaGrowthSpace.BLL.Models.Modules;
using EndavaGrowthSpace.Domain.Entities;

namespace EndavaGrowthSpace.BLL.Interfaces;

public interface IModuleService
{
    Module Add(CreateModuleDto createModuleDto);
    Module GetById(int id);
    void Delete(int id);
    Module Update(UpdateModuleDto updateModuleDto, int id);
}