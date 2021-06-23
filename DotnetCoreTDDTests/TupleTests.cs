using System;
using NUnit.Framework;

namespace DotnetCoreTDDTests
{
    [TestFixture]
    class TupleTests
    {
        [Test]
        public void TupleTest()
        {
            var emp = GetEmpInfo();

            Assert.AreEqual("王大同", emp.Item1);
            Assert.AreEqual(50, emp.Item2);
        }


        public Tuple<string, int> GetEmpInfo()
        {
            return new Tuple<string, int>("王大同", 50);
        }
    }
}
