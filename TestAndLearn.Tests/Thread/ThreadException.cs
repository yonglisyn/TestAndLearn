using NUnit.Framework;

namespace TestAndLearn.Tests.Thread
{
    [TestFixture()]
    class ThreadException
    {
        [Test]
        public void Thread_Exeption_Tryout()
        {
            var main = new ThreadTest();
            var thread = new System.Threading.Thread(main.GoGo);
            Assert.DoesNotThrow(()=>thread.Start());
        }
    }

    internal class ThreadTest
    {
        public void GoGo()
        {
            throw new System.NotImplementedException();
        }
    }
}
