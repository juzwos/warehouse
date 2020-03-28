using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Warehouse.Parser;
using Warehouse.Repository;
using StoreTests.Helpers;
using StoreTests.ParserTestCases;

namespace StoreTests
{
    public class Tests
    {
        private readonly Parser _parser = new Parser();
        
        [Test]
        public void When_FileHasProperFormat_Then_AllLineAreParsed()
        {
            var sut = GetSut("ProperFile");
            var data = _parser.Parse(new SourceForTests(sut));

            data.Count.Should().Be(sut.ExpetedItemsAmount);
            data.Select(x=>x.Warehouse).Distinct().Count().Should().Be(sut.ExpetedStores);

            var inm = new InMemory();
            inm.Add(data);
        }

        [Test]
        public void When_FileIsRandom_Then_LineAreNotParsed()
        {
            var sut = GetSut("LoremIpsum");
            var data = _parser.Parse(new SourceForTests(sut));

            data.Count.Should().Be(sut.ExpetedItemsAmount);
            data.Select(x => x.Warehouse).Distinct().Count().Should().Be(sut.ExpetedStores);
        }

        [Test]
        public void When_StoreIsMissing_Then_RecordIsNotAdded()
        {
            var sut = GetSut("MissingStore");
            var data = _parser.Parse(new SourceForTests(sut));

            data.Count.Should().Be(sut.ExpetedItemsAmount);
            data.Select(x => x.Warehouse).Distinct().Count().Should().Be(sut.ExpetedStores);
        }

        [Test]
        public void When_AmountIsZero_Then_RecordIsNotAdded()
        {
            var sut = GetSut("ZeroAmount");
            var data = _parser.Parse(new SourceForTests(sut));

            data.Count.Should().Be(sut.ExpetedItemsAmount);
            data.Select(x => x.Warehouse).Distinct().Count().Should().Be(sut.ExpetedStores);
        }

        private static ITestCase GetSut(string caseName)
        {
            var t = Type.GetType($"StoreTests.ParserTestCases.{caseName}");
            return Activator.CreateInstance(t) as ITestCase;
        }
    }
}