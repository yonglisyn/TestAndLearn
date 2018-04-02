using NUnit.Framework;

namespace TestAndLearn.Tests.OOP
{
    [TestFixture()]
    class Singleton
    {
        [Test]
        public void Singleton_Should_Be_Initialzed_Once()
        {
            var a=MySingleton.Singleton;
            var b=MySingleton.Singleton;
            Assert.AreEqual(1,b.Count);
        }
    }

    internal class MySingleton
    {
        private int _count;
        public int Count
        {
            get { return _count; }
        }
        public static MySingleton Singleton= new MySingleton();

        private MySingleton()
        {
            _count++;
        }

    }
}
