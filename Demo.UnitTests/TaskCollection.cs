using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.UnitTests
{
    [CollectionDefinition("Lone Time Task Collection")]
    public class TaskCollection : ICollectionFixture<LongTimeFixture>
    {
    }
}
