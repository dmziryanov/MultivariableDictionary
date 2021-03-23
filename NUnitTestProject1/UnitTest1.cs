using ConsoleApp2;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace NUnitTestProject1
{
    public class Tests
    {
        MultivariableDictionary<string, string> mv = new MultivariableDictionary<string, string>();

        [SetUp]
        public void Setup()
        {
            mv.Add("a", "b");
            mv.Add("a", "c");
            mv.Add("a", "c");
        }

        [Test]
        public void TestQuantity()
        {
            Assert.AreEqual(2,  mv.Count());
        }

        [Test]
        public void SequenceEqual()
        {
            List<string> l = new List<string>() { "b", "c" };
            Assert.IsTrue(mv.ToList().SequenceEqual<string>(l));
        }
    }
}