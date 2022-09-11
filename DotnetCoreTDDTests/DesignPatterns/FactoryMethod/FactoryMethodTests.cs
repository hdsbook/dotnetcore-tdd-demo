using DotnetCoreTDD.DesignPatterns.FactoryMethod;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.FactoryMethod
{
    [TestFixture]
    public class FactoryMethodTests
    {
        /// <summary>
        /// 此為簡單工廠的使用方式
        /// </summary>
        [Test]
        public void SimpleFactory_Works_Correctly()
        {
            // given factory
            var screenWidth = 100;
            var factory = new SimpleEnemyFactory(screenWidth);
            
            // when create enemies
            var airplane = factory.Create("Airplane");
            var tank = factory.Create("Tank");
            
            // then assert
            StringAssert.Contains("飛機", airplane.Show());
            StringAssert.Contains("坦克", tank.Show());
        }

        /// <summary>
        /// 此為工廠方法的使用方式，有以下好處
        /// 1. 新增新敵人類別時，只需新增新的敵人類別和新的工廠類別，無需對原本的工廠類別做任何改動
        /// 2. 各工廠專注於生產各自的產品，不會有一個工廠負責多個不同產品的生產
        /// </summary>
        [Test]
        public void FactoryMethod_Works_Correctly()
        {
            // given factories
            var screenWidth = 100;
            var airplaneFactory = new AirplaneEnemyFactory(screenWidth);
            var tankFactory = new TankEnemyFactory(screenWidth);
            
            // when create enemies
            var airplane = airplaneFactory.Create();
            var tank = tankFactory.Create();
            
            // then assert
            StringAssert.Contains("飛機", airplane.Show());
            StringAssert.Contains("坦克", tank.Show());
        }
    }
}