using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestAndLearn.Tests.TestThread.Tests.TestThread.Tests.Async
{
    [TestFixture()]
    class AsyncInTaskRun
    {

        [Test]
        public async Task Async_Without_Await_In_TaskRun()
        {
            var dummy = new Dummy { MyState = "State Original" };
            TestContext.WriteLine($"Main thread:{Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() => new AsyncHelper().DownloadAysnc(30, dummy).ConfigureAwait(false));
            TestContext.WriteLine($"State: {dummy.MyState}");
            Thread.SpinWait(300);
            TestContext.WriteLine($"Result: {dummy.MyState}");
        }

        [Test]
        public void Async_Without_Await_In_TaskRun_Without_ConfigureAwait()
        {
            var dummy = new Dummy { MyState = "State Original" };
            TestContext.WriteLine($"Main thread:{Thread.CurrentThread.ManagedThreadId}");
            Func<Task> func = () => new AsyncHelper().DownloadAysnc(30, dummy);
            var task = Task.Run(func);
            TestContext.WriteLine($"State: {dummy.MyState}");
            task.Wait();
            TestContext.WriteLine($"Result: {dummy.MyState}");
        }


        [Test]
        public void Async_With_Await_In_TaskRun()
        {
            var dummy = new Dummy {MyState = "State Original"};
            TestContext.WriteLine($"Main thread:{Thread.CurrentThread.ManagedThreadId}");
            var task = Task.Run(async () =>await new AsyncHelper().DownloadAysnc(30, dummy).ConfigureAwait(false));
            TestContext.WriteLine($"State: {dummy.MyState}");
            task.Wait();
            TestContext.WriteLine($"Result: {dummy.MyState}");
        }
    

    }
    public class Dummy
    {
        public string MyState { get; set; }
    }

    public class AsyncHelper
    {
        public async Task DownloadAysnc(int millisecondsDelay, Dummy dummy)
        {
            TestContext.WriteLine($"Before download thread:{Thread.CurrentThread.ManagedThreadId}");
            TestContext.WriteLine("DownloadAysnc starting...");
            await Task.Delay(millisecondsDelay).ConfigureAwait(false);
            dummy.MyState = "State Changed";
            TestContext.WriteLine($"After download thread:{Thread.CurrentThread.ManagedThreadId}");
            TestContext.WriteLine("DownloadAysnc ending...");
        }
    }
}
