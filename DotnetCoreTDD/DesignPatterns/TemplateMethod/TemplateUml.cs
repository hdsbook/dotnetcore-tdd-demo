namespace DotnetCoreTDD.DesignPatterns.TemplateMethod
{
    public class TemplateUml
    {
        public abstract class AbstractTemplate
        {
            public string Operation1()
            {
                var operation1 = "option 1";
                return operation1;
            }
            
            public abstract string Operation2();
        }

        public class ConcreteTemplateA : AbstractTemplate
        {
            public override string Operation2()
            {
                return "do operation 2 for template A";
            }
        }

        public class ConcreteTemplateB : AbstractTemplate
        {
            public override string Operation2()
            {
                return "do operation 2 for template B";
            }
        }
    }
}