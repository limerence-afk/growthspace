using EndavaGrowthSpace.Domain.Entities;

namespace EndavaGrowthSpace.DAL.Interfaces;

public interface IModuleRepository
{
    Module Add(Module entity);
    IEnumerable<Module> Get();
    IEnumerable<Module> Find(Func<Module, bool> predicate);
    void Delete(int id);
    Module? GetById(int id);
}