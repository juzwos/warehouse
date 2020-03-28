using System;
using System.Collections.Generic;
using System.Linq;

namespace Warehouse.Repository
{
    public class InMemory : IRepository
    {
        private readonly List<Data.Warehouse> _warehouses = new List<Data.Warehouse>();

        public void Add(IList<(string Material, string Warehouse, int Amount)> data)
        {
            foreach (var warehouseMaterials in data.GroupBy(x => x.Warehouse))
            {
                var wh = new Data.Warehouse(warehouseMaterials.Key);
                wh.AddMaterials(warehouseMaterials.AsEnumerable());

                _warehouses.Add(wh);
            }
        }

        public IReadOnlyCollection<Data.Warehouse> Get()
        {
            return _warehouses;
        }
    }
}
