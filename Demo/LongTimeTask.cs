using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Demo
{
    public class LongTimeTask
    {
        public LongTimeTask()
        {
            Thread.Sleep(2000);
        }
    }
}
