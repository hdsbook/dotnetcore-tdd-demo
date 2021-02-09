using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DotnetCoreTDDTests.LINQ
{
    [TestFixture()]
    class OrderByTests
    {
        [Test()]
        public void OrderTest()
        {
            // given names
            string[] names = { "Tony", "Amy", "Natalie", "Tom", "Jenny" };

            // when 先依長度排序，再依字母序排序
            var namesOrder = names.OrderBy(str => str.Length)
                                    .ThenBy(str => str);

            // then assert
            string[] expected = { "Amy", "Tom", "Tony", "Jenny", "Natalie" };
            Assert.AreEqual(expected, namesOrder);
        }
    }
}
