using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualBasic.CompilerServices;
using Warehouse.Parser;
using StoreTests.ParserTestCases;

namespace StoreTests.Helpers
{
    class SourceForTests : ISource
    {
        private readonly  ITestCase _testCase;
        public SourceForTests(ITestCase testCase)
        {
            _testCase = testCase;
        }

        public IEnumerable<string> GetData()
        {
            return _testCase.Content.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }
    }
}
