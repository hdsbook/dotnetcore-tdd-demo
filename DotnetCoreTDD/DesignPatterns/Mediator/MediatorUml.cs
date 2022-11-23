using System;
using System.Collections.Generic;

namespace DotnetCoreTDD.DesignPatterns.Mediator
{
    public class MediatorUml
    {
        public interface IMediator
        {
            void Register(IComponent component);
        }
        
        public interface IComponent
        {
            void SetMediator(ConcreteMediator mediator);
            void ReceiveMessage(string message);
        }

        public class ConcreteMediator : IMediator
        {
            private readonly List<IComponent> Components = new List<IComponent>();
            public void Register(IComponent component)
            {
                Components.Add(component);
                component.SetMediator(this);
            }

            public void DistributeMessage(string message)
            {
                foreach (var component in Components)
                {
                    component.ReceiveMessage(message);
                }
            }
        }


        public class ConcreteComponentA : IComponent
        {
            private readonly List<string> ReceivedMessages = new List<string>();
            private ConcreteMediator _mediator = null;

            public void SetMediator(ConcreteMediator mediator)
            {
                _mediator = mediator;
            }
            
            public void ReceiveMessage(string message)
            {
                ReceivedMessages.Add(message);
            }

            public void SendMessage(string message)
            {
                _mediator.DistributeMessage(message);
            }

            public List<string> GetReceivedMessages()
            {
                return ReceivedMessages;
            }
        }
        
        public class ConcreteComponentB : IComponent
        {
            private readonly List<string> ReceivedMessages = new List<string>();
            private ConcreteMediator _mediator = null;

            public void SetMediator(ConcreteMediator mediator)
            {
                _mediator = mediator;
            }
            
            public void ReceiveMessage(string message)
            {
                // 假設接受訊息時，會多加紀錄日期資訊
                message = DateTime.Now.ToString("yyyy/MM/dd") + ":" + message;
                ReceivedMessages.Add(message);
            }

            public void SendMessage(string message)
            {
                // 可能會在發送訊息時為訊息加上一個前綴
                _mediator.DistributeMessage("[From B]" + message);
            }

            public List<string> GetReceivedMessages()
            {
                return ReceivedMessages;
            }
        }
    }

}