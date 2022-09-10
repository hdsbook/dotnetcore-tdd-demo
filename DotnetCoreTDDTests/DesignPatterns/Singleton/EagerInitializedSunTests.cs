using System.Threading;
using DotnetCoreTDD.DesignPatterns.Singleton;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.Singleton
{
    [TestFixture]
    public class EagerInitializedSunTests
    {
        [Test]
        public void GetInstance_Twice_InstancesAreTheSame()
        {
            // when 呼叫兩次取得太陽
            var sunA = EagerInitializedSun.GetInstance();
            var sunB = EagerInitializedSun.GetInstance();

            // then assert 兩顆太陽是同一顆太陽
            Assert.AreEqual(sunA, sunB);
        }
        
        [Test]
        public void GetInstance_ByThread_InstancesAreTheSame()
        {
            // given 太陽紀錄變數
            EagerInitializedSun lastSun = null;

            // when 以執行緒呼叫多次取得太陽
            for (var i = 0; i < 50; i++)
            {
                new Thread(() =>
                {
                    var currentSun = EagerInitializedSun.GetInstance();
                    if (lastSun != null)
                    {
                        // then 確保每次取得的太陽都和上一次取得的太陽是同一顆太陽
                        Assert.AreSame(lastSun, currentSun);
                    }
                    lastSun = currentSun;
                }).Start();
            }
        }
        
    }
}