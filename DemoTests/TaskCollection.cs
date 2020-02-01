using Demo;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DemoTests
{
    [CollectionDefinition("Long Time Task Collection")]
    public class TaskCollection:ICollectionFixture<LongTimeTaskFixture>
    {

    }
}
