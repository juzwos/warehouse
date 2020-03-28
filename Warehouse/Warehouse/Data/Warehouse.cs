using System.Collections.Generic;
using System.Linq;

namespace Warehouse.Data
{
    public class Warehouse
    {
        public string Name { get; }
        private readonly Dictionary<Material, int> _materialInWarehouse = new Dictionary<Material, int>();

        public Warehouse(string name)
        {
            Name = name;
        }

        public void AddMaterials(IEnumerable<(string Material, string Warehouse, int Amount)> materials)
        {
            foreach (var material in materials)
            {
                _materialInWarehouse.TryAdd(new Material(material.Material), material.Amount);
            }
        }

        public IReadOnlyDictionary<Material, int> Materials()
        {
            return _materialInWarehouse;
        }
    }
}
