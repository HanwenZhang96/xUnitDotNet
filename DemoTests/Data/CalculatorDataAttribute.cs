using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace DemoTests.Data
{
    public class CalculatorDataAttribute:DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 0, 100, 100 };
            yield return new object[] { 1, 99, 100 };
            yield return new object[] { 50, 50, 100 };
        }
    }
}
