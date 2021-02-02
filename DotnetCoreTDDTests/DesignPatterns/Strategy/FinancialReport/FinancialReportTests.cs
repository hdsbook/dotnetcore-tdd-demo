using NUnit.Framework;
using DotnetCoreTDD.DesignPatterns.Strategy.FinancialReport;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.FinancialReport.Tests
{
    [TestFixture()]
    public class FinancialReportTests
    {
        private object _data;

        [SetUp]
        public void Init()
        {
            _data = new List<string>();
        }

        [Test()]
        public void RawExportTest()
        {
            // given
            var exportType = "pdf";

            // when export
            var reportObj = new RawFinancialReport();
            var fileName = reportObj.Export("財務報表", exportType, _data);

            Assert.AreEqual("財務報表.pdf", fileName);
        }

        [Test()]
        public void ExportStrategyTest()
        {
            // given
            var exportType = "excel";

            // when export
            IExportStrategy exportStrategy = null;
            switch (exportType)
            {
                case "pdf":
                    exportStrategy = new PDFExportStrategy();
                    break;
                case "excel":
                default:
                    exportStrategy = new ExcelExportStrategy();
                    break;
            }
            var reportObj = new FinancialReport();
            var fileName = reportObj.Export("財務報表", exportStrategy, _data);

            Assert.AreEqual("財務報表.excel", fileName);
        }

        [Test()]
        public void ExportStrategyTest2()
        {
            // given
            var exportType = "excel";

            // when export
            var exportStrategy = _GetExportStrategy(exportType);
            var reportObj = new FinancialReport();
            var fileName = reportObj.Export("財務報表", exportStrategy, _data);

            Assert.AreEqual("excel", _GetFileExt(fileName));
        }

        private IExportStrategy _GetExportStrategy(string exportType)
        {
            switch (exportType)
            {
                case "pdf":
                    return new PDFExportStrategy();
                case "excel":
                default:
                    return new ExcelExportStrategy();
            }
        }

        private string _GetFileExt(string fileName)
        {
            return System.IO.Path.GetExtension(fileName).TrimStart('.').ToLower();
        }
    }
}