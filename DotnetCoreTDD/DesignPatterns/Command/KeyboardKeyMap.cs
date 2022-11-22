using System.Collections.Generic;

namespace DotnetCoreTDD.DesignPatterns.Command.KeymapExample
{
    public class Keyboard
    {
        private Dictionary<string, List<IKeyMapCommand>> Keymaps = new Dictionary<string, List<IKeyMapCommand>>();

        public void SetKeyMap(string key, List<IKeyMapCommand> commands)
        {
            Keymaps[key] = commands;
        }

        public List<string> Click(string key)
        {
            var actions = new List<string>();
            if (Keymaps.ContainsKey(key))
            {
                var commands = Keymaps[key];
                foreach (var command in commands)
                {
                    var action = command.Execute();
                    actions.Add(action);
                }
            }

            return actions;
        }
    }

    public interface IKeyMapCommand
    {
        public string Execute();
    }

    public class Attack : IKeyMapCommand
    {
        public string Execute()
        {
            return "攻擊";
        }
    }

    public class Defense : IKeyMapCommand
    {
        public string Execute()
        {
            return "防守";
        }
    }

    public class MoveForward : IKeyMapCommand
    {
        public string Execute()
        {
            return "向前移動";
        }
    }

    public class MoveBackward : IKeyMapCommand
    {
        public string Execute()
        {
            return "向後移動";
        }
    }

    public class MoveRight : IKeyMapCommand
    {
        public string Execute()
        {
            return "向右移動";
        }
    }

    public class MoveLeft : IKeyMapCommand
    {
        public string Execute()
        {
            return "向左移動";
        }
    }
}