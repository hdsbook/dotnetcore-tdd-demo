using System.Collections.Generic;
using DotnetCoreTDD.DesignPatterns.TemplateMethod;
using FluentAssertions;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.TemplateMethod
{
    [TestFixture]
    public class BeverageShopTests
    {
        [Test]
        public void Coffee_Works_Correctly()
        {
            // given coffee template
            var coffeeTemplate = new BeverageShop.Coffee();

            // when make coffee
            var history = coffeeTemplate.Make();
            
            // then
            var expected = new List<string>
            {
                "把水煮沸",
                "用沸水沖泡咖啡",
                "把咖啡倒進杯子",
                "加糖和牛奶",
            };
            history.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }
        
        
        [Test]
        public void Tea_Works_Correctly()
        {
            // given coffee template
            var template = new BeverageShop.Tea();

            // when make coffee
            var history = template.Make();
            
            // then
            var expected = new List<string>
            {
                "把水煮沸",
                "用沸水浸泡茶葉",
                "把茶倒進杯子",
                "加檸檬",
            };
            history.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }
    }
}