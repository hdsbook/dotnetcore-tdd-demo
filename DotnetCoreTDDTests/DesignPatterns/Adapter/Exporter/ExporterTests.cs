using NUnit.Framework;
using DotnetCoreTDD.DesignPatterns.Adapter.Exporter;
using DotnetCoreTDD.DesignPatterns.Adapter.Exporter.Plugins;

namespace DotnetCoreTDDTests.DesignPatterns.Adapter.Exporter
{
    [TestFixture()]
    public class ExporterTests
    {
        [Test()]
        public void BeforeAdapterTest()
        {
            var excelExporter = new ExcelExporter();
            var pdfPlugin = new PDFDotnet();
            var odsPlugin = new ODSManager();

            // 原本 PDF、ODS 各自實作不同的介面，呼叫的方法名稱不同
            Assert.AreEqual("匯出EXCEL", excelExporter.Export());
            Assert.AreEqual("匯出PDF", pdfPlugin.Save());
            Assert.AreEqual("匯出ODS", odsPlugin.Output());
        }

        [Test()]
        public void AdapterTest()
        {
            var excelExporter = new ExcelExporter();
            var pdfExporter = new PDFExporter();
            var odsExporter = new ODSExporter();

            // 採用 Adapter 轉接後，均使用相同的介面
            Assert.AreEqual("匯出EXCEL", excelExporter.Export());
            Assert.AreEqual("匯出PDF", pdfExporter.Export());
            Assert.AreEqual("匯出ODS", odsExporter.Export());
        }
    }
}