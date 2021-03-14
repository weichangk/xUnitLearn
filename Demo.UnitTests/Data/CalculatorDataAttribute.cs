using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Demo.UnitTests
{
    public class CalculatorDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 0, 100, 100 };
            yield return new object[] { 1, 99, 100 };
            yield return new object[] { 2, 98, 100 };
            yield return new object[] { 3, 97, 100 };
        }
    }
}
