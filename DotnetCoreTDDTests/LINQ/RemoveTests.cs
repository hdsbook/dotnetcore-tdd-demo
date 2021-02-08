using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DotnetCoreTDDTests.LINQ
{
    [TestFixture()]
    class RemoveTests
    {
        private List<string> _listOfString;

        [SetUp()]
        public void Init()
        {
            _listOfString = new List<string> { "r", "e", "m", "o", "v", "e" };
        }

        private string _ToStr(List<string> list)
        {
            return string.Join("", list);
        }

        [Test()]
        public void RemoveTest()
        {
            var target = _listOfString.FirstOrDefault(x => x == "e");
            _listOfString.Remove(target);
            Assert.AreEqual("rmove", _ToStr(_listOfString));

            _listOfString.Remove(_listOfString.FirstOrDefault(x => x == "e"));
            Assert.AreEqual("rmov", _ToStr(_listOfString));
        }

        [Test()]
        public void RemoveAllTest()
        {
            _listOfString.RemoveAll(x => x == "e");
            Assert.AreEqual("rmov", _ToStr(_listOfString));
        }

        [Test()]
        public void RemoveAtTest()
        {
            _listOfString.RemoveAt(3);
            Assert.AreEqual("remve", _ToStr(_listOfString));
        }

        [Test()]
        public void RemoveRangeTest()
        {
            _listOfString.RemoveRange(3, 2);
            Assert.AreEqual("reme", _ToStr(_listOfString));
        }
    }
}
