using System;
using System.Collections.Generic;
using System.Linq;

namespace Warehouse.Parser
{
    public class Parser : IParser
    {
        public IList<(string Material, string Warehouse, int Amount)> Parse(ISource source)
        {
            var ret = new List<(string Material, string warehouse, int Amount)>();

            foreach (var line in source.GetData())
            {
              ret.AddRange(ParseSingleLine(line));
            }

            return ret;
        }

        private IEnumerable<(string Material, string Warehouse, int Amount)> ParseSingleLine(string line)
        {
            const char materialWarehouseSeparator = ';';

            if (DoNotParse(line))
            {
                yield break;
            }

            var materialDescStart = line.IndexOf(materialWarehouseSeparator);
            var materialDescEnd = line.LastIndexOf(materialWarehouseSeparator);

            if (materialDescEnd == -1 || materialDescStart == -1 || materialDescStart >= materialDescEnd)
            {
                yield break;
            }

            var startPoint = materialDescStart + 1;
            var materialSymbol = line.Substring(startPoint, materialDescEnd - startPoint).Trim();

            var warehouseAmountData = line.Substring(materialDescEnd+1);
            foreach (var data in ParsewarehouseAmountData(warehouseAmountData))
            {
                yield return (Material: materialSymbol.ToUpper(), data.Warehouse, data.Amount);
            }
        }

        private IEnumerable<(string Warehouse, int Amount)> ParsewarehouseAmountData(string warehouseAmountData)
        {
            if (string.IsNullOrWhiteSpace(warehouseAmountData)) return Enumerable.Empty<(string warehouse, int Amount)>();

            const char warehouseSeparator = '|';
            const char warehouseAmountSeparator = ',';

            Func<string,int> amountParser = (amount) => Int32.TryParse(amount, out var number) ? number : 0;

            return warehouseAmountData.Split(warehouseSeparator)
                .Select(x => x.Split(warehouseAmountSeparator))
                .Where(x => x.Length == 2)
                .Select(x => (warehouse:x[0].Trim().ToUpper(), Amount:amountParser(x[1])))
                .Where(x => (x.Amount > 0 && !string.IsNullOrEmpty(x.warehouse)))
                .ToList();
        }

        private bool DoNotParse(string line)
        {
            const char comment = '#';

            return (string.IsNullOrEmpty(line) || line.StartsWith(comment));
        }

    }
}
