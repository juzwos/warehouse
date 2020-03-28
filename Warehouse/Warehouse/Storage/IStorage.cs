using System.Collections.Generic;

namespace Warehouse.Storage
{
    public interface IStorage
    {
        public void Add(IList<(string Material, string Warehouse, int Amount)> data);
        public IReadOnlyCollection<Data.Warehouse> Get();
    }
}
