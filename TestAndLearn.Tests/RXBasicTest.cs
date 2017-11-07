//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Reactive.Linq;
//using System.Reactive.Threading.Tasks;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace TestAndLearn.Tests
//{
//    [TestClass]
//    class RXBasicTest
//    {
//        /// <summary>
//        ///  Observable.Return<T>(T value). This method takes a value of T and returns an IObservable<T> with the single value and then completes
//        /// </summary>
//        [TestMethod]
//        public void Observalbe_Return()
//        {
//        }

//        public async Task Observable_TimeOut()
//        {
//            async Task<IDictionary<string, decimal?>>
//            var results = new Dictionary<string, decimal?>();
//            var timer = new Stopwatch();
//            timer.Start();
//            .Delay(new TimeSpan(0, 0, 2))
//            var range = Observable.Range(0, 10000000);

//            var result = await TestDummy(range);
//            Subscribe(x =>
//        {
//            TestContext.WriteLine("seconds:" + timer.ElapsedMilliseconds / 1000);
//            TestContext.WriteLine(x);
//        });
//            await target
//                .Where(t => t > 11)
//                .Take(1)
//                .Timeout(TimeSpan.FromSeconds(10), Observable.Return(1))
//                .ToTask(cancellationToken).ConfigureAwait(false);
//            timer.Stop();
//            TestContext.WriteLine("seconds total:" + timer.ElapsedMilliseconds / 1000);
//            TestContext.WriteLine(result);

//            return results;
//            Assert.IsTrue(true);

//        }

//        private async Task<int> TestDummy(IObservable<int> range)
//        {
//            await range.Where(x => x > 10).Take(1).Timeout(new TimeSpan(1), Observable.Return(11)).ToTask();
//            TestContext.WriteLine("here");
//            return 12;
//        }
//    }
//}
