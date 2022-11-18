using System.Collections.Generic;
using DotnetCoreTDD.DesignPatterns.Command;
using FluentAssertions;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.Command
{
    [TestFixture]
    public class CommandUmlTests
    {
        [Test]
        public void GivenInvoker_SetHooksWithCommands_WorksCorrectly()
        {
            // given invoker
            var invoker = new CommandUml.Invoker();
            
            // given receiver
            var receiver = new CommandUml.Receiver();

            // given simple command and complex command
            var simpleCommand = new CommandUml.SimpleCommand();
            var complexCommand = new CommandUml.ComplexCommand(receiver, "a", "b");
            
            // when set start and finish hooks to invoker
            invoker.SetOnStart(simpleCommand);
            invoker.SetOnFinish(complexCommand);
            
            // when invoker do something important
            var executeHistory = invoker.DoSomethingImportant();

            // then
            var expected = new List<string>
            {
                "simple command do something",
                "invoker do something important",
                "complex command do something with a",
                "complex command do something else with b"
            };
            executeHistory.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }
    }
}