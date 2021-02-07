using DotnetCoreTDD.DesignPatterns.Adapter.Exporter.Plugins;

namespace DotnetCoreTDD.DesignPatterns.Adapter.Exporter
{
    /// <summary>
    /// ODS 轉接器
    /// </summary>
    public class ODSExporter : IExporter
    {
        private ODSManager _adaptee;

        public ODSExporter()
        {
            _adaptee = new ODSManager();
        }

        public string Export()
        {
            return _adaptee.Output();
        }
    }
}
