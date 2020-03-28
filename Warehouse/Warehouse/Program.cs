using System;
using Warehouse.Parser;
using Warehouse.Reports;
using Warehouse.Repository;

namespace Warehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser.Parser();
            var source = new FileSource(args[0]);

            var data = parser.Parse(source);

            var storage = new Storage.Storage(new InMemory());
            storage.Add(data);

            var report = new WarehousesReport(storage);

            Console.WriteLine(report.GetData());
        }
    }
}
