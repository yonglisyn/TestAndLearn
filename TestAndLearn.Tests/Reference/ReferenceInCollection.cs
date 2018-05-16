using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TestAndLearn.Tests.TestThread.Tests.TestThread.Tests.Async;

namespace TestAndLearn.Tests.ReferenceInCollection
{
    [TestFixture]
    class ReferenceInCollection
    {
        [Test]
        public void Linq_Result_Behavior_IList()
        {
            var input = new List<Dummy>
            {
                new Dummy {MyState = "A"},
                new Dummy {MyState = "B"},
                new Dummy {MyState = "C"}
            };
            //Returns the reference, not a new copy
            var tmp = input.First(x => x.MyState == "A");
            tmp.MyState = "Aa";
            Assert.AreEqual("Aa",input.First().MyState);
            //Returns the reference, not a new copy
        }

        [Test]
        public void Linq_Result_Behavior_IDictionary()
        {
            var input = new Dictionary<int,Dummy>
            {
                { 1,new Dummy {MyState = "A"}},
                {2, new Dummy {MyState = "B"}},
                {3, new Dummy {MyState = "C"}}
            };
            //Returns the reference, not a new copy
            var tmp = input.Values.First();
            tmp.MyState = "Aa";
            Assert.AreEqual("Aa",input.First().Value.MyState);
        }

        [Test]
        public void Linq_Result_Behavior_IDictionary_Add()
        {
            var input = new Dictionary<int,Dummy>
            {
                { 1,new Dummy {MyState = "A"}},
                {2, new Dummy {MyState = "B"}},
                {3, new Dummy {MyState = "C"}}
            };
            //Returns the reference, not a new copy
            Dictionary<int,Dummy> tmp = new Dictionary<int, Dummy>();
            tmp.Add(1,input.Values.First());
            tmp[1].MyState = "Aa";
            Assert.AreEqual("Aa",input.First().Value.MyState);
        }
    }
}
