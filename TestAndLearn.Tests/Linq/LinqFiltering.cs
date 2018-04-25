using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TestAndLearn.Tests.Linq
{
    [TestFixture()]
    class LinqFiltering
    {
        [Test]
        public void Should_Return_Filtered_Result()
        {
            var source = new List<string>();
            Enumerable.Range(0, 3).ToList().ForEach(x=>source.Add("abc"+x));
            var filteredsource = from result in source
                where result.EndsWith("2")
                select result;
            Assert.AreEqual(1,filteredsource.Count());
        }
    }
}
