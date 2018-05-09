using System.Collections.Generic;
using NUnit.Framework;

namespace TestAndLearn.Tests.TestThread.Tests.TestThread.Tests.Linq
{
    [TestFixture()]
    class IEumerableBehavior
    {
        private static int _Count = 0;
        [Test]
        public void How_Generate_Enumerable_Being_Excecuted()
        {
            var restul = GetMyResponse();
            var tmp = restul.MyEnumerable;
            foreach (var d in tmp)
            {
                
            }
            foreach (var d in tmp)
            {

            }
        }

        private MyResponse GetMyResponse()
        {
            return new MyResponse
            {
                MyEnumerable = GenerateEnumerable()
            };
        }

        private IEnumerable<string> GenerateEnumerable()
        {
            TestContext.WriteLine($"I am executed {_Count++}");
            return new List<string> {"a"};
        }
    }

    internal class MyResponse
    {
        public IEnumerable<string> MyEnumerable { get; set; }
    }
}
