using System;
using System.Collections.Generic;
using DotnetCoreTDD.DesignPatterns.Decorator;
using DotnetCoreTDD.DesignPatterns.Mediator;
using FluentAssertions;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.Mediator
{
    [TestFixture]
    public class MediatorTests
    {
        [Test]
        public void GivenMediator_WhenRegisterComponents_WorksCorrectly()
        {
            var today = DateTime.Now.ToString("yyyy/MM/dd");

            // given mediator and components
            var mediator = new MediatorUml.ConcreteMediator();
            var componentA = new MediatorUml.ConcreteComponentA();
            var componentB = new MediatorUml.ConcreteComponentB();

            // when register components
            mediator.Register(componentA);
            mediator.Register(componentB);

            // when components send messages
            componentA.SendMessage("來自A的訊息");
            componentB.SendMessage("來自B的訊息");

            // then 驗證各components 收到的訊息正確
            var receivedMessagesOfA = componentA.GetReceivedMessages();
            receivedMessagesOfA.Should().BeEquivalentTo(new List<string>
            {
                "來自A的訊息",
                "[From B]來自B的訊息"
            });

            var receivedMessagesOfB = componentB.GetReceivedMessages();
            receivedMessagesOfB.Should().BeEquivalentTo(new List<string>
            {
                today + ":" + "來自A的訊息",
                today + ":" + "[From B]來自B的訊息"
            });
        }
    }
}