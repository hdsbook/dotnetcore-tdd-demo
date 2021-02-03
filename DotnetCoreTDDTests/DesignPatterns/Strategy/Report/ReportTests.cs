using NUnit.Framework;
using DotnetCoreTDD.DesignPatterns.Strategy.Report;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Report.Tests
{
    [TestFixture()]
    public class ReportTests
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
            var reportObj = new LunchReport_V2();
            var fileName = reportObj.Export("午餐清單", exportType);

            Assert.AreEqual("午餐清單.pdf", fileName);
        }

        [Test]
        public void ExportExcelTest()
        {
            IExportStrategy exporter = new ExcelExporter();
            var reportObj = new LunchReport_V3(exporter);
            var result = reportObj.Export("午餐清單");

            Assert.AreEqual("午餐清單.excel", result);
        }

        [Test]
        public void GivenExportTypeTest()
        {
            // given
            var exportType = "excel";

            // when export
            IExportStrategy exporter = null;
            switch (exportType)
            {
                case "pdf":
                    exporter = new PDFExporter();
                    break;
                case "excel":
                default:
                    exporter = new ExcelExporter();
                    break;
            }
            var reportObj = new LunchReport_V3(exporter);
            var result = reportObj.Export("午餐清單");

            Assert.AreEqual(exportType, _GetFileExt(result));
        }

        [Test()]
        public void ExportStrategyTest2()
        {
            // given
            var exportType = "excel";

            // when export
            var exporter = ExportManageTool.GetExporter(exportType);
            var reportObj = new LunchReport_V3(exporter);
            var fileName = reportObj.Export("午餐清單");

            Assert.AreEqual("excel", _GetFileExt(fileName));
        }

        public class ExportManageTool
        {
            public static IExportStrategy GetExporter(string exportType)
            {
                switch (exportType)
                {
                    case "pdf":
                        return new PDFExporter();
                    case "excel":
                    default:
                        return new ExcelExporter();
                }
            }
        }


        private string _GetFileExt(string fileName)
        {
            return System.IO.Path.GetExtension(fileName).TrimStart('.').ToLower();
        }
    }
}