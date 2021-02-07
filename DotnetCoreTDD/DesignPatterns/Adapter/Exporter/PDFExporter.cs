using DotnetCoreTDD.DesignPatterns.Adapter.Exporter.Plugins;

namespace DotnetCoreTDD.DesignPatterns.Adapter.Exporter
{

    /// <summary>
    /// PDF 轉接器
    /// </summary>
    public class PDFExporter : IExporter
    {
        private PDFDotnet _adaptee;

        public PDFExporter()
        {
            _adaptee = new PDFDotnet();
        }

        public string Export()
        {
            return _adaptee.Save();
        }
    }
}
