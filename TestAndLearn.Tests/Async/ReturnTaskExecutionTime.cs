using System.Threading.Tasks;
using NUnit.Framework;

namespace TestAndLearn.Tests.Async
{
    [TestFixture()]
    class ReturnTaskExecutionTime
    {
        [Test]
        public void Method_Return_Task_Meaning()
        {
            Task<string> result = ReturnTask("I am executed!");
            result.Start();
            TestContext.WriteLine(result.Result);
        }

        [Test]
        public void Method_Return_Task_Meaning_With_Task_FromResult()
        {
            Task<string> result = ReturnTaskWithFromResult("I am executed!");
            TestContext.WriteLine(result.Result);
        }

        private Task<TResult> ReturnTask<TResult>(TResult input)
        {
            TestContext.WriteLine("I am here");
            var task = new Task<TResult>(()=>
            {
                TestContext.WriteLine("I am here inside");
                return input;
            });
            return task;
        }
        private Task<TResult> ReturnTaskWithFromResult<TResult>(TResult input)
        {
            TestContext.WriteLine("I am here");
            var task = Task.FromResult(input);
            return task;
        }
    }
}
