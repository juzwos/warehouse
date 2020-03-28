using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Warehouse.Reports;
using Warehouse.Storage;
using SingleWarehouse = Warehouse.Data.Warehouse;

namespace WarehouseTests
{
    public class WarehousesReportTests
    {
        
        [Test]
        public void When_DataAreInWarehouse_Then_ShouldReportShouldHaveProperForm()
        {
            const string expected = @"B (53)
CM1: 50
M2: 2
M3: 1

A (13)
AM1: 10
M2: 2
M3: 1

B (8)
BM1: 5
M2: 2
M3: 1";

            var storage = Mock.Of<IStorage>(x => x.Get() == GetStorage());

            var report = new WarehousesReport(storage);
            var data = report.GetData();

            data.Should().NotBeNullOrWhiteSpace();
            data.Should().Be(expected);
        }

        [Test]
        public void When_WarehouseIsEmpty_Then_ShouldReportShouldBeEmpty()
        {
            var storage = Mock.Of<IStorage>(x => x.Get() == new LinkedList<SingleWarehouse>());

            var report = new WarehousesReport(storage);
            var data = report.GetData();

            data.Should().BeEmpty();
        }


        private IReadOnlyCollection<SingleWarehouse> GetStorage()
        {
            var firstWh = new SingleWarehouse("A");
            var secondWh = new SingleWarehouse("B");
            var thirdWh = new SingleWarehouse("B");

            firstWh.AddMaterials(new List<(string Material, string Warehouse, int Amount)>
            {
                ("AM1","",10),
                ("M2","",2),
                ("M3","",1)
            });

            secondWh.AddMaterials(new List<(string Material, string Warehouse, int Amount)>
            {
                ("BM1","",5),
                ("M2","",2),
                ("M3","",1)
            });

            thirdWh.AddMaterials(new List<(string Material, string Warehouse, int Amount)>
            {
                ("CM1","",50),
                ("M2","",2),
                ("M3","",1)
            });

            var warehouses = new List<SingleWarehouse>{firstWh, secondWh, thirdWh};

            return warehouses;
        }

    }
}
