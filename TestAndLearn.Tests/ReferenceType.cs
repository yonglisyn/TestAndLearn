using System;
using FluentAssert;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAndLearn.Tests
{
    [TestClass]
    public class ReferenceType
    {
        [TestMethod]
        public void ReferenceType_Assign_To_Local_Variable()
        {
            //Arrange
            var testRef = new Test("yongli","shan",18,null);
            //Act
            var tmp = testRef;
            tmp.Age = 28;

            //Assert
            tmp.ShouldBeEqualTo(testRef);
            Assert.AreEqual(testRef.Age,28);
        }

        [TestMethod]
        public void Nested_ReferenceType_Assign_To_Local_Variable()
        {
            //Arrange
            Test childTest = new Test("fn1","sn1",1,null);
            var testRef = new Test("yongli","shan",18, childTest);
            //Act
            var tmp = testRef;
            tmp.Age = 28;

            //Assert
            tmp.ShouldBeEqualTo(testRef);
            Assert.AreEqual(testRef.Age,28);
        }

        private class Test
        {
            public string FirstName { get; }
            public string Surname { get; }
            public int Age { get; set; }
            public Test Child { get; }

            public Test(string firstName, string surname, int age, Test child)
            {
                FirstName = firstName;
                Surname = surname;
                Age = age;
                Child = child;
            }
        }
    }

   
}
