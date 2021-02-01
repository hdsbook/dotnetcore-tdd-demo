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
        public void StrategyTest()
        {
            // given
            var goby = "bus";
            IGotStrategy goStrategy = null;
            switch (goby)
            {
                case "bus":
                    goStrategy = new GoByBus();
                    break;
                case "train":
                default:
                    goStrategy = new GoByTrain();
                    break;
            }
            var traveler = new Traveler("小明", goStrategy);

            // when
            var result = traveler.Travel("台北");

            // then
            Assert.AreEqual("小明搭巴士去台北", result);
        }

        public void WithoutStrategyTest()
        {
            // given
            var goby = "bus";
            var traveler = new RawTraveler("小明");

            // when
            var result = traveler.Travel("台北", goby);

            // then
            Assert.AreEqual("小明搭巴士去台北", result);
        }
    }
}