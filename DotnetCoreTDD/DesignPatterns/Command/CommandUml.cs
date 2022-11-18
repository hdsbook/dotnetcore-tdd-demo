using System.Collections.Generic;

namespace DotnetCoreTDD.DesignPatterns.Command
{
    public class CommandUml
    {
        public interface ICommand
        {
            public List<string> Execute();
        }

        public class SimpleCommand: ICommand
        {
            public List<string> Execute()
            {
                return new List<string> {"simple command do something"};
            }
        }
        
        public class ComplexCommand: ICommand
        {
            private readonly Receiver _receiver;
            private readonly string _a;
            private readonly string _b;
            public ComplexCommand(Receiver receiver, string a, string b)
            {
                _receiver = receiver;
                _a = a;
                _b = b;
            }

            public List<string> Execute()
            {
                var result = new List<string>();
                result.Add(_receiver.DoSomething(_a));
                result.Add(_receiver.DoSomethingElse(_b));
                return result;
            }
        }
        
        public class Receiver
        {
            public string DoSomething(string s)
            {
                return "complex command do something with " + s;
            }

            public string DoSomethingElse(string s)
            {
                return "complex command do something else with " + s;
            }
        }
        
        public class Invoker
        {
            private ICommand _onStart;
            private ICommand _onFinish;

            public void SetOnStart(ICommand command)
            {
                _onStart = command;
            }
            
            public void SetOnFinish(ICommand command)
            {
                _onFinish = command;
            }

            public List<string> DoSomethingImportant()
            {
                var result = new List<string>();
                
                if (_onStart is ICommand)
                {
                    result.AddRange(_onStart.Execute());
                }

                result.Add("invoker do something important");

                if (_onFinish is ICommand)
                {
                    result.AddRange(_onFinish.Execute());
                }

                return result;
            }
        }
    }

}