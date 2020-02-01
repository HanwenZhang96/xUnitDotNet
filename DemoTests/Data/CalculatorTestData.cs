using System;
using System.Collections.Generic;
using System.Text;

namespace DemoTests
{
    public class CalculatorTestData
    {
        private static readonly List<object[]> Data = new List<object[]>
        {
            new object[]{1, 2, 3},
            new object[]{1, 3, 4},
            new object[]{2, 4, 6}
        };

        public static IEnumerable<object[]> TastData => Data;
    }
}
