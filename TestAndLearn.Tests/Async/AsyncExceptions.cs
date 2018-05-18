using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestAndLearn.Tests.Async
{
    [TestFixture()]
    class AsyncExceptions
    {
        [Test]
        public async Task Aysnc_Exceptions()
        {
            var nums= new List<int>();
            try
            {
                foreach (var num in Enumerable.Range(0,5))
                {
                    nums.Add(await MyAsync(num));
                }
            }
            catch (ArgumentException e)
            {
                TestContext.WriteLine(e.Message);
            }

            nums.ForEach(TestContext.WriteLine);
        }

        private async Task<int> MyAsync(int num)
        {
            if (num == 3)
            {
                throw new ArgumentException("yo");
            }
            await Task.Delay(100);
            return num;
        }
    }
}
