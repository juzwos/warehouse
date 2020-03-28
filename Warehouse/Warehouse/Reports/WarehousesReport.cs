using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Warehouse.Storage;

namespace Warehouse.Reports
{
    public class WarehousesReport : IPresenter
    {
        private readonly IStorage _storage;

        public WarehousesReport(IStorage storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }
        public string GetData()
        {
            var sb = new StringBuilder();

            foreach (var warehouse in  _storage.Get()
                .OrderByDescending<Warehouse.Data.Warehouse, int>(x => Enumerable.Sum((IEnumerable<int>) x.Materials().Values))
                .ThenByDescending(x=>x.Name))
            {
                var materials = string.Join(Environment.NewLine, warehouse.Materials()
                    .OrderBy(x => x.Key.Name)
                    .Select(x => $"{x.Key.Name}: {x.Value}"));
                
                    sb.AppendLine($"{warehouse.Name} ({warehouse.Materials().Values.Sum()}){Environment.NewLine}{materials}");
                sb.AppendLine();
            }

            return sb.ToString().Trim();
        }
    }
}
