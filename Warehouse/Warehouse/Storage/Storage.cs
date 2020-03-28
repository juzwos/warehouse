using System.Collections.Generic;
using Warehouse.Repository;

namespace Warehouse.Storage
{
    public class Storage : IStorage
    {
        public readonly IRepository _repository;
        public Storage(IRepository repository)
        {
            _repository = repository;
        }

        public void Add(IList<(string Material, string Warehouse, int Amount)> data)
        {
            _repository.Add(data);
        }

        public IReadOnlyCollection<Data.Warehouse> Get()
        {
            return _repository.Get();
        }

    }
}
