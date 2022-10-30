using DotnetCoreTDD.DesignPatterns.Decorator;
using FluentAssertions;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.Decorator
{
    [TestFixture]
    public class DecoratorUmlTests
    {
        /// <summary>
        /// 未經裝飾前的行為如下
        /// </summary>
        [Test]
        public void Operation_Undecorated_ReturnsCorrectly()
        {
            // given component
            var component = new DecoratorUml.ConcreteComponent();

            // when do operation
            var result = component.Operation();
            
            // then
            result.Should().Be("做某事");
        }
        
        /// <summary>
        /// 經裝飾器裝飾後的行為如下
        /// </summary>
        [Test]
        public void Operation_Decorated_ReturnsCorrectly()
        {
            // given decorated component
            var component = new DecoratorUml.ConcreteComponent();
            var decoratedComponent = new DecoratorUml.ConcreteDecorator(component);

            // when do operation
            var result = decoratedComponent.Operation();
            
            // then
            result.Should().Be("新增前置動作、做某事、新增後置動作");
        }
    }
}