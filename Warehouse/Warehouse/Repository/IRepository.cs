using System.Collections.Generic;

namespace Warehouse.Repository
{
    public interface IRepository
    {
        public void Add(IList<(string Material, string Warehouse, int Amount)> data);
        public IReadOnlyCollection<Data.Warehouse> Get();
    }
}
