using System.Collections.Generic;
using DotnetCoreTDD.DesignPatterns.Flyweight;
using FluentAssertions;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.Flyweight
{
    [TestFixture]
    public class FlyweightUmlTests
    {
        [Test]
        public void Flyweight_Works_Correctly()
        {
            // given 享元工廠
            var factory = new FlyweightUml.FlyweightFactory();
            var extrinsicState = 1;

            // when 取得享元物件
            var fx = factory.GetFlyweight("X");
            var fy = factory.GetFlyweight("Y");
            var fz = factory.GetFlyweight("Z");
            
            // when 享元物件執行方法
            var resultX = fx.Operation(extrinsicState++);
            var resultY = fy.Operation(extrinsicState++);
            var resultZ = fz.Operation(extrinsicState);

            // then 確認結果正確
            resultX.Should().Contain("X1");
            resultY.Should().Contain("Y2");
            resultZ.Should().Contain("Z3");
        }
        
        [Test]
        public void Flyweight_GetBySameKey_ReturnsSameObject()
        {
            // given 享元工廠
            var factory = new FlyweightUml.FlyweightFactory();

            // when 取得同一個享元物件(X)兩次
            var fx1 = factory.GetFlyweight("X");
            var fx2 = factory.GetFlyweight("X");
            
            // then 確保兩個享元物件是同一個物件
            (fx1 == fx2).Should().Be(true);
            
            // when 再取得一個不同的享元物件(Y)
            var fy = factory.GetFlyweight("Y");
            
            // then 確保 fx 和 fy 不會是相同的物件
            (fx1 == fy).Should().Be(false);
        }
    }
}