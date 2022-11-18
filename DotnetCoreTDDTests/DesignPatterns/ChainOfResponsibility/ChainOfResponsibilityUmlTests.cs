using DotnetCoreTDD.DesignPatterns.ChainOfResponsibility;
using FluentAssertions;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.ChainOfResponsibility
{
    [TestFixture]
    public class ChainOfResponsibilityUmlTests
    {
        [Test]
        public void GivenHandlers_WhenSetSequenceAsABC_WorksCorrectly()
        {
            // given handlers
            var handlerA = new ChainOfResponsibilityUml.RealHandlerA();
            var handlerB = new ChainOfResponsibilityUml.RealHandlerB();
            var handlerC = new ChainOfResponsibilityUml.RealHandlerC();
            handlerA.SetNext(handlerB).SetNext(handlerC);
            
            // when request with A, then 預期流程將在 handlerA 進行處理
            var resultA = handlerA.Handle("A");
            resultA.Should().Be("ok on A");
            
            // when request with B, then 預期流程將在 handlerB 進行處理
            var resultB = handlerB.Handle("B");
            resultB.Should().Be("ok on B");
            
            // when request with C, then 預期流程將在 handlerC 進行處理
            var resultC = handlerC.Handle("C");
            resultC.Should().Be("ok on C");
        }
    }
}