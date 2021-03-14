using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.UnitTests
{
    public class LongTimeFixture : IDisposable
    {
        public LongTimeTask Task { get; }
        public LongTimeFixture()
        {
            Task = new LongTimeTask();
        }
        public void Dispose()
        {
        }
    }
}
