using NUnit.Framework;
using NUnit.Framework.Internal;
using TestAndLearn.Tests.TestThread.Tests.TestThread.Tests.Async;

namespace TestAndLearn.Tests.Reference
{
    [TestFixture()]
    class ReferenceOfReadOnly
    {

        [Test]
        public void ReadOnly_Reference_Can_Only_Init_In_Constructor_But_Manipulate_Anywhere()
        {
            var input = new MyClass(new Dummy {MyState = "A"});
            input.SetDummyState("Aa");
            Assert.AreEqual("Aa",input.Dummy.MyState);
        }

        [Test]
        public void ReadOnly_Reference_Can_Only_Init_In_Constructor_But_Manipulate_Anywhere2()
        {
            var input = new MyClass(new Dummy {MyState = "A"});
            var tmp = input.NewMyChildClass();
            tmp.Dummy = new Dummy {MyState = "Aa"};
            Assert.AreEqual("A", input.Dummy.MyState);
        }

        private class MyClass
        {
            //can only the assigned/initialized in constructor
            //BUT can be manipulated anywhere see SetDummyState
            private readonly Dummy _dummy;

            public Dummy Dummy => _dummy;

            public MyClass(Dummy dummy)
            {
                _dummy = dummy;
            }

            public void SetDummyState(string state)
            {
                _dummy.MyState = state;
            }

            public MyChildClass NewMyChildClass()
            {
                return new MyChildClass(_dummy);
            }
        }
    }

    internal class MyChildClass
    {
        public Dummy Dummy { get; set; }

        public MyChildClass(Dummy dummy)
        {
            Dummy = dummy;
        }
    }
}
