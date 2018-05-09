using System;
using NUnit.Framework;

namespace TestAndLearn.Tests.TestThread.Tests.TestThread.Tests
{
    [TestFixture()]
    ///summary
    ///Delegate as public varialbe(property/filed) is not protected and can be easily override by clients
    /// Event provide a protect layer for delegate and limit clients operations. 
    ///summary
    public class EventAndDelegateTest
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
            //Event version with field
            var test1_1 = new MyTest();
            test1_1.DummyEventProperty += myConsolWrite;

            test1_1.OnDummyEventHappened("I am event");
            //delegate version
            var test2 = new MyTest();
            test2.DummyDelegate = myConsolWrite;
            test2.OnDummyDelegateHappened("I am delegate");

            test2.DummyDelegate = null;


            TestDelegate testDelegate = ()=>test2.OnDummyDelegateHappened("I will have exception, that's why i should not be a public property/field. danger to be easily override");
            Assert.Throws<NullReferenceException>(testDelegate);
        }







        private class MyTest
        {
            //event version
            public event MyConsolWrite DummyEvent;

            //event version with field
            public event MyConsolWrite DummyEventProperty
            {
                add { _eventHandler += value; }
                remove { _eventHandler -= value; }
            }
            private MyConsolWrite _eventHandler;

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
                TestContext.WriteLine(message);
            }
        }
    }

    
}
