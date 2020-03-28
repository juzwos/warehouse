using System.Collections.Generic;

namespace Warehouse.Parser
{
    public interface ISource
    {
        IEnumerable<string> GetData();
    }
}
