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
        public void Linq_Result_After_Add_Behavior()
        {
            var input = new List<Dummy>();
            var tmp = new Dummy {MyState = "A"};
            //After add, change source still affect reference
            input.Add(tmp);
            tmp.MyState = "Aa";
            Assert.AreEqual("Aa",input.First().MyState);
            //Returns the reference, not a new copy
        }
        [Test]
        public void Linq_Result_After_Select_Behavior()
        {
            var input = new List<Dummy>
            {
                new Dummy {MyState = "A"},
                new Dummy {MyState = "B"},
                new Dummy {MyState = "C"}
            };
            //Returns the reference, not a new copy
            var tmp = input.Select(x => x);
            input.First().MyState = "Aa";
            Assert.AreEqual(tmp.First().MyState, input.First().MyState);
            //Returns the reference, not a new copy
        }
        [Test]
        public void Linq_Result_After_AddRange_Behavior()
        {
            //AddRange is adding each element one by one by reference.
            // the change of the range reference(e.g. adding one more element) will not affect after AddRange
            //however, the change of the reference of the each element, will affter after AddRange.



            var input = new List<Dummy>
            {
                new Dummy {MyState = "A"},
                new Dummy {MyState = "B"},
                new Dummy {MyState = "C"}
            };
            //Returns the reference, not a new copy
            var tmp = new List<Dummy>();
            tmp.AddRange(input);
            input.First().MyState = "Aa";
            input.Add(new Dummy {MyState = "D"});
            Assert.AreEqual(tmp.First().MyState, input.First().MyState);
            Assert.IsTrue(tmp.Count< input.Count);
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
