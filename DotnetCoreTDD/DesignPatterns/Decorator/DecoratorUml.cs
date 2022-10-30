using System.Collections.Generic;
using System.Linq;

namespace DotnetCoreTDD.DesignPatterns.Decorator
{
    public class DecoratorUml
    {
        /// <summary>
        /// 介面
        /// </summary>
        public interface IComponent
        {
            public string Operation();
        }

        /// <summary>
        /// 被裝飾者
        /// </summary>
        public class ConcreteComponent : IComponent
        {
            public string Operation()
            {
                return "做某事";
            }
        }
        
        /// <summary>
        /// 裝飾者抽象類別
        /// </summary>
        public abstract class Decorator: IComponent
        {
            protected IComponent Component { get; set; }

            protected Decorator(IComponent component)
            {
                Component = component;
            }

            public virtual string Operation()
            {
                return Component.Operation();
            }
        }
        
        public class ConcreteDecorator: Decorator
        {
            public ConcreteDecorator(IComponent component) : base(component)
            {
            }

            public override string Operation()
            {
                var operations = new List<string>();
                operations.Add(_DoSomeThingBeforeOperation());
                operations.Add(base.Operation());
                operations.Add(_DoSomeThingAfterOperation());

                return string.Join("、", operations);
            }

            private string _DoSomeThingBeforeOperation()
            {
                var result = "新增前置動作";
                return result;
            }

            private string _DoSomeThingAfterOperation()
            {
                var result = "新增後置動作";
                return result;
            }
        }
    }
}