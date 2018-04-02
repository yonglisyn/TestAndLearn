using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestAndLearn.Tests
{
    [TestFixture()]
    class ObservableBasicTests
    {
        public event Action Activation;

        [Test]
        public async void What_Is_The_Behavior_Of_Observable_FromEvent()
        {
            //Arrange
            var testTarget = new MyTest();
            //testTarget.TestStarted += HandleTestStarted;
            //testTarget.OnTestStart();

            var observableTarget =
                Observable.FromEventPattern(h => testTarget.TestStarted += h, h => testTarget.TestStarted -= h);
            IObserver<EventPattern<object>> testObserver = new TestObserver(HandleTestStarted);
            //observableTarget.Subscribe(testObserver);

            var myTask = observableTarget.Timeout(TimeSpan.FromSeconds(1)).ToTask();
            await myTask;
            testTarget.OnTestStart();

        }

        public static event EventHandler SimpleEvent;

        [Test]
        public async Task What_Is_The_Behavior_Of_Observable_FromEvent_2()
        {
            TestContext.WriteLine("Setup observable");
            // To consume SimpleEvent as an IObservable:
            var eventAsObservable = Observable.FromEventPattern(
                ev => SimpleEvent += ev,
                ev => SimpleEvent -= ev);

            // SimpleEvent is null until we subscribe
            TestContext.WriteLine(SimpleEvent == null ? "SimpleEvent == null" : "SimpleEvent != null");
            //to task
            var myTask = eventAsObservable.Timeout(TimeSpan.FromSeconds(5), Observable.Return<object>(null))
                .ToTask();

            await myTask;
            if (myTask.Result == null)
                TestContext.WriteLine("time out return null");
            TestContext.WriteLine(myTask.Result);
            return;

            TestContext.WriteLine("Subscribe");
            //Create two event subscribers
            var s = eventAsObservable.Subscribe(args => TestContext.WriteLine("Received event for s subscriber"));
            var t = eventAsObservable.Subscribe(args => TestContext.WriteLine("Received event for t subscriber"));

            // After subscribing the event handler has been added
            TestContext.WriteLine(SimpleEvent == null ? "SimpleEvent == null" : "SimpleEvent != null");

            TestContext.WriteLine("Raise event");
            if (null != SimpleEvent)
            {
                SimpleEvent(null, EventArgs.Empty);
            }

            // Allow some time before unsubscribing or event may not happen
            System.Threading.Thread.Sleep(100);

            TestContext.WriteLine("Unsubscribe");
            s.Dispose();
            t.Dispose();

            // After unsubscribing the event handler has been removed
            TestContext.WriteLine(SimpleEvent == null ? "SimpleEvent == null" : "SimpleEvent != null");

        }

        private void HandleTestStarted(object sender, object e)
        {
            TestContext.WriteLine(
                $"event {nameof(MyTest.TestStarted)} happened and {nameof(this.HandleTestStarted)} is handling it!");
        }

        public class TestObserver : IObserver<EventPattern<object>>
        {
            private readonly EventHandler<object> _handleTestStarted;

            public TestObserver(EventHandler<object> handleTestStarted)
            {
                _handleTestStarted = handleTestStarted;
            }

            public void OnNext(EventPattern<object> value)
            {
                _handleTestStarted(null, null);
            }

            public void OnError(Exception error)
            {
                _handleTestStarted(null, null);

            }

            public void OnCompleted()
            {
                _handleTestStarted(null, null);
            }
        }

        private void DoNothing(Exception ex)
        {
        }

        private void HandleTestStarted(object sender, EventArgs e)
        {
            TestContext.WriteLine(
                $"event {nameof(MyTest.TestStarted)} happened and {nameof(this.HandleTestStarted)} is handling it!");
        }

        private class MyTest
        {
            public event EventHandler TestStarted;

            public void OnTestStart()
            {
                if (TestStarted != null)
                    TestStarted(null, null);
            }
        }
    }

}
