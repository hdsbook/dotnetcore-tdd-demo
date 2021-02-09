using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DotnetCoreTDDTests.LINQ
{
    /// <summary>
    /// 直積測試
    /// </summary>
    [TestFixture()]
    class CartesianProductTests
    {
        [Test()]
        public void CartesianProductTest_V1()
        {
            // given charSet and numSet
            char[] charSet = { 'X', 'Y', 'Z' };
            int[] numSet = { 1, 2, 3 };

            // when 取得直積
            var cartesianProduct = (from Letter in charSet
                                    from Number in numSet
                                    select $"{Letter}{Number}");

            // then assert
            string[] expected = { "X1", "X2", "X3", "Y1", "Y2", "Y3", "Z1", "Z2", "Z3" };
            Assert.AreEqual(expected, cartesianProduct);
        }

        [Test()]
        public void CartesianProductTest_V2()
        {
            // given charSet and numSet
            char[] charSet = { 'X', 'Y', 'Z' };
            int[] numSet = { 1, 2, 3 };

            // when 取得直積 (用 SelectMany)
            var cartesianProduct = charSet.SelectMany(x => numSet.Select(y => $"{x}{y}"));

            // then assert
            string[] expected = { "X1", "X2", "X3", "Y1", "Y2", "Y3", "Z1", "Z2", "Z3" };
            Assert.AreEqual(expected, cartesianProduct);
        }

        [Test()]
        public void ThreeSetProductTest_V1()
        {
            // given three sets
            char[] charSet = { 'X', 'Y' };
            int[] numSet = { 1, 2 };
            string[] colorSet = { "Green", "Red" };

            // when get product
            var product = (from Letter in charSet
                           from Number in numSet
                           from Color in colorSet
                           select $"{Letter}{Number}{Color}");

            // then assert
            string[] expected = { "X1Green", "X1Red", "X2Green", "X2Red", "Y1Green", "Y1Red", "Y2Green", "Y2Red" };
            Assert.AreEqual(expected, product);
        }

        [Test()]
        public void ThreeSetProductTest_V2()
        {
            // given three sets
            char[] charSet = { 'X', 'Y' };
            int[] numSet = { 1, 2 };
            string[] colorSet = { "Green", "Red" };

            // when get product (use SelectMany)
            var set12Product = charSet.SelectMany(Letter => numSet.Select(Number => $"{Letter}{Number}"));
            var product = set12Product.SelectMany(set1and2 => colorSet.Select(color => $"{set1and2}{color}"));

            // then assert
            string[] expected = { "X1Green", "X1Red", "X2Green", "X2Red", "Y1Green", "Y1Red", "Y2Green", "Y2Red" };
            Assert.AreEqual(expected, product);
        }
    }
}
