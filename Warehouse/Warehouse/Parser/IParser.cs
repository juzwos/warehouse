using System.Collections.Generic;

namespace Warehouse.Parser
{
    interface IParser
    {
        IList<(string Material, string Warehouse, int Amount)> Parse(ISource source);
    }
}
