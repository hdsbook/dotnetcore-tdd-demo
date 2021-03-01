namespace DotnetCoreTDD.DesignPatterns.Adapter.Exporter
{
    /// <summary>
    /// 匯出器介面
    /// </summary>
    public interface IExporter
    {
        public string Export();
    }

    public class MyClass
    {
        private string Attribute1;

        public void Operation1()
        {
            // ...
        }
    }
}
