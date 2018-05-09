using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace TestAndLearn.Tests.TestThread.Tests.TestThread.Tests.TPL
{
    [TestFixture()]
    class ParalleForUsage
    {
        private static List<int> resource = Enumerable.Range(0, 160).ToList();
        [Test]
        public void DownloadParalle()
        {
            var result = new List<string>();
            Parallel.For(0, 8, (x,loopstate) =>
            {
                var start = x * 50;
                var end = DownloadFrom(start);
                if (end >= start)
                {
                    var tmpResult = $"i am the source start {start} to end {end}";
                    result.Add(tmpResult);
                }
                else
                {
                    var tmpResult = $"i am stopped on {x}";
                    result.Add(tmpResult);
                    loopstate.Stop();
                }
            });

            TestContext.WriteLine(JsonConvert.SerializeObject(result,Formatting.Indented));
        }

        private int DownloadFrom(int number)
        {
            return Math.Min(number + 49, resource.Max());
        }
    }
}
