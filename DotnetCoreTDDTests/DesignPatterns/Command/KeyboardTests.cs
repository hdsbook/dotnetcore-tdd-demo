using System.Collections.Generic;
using DotnetCoreTDD.DesignPatterns.Command;
using DotnetCoreTDD.DesignPatterns.Command.KeymapExample;
using FluentAssertions;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.Command
{
    [TestFixture]
    public class KeyboardTests
    {
        [Test]
        public void GivenKeyboard_SetKeyMaps_WorksCorrectly()
        {
            // given keyboard
            var keyboard = new Keyboard();
            
            // when set keymap to A
            keyboard.SetKeyMap("A", new List<IKeyMapCommand>
            {
                new MoveForward(),
                new Attack(),
                new MoveBackward(),
            });
            
            // when set keymap to B
            keyboard.SetKeyMap("B", new List<IKeyMapCommand>
            {
                new MoveBackward(),
                new Defense()
            });
            
            
            // when click keyboard keys
            var actionsOfA = keyboard.Click("A");
            var actionsOfB = keyboard.Click("B");
            var actionsOfC = keyboard.Click("C");
            
            // then
            actionsOfA.Should().BeEquivalentTo(new List<string>
            {
                "向前移動",
                "攻擊",
                "向後移動",
            });
            
            actionsOfB.Should().BeEquivalentTo(new List<string>
            {
                "向後移動",
                "防守",
            });
            
            actionsOfC.Should().BeEmpty();
        }
    }
}