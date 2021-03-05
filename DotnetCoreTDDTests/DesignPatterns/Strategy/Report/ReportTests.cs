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

        [SetUp()]
        public void Init()
        {
            _data = new List<string>();
        }

        /// <summary>
        /// 重構成完整策略模式的前一個版本
        /// </summary>
        [Test()]
        public void RawExportTest()
        {
            // given 匯出類型字串
            var exportType = "pdf";

            // when export
            var reportObj = new LunchReport_V2();
            var fileName = reportObj.Export("午餐清單", exportType);

            // then assert
            Assert.AreEqual("午餐清單.pdf", fileName);
        }

        [Test()]
        public void ExportExcelTest()
        {
            // given 匯出策略
            IExportStrategy exporter = new ExcelExporter();

            // when export
            var reportObj = new LunchReport_V3(exporter);
            var result = reportObj.Export("午餐清單");

            // then assert
            Assert.AreEqual("午餐清單.excel", result);
        }

        [Test()]
        public void GivenExportTypeTest()
        {
            var exportType = "excel";

            // 完整重構的 strategy 
            // 在報表物件內部已不再包含策略的選擇(switch)，變成需由外部決定後再傳入報表物件
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
        public void ExportStrategyWithFactoryTest()
        {
            var exportType = "excel";

            // 將「策略選擇(switch)」的工作交給工廠(factory)負責，如此可以比較整潔
            var exporter = ExportManageTool.GetExporter(exportType);
            
            // 策略模式的目標就是使核心類別(報表類別)不再關心策略是如何被選擇的
            // 把「策略的選擇」這件事從核心邏輯(取得報表資料)中抽離出來
            var reportObj = new LunchReport_V3(exporter);
            var fileName = reportObj.Export("午餐清單");

            Assert.AreEqual("excel", _GetFileExt(fileName));
        }

        /// <summary>
        /// 取得匯出策略的工廠物件
        /// </summary>
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

        /// <summary>
        /// 取得副檔名
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string _GetFileExt(string fileName)
        {
            return System.IO.Path.GetExtension(fileName).TrimStart('.').ToLower();
        }
    }
}