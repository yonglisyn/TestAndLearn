using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TestAndLearn.Tests
{
    [TestFixture()]
    class EventAndDelegate
    {
        public delegate void MyConsolWrite(string message);
        [Test]
        public void Why_Need_Event_When_Delegate_Can_Do_What_Event_Do()
        {
            MyConsolWrite myConsolWrite = MyTest.ConsoleWrite;

            //Event version
            var test1 = new MyTest();
            test1.DummyEvent += myConsolWrite;

            test1.OnDummyEventHappened("I am event");
            //delegate version
            var test2 = new MyTest();
            test2.DummyDelegate = myConsolWrite;
            test2.OnDummyDelegateHappened("I am delegate");

            test2.DummyDelegate = null;


            TestDelegate testDelegate = ()=>test2.OnDummyDelegateHappened("I will have exception, that's why i should not be a public property/field. danger to be easily override");
            Assert.Throws<Exception>(testDelegate);
        }







        private class MyTest
        {
            //event version
            public event MyConsolWrite DummyEvent;

            //delegate version
            public MyConsolWrite DummyDelegate;

            public void OnDummyEventHappened(string message)
            {
                DummyEvent(message);
            }
            public void OnDummyDelegateHappened(string message)
            {
                DummyDelegate(message);
            }

            public static void ConsoleWrite(string message)
            {
                ConsoleWrite(message);
            }
        }
    }

    
}
