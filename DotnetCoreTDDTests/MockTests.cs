using DotnetCoreTDD.DesignPatterns.Adapter.Exporter;
using NUnit.Framework;
using Moq;

namespace DotnetCoreTDDTests
{
    [TestFixture]
    public class MockTests
    {
        [Test]
        public void ExporterTest()
        {
            // given 匯出器
            var excelExporter = new ExcelExporter();

            // when 匯出
            var result = excelExporter.Export();

            // then 檢查結果
            Assert.AreEqual("匯出EXCEL", result);
        }

        [Test]
        public void MockExporterTest()
        {
            // given 假匯出器，定義當 假匯出器 執行匯出時 回傳 仿冒的結果
            var mock = new Mock<IExporter>();
            mock.Setup(x => x.Export()).Returns("仿冒的結果");

            // when 假匯出器執行 Export
            var result = mock.Object.Export();

            // then 檢查結果
            Assert.AreEqual("仿冒的結果", result);
        }
    }
}