using NUnit.Framework;
using DotnetCoreTDD.DesignPatterns.Bridge.Report.Abstractions;
using DotnetCoreTDD.DesignPatterns.Bridge.Report.Implementors;
using System;
using System.Collections.Generic;
using System.Text;


namespace DotnetCoreTDDTests.DesignPatterns.Bridge
{
    [TestFixture()]
    public class ReportTests
    {
        [Test()]
        public void BridgeTest()
        {
            // Bridge 就是把一組概念相同的名詞(報表)，與一組概念相同的實作(匯出)橋接在一起的橋接模式

            // given 兩種匯出實作
            var excelExporter = new ExcelExporter();
            var pdfExporter = new PDFExporter();

            // given 午餐報表對應不同的實作
            var lunchPdfReport = new LunchReport(pdfExporter);
            var lunchExcelReport = new LunchReport(excelExporter);

            // given 財務報表對應不同的實作
            var financialPdfReport = new FinancialReport(pdfExporter);
            var financialExcelReport = new FinancialReport(excelExporter);

            // then assert 不同報表對應不同實作的結果
            Assert.AreEqual("午餐明細.pdf: 午餐明細資料", lunchPdfReport.Export("午餐明細"));
            Assert.AreEqual("午餐明細.excel: 午餐明細資料", lunchExcelReport.Export("午餐明細"));
            Assert.AreEqual("財金報表.pdf: 財金報表資料", financialPdfReport.Export("財金報表"));
            Assert.AreEqual("財金報表.excel: 財金報表資料", financialExcelReport.Export("財金報表"));
        }
    }
}