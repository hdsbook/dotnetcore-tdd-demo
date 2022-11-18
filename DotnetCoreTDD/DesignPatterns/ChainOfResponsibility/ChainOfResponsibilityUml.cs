namespace DotnetCoreTDD.DesignPatterns.ChainOfResponsibility
{
    public class ChainOfResponsibilityUml
    {
        public interface IHandler
        {
            public IHandler SetNext(IHandler handler);

            public string Handle(string request);
        }

        public class AbstractHandler : IHandler
        {
            private IHandler NextHandler { get; set; }

            public IHandler SetNext(IHandler handler)
            {
                NextHandler = handler;
                return NextHandler; // 回傳 NextHandler，使 NextHandler 可以接續串接 SetNext 方法
            }

            public virtual string Handle(string request)
            {
                return NextHandler == null
                    ? null
                    : NextHandler.Handle("A");
            }
        }
        
        
        public class RealHandlerA: AbstractHandler
        {
            public override string Handle(string request)
            {
                if (request == "A")
                {
                    return "ok on A";
                }
                else
                {
                    return base.Handle(request);
                }
            }
        }
        
        public class RealHandlerB: AbstractHandler
        {
            public override string Handle(string request)
            {
                if (request == "B")
                {
                    return "ok on B";
                }
                else
                {
                    return base.Handle(request);
                }
            }
        }
        
        public class RealHandlerC: AbstractHandler
        {
            public override string Handle(string request)
            {
                if (request == "C")
                {
                    return "ok on C";
                }
                else
                {
                    return base.Handle(request);
                }
            }
        }
    }
}