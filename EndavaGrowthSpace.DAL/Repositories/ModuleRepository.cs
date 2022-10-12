using EndavaGrowthSpace.DAL.Interfaces;
using EndavaGrowthSpace.Domain.Entities;


namespace EndavaGrowthSpace.DAL.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly List<Module> _entities = new();

        public Module Add(Module entity)
        {
            entity.Id = new Random().Next();
            _entities.Add(entity);
            return entity;
        }

        public IEnumerable<Module> Get()
        {
            return _entities;
        }

        public IEnumerable<Module> Find(Func<Module, bool> predicate)
        {
            return _entities.Where(predicate);
        }

        public void Update(Module module, int id)
        {
            var index = _entities.FindIndex(e => e.Id == id);
            if (index == -1) throw new Exception();
            _entities[index] = module;
        }

        public void Delete(int id)
        {
            var index = _entities.FindIndex(e => e.Id == id);
            if (index == -1) throw new Exception();

            _entities.RemoveAt(index);
        }

        public Module? GetById(int id)
        {
            return _entities.FirstOrDefault(entity => entity.Id == id);
        }
    }
}