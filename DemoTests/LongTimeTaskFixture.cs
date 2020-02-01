using Demo;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoTests
{
    public class LongTimeTaskFixture : IDisposable
    {
        public LongTimeTask Task { get;private set; }
        public LongTimeTaskFixture()
        {
            Task = new LongTimeTask();
        }
        public void Dispose()
        {
        }
    }
}
