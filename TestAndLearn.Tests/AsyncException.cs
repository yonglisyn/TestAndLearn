using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestAndLearn.Tests
{
    [TestFixture]
    public class AsyncException
    {
        [Test]
        public async Task AsyncMethod_Exception()
        {
            TaskScheduler.UnobservedTaskException += (object sender, UnobservedTaskExceptionEventArgs eventArgs) =>
            {
                eventArgs.SetObserved();
                ((AggregateException)eventArgs.Exception).Handle(ex =>
                {
                    Console.WriteLine("Exception type: {0}", ex.GetType());
                    return true;
                });
            }; TestContext.WriteLine("start");
            try
            {
                Wrap();
                //var func = await GetAsyncWithException();

                //TestContext.WriteLine(func);

            }
            catch (AggregateException ex)
            {
                var ex2 = ex.Flatten();
                TestContext.WriteLine("AggregateException");
                TestContext.WriteLine(ex2);

                throw ex2;
            }
            catch (Exception e)
            {
                TestContext.WriteLine("Non AggregateException");
                TestContext.WriteLine(e);

                throw e;
            }

          Assert.IsTrue(true);

        }

        private async Task Wrap()
        {
            await GetAsyncWithException();
        }

        public Task OnUIThreadAsync(Action action)
        {
            return Task.Factory.StartNew(action);
        }

        private async Task<int> GetAsyncWithException()
        {
            await Task.Delay(1000);
            throw new Exception("test GetAsyncWithException");
            return 1;
        }
    }
}
