using NUnit.Framework;
using DotnetCoreTDD.DesignPatterns.Strategy.Traveler;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Traveler.Tests
{
    [TestFixture()]
    public class TravelerTests
    {
        [Test()]
        public void TravelByBusTest()
        {
            var goStrategy = new GoByBus();
            var traveler = new Traveler("小明", goStrategy);

            var result = traveler.Travel("台北");

            Assert.AreEqual("小明搭巴士去台北", result);
        }

        [Test()]
        public void TravelByTrainTest()
        {
            var goStrategy = new GoByTrain();
            var traveler = new Traveler("小明", goStrategy);

            var result = traveler.Travel("台北");

            Assert.AreEqual("小明搭火車去台北", result);
        }
    }
}