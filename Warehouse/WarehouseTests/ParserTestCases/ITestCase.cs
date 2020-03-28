namespace StoreTests.ParserTestCases
{
    public interface ITestCase
    {
        string Content { get; }
        int ExpetedItemsAmount { get; }
        int ExpetedStores { get; }
    }
}
