using DotnetCoreTDD.DesignPatterns.Prototype;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.Prototype
{
    [TestFixture]
    public class PrototypeTests
    {
        [TestCase(100)]
        [TestCase(200)]
        [TestCase(300)]
        public void EnemyPlaneFactory_Returns_Correctly(int x)
        {
            // when 取得新敵機
            var enemyPlane = PrototypeExample.EnemyPlaneFactory.GetInstance(x);
            
            // then assert
            Assert.AreEqual(x, enemyPlane.GetX());
        }

        
        /// <summary>
        /// 測試利用 prototype 建立物件的效能比較好
        /// </summary>
        [Test]
        public void CreateInstance_WithPrototype_IsMoreEfficient()
        {
            // given 重覆次數
            int loopTime = 100;
            
            // when 以一般方式建立instance
            var beforeDT = System.DateTime.Now;
            for (int i = 0; i < loopTime; i++)
            {
                new PrototypeExample.EnemyPlane(i);
            }
            var afterDT = System.DateTime.Now;
            var tsForGeneral = afterDT.Subtract(beforeDT).TotalMilliseconds;
            
            // when 以prototype方式建立instance
            beforeDT = System.DateTime.Now;
            for (int i = 0; i < loopTime; i++)
            {
                PrototypeExample.EnemyPlaneFactory.GetInstance(i);
            }
            afterDT = System.DateTime.Now;
            var tsForPrototype = afterDT.Subtract(beforeDT).TotalMilliseconds;
            
            
            // then assert prototype 方法建立的時間比較短
            Assert.Less(tsForPrototype, tsForGeneral);
        }
    }
}