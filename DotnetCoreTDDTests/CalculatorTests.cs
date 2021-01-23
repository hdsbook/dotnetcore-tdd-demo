using NUnit.Framework;
using DotnetCoreTDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.Tests
{
    [TestFixture()]
    public class CalculatorTests
    {
        [Test()]
        public void AddTest()
        {
            // Arrange
            var calculator = new Calculator();
            int x = 1, y = 2;
            var expected = 3;

            // Act
            var actual = calculator.Add(x, y);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}