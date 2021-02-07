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
            var excelExporter = new ExcelExporter();
            var pdfExporter = new PDFExporter();

            var lunchPdfReport = new LunchReport(pdfExporter);
            var lunchExcelReport = new LunchReport(excelExporter);
            var financialPdfReport = new FinancialReport(pdfExporter);
            var financialExcelReport = new FinancialReport(excelExporter);

            Assert.AreEqual("午餐明細.pdf: 午餐明細資料", lunchPdfReport.Export("午餐明細"));
            Assert.AreEqual("午餐明細.excel: 午餐明細資料", lunchExcelReport.Export("午餐明細"));
            Assert.AreEqual("財金報表.pdf: 財金報表資料", financialPdfReport.Export("財金報表"));
            Assert.AreEqual("財金報表.excel: 財金報表資料", financialExcelReport.Export("財金報表"));
        }
    }
}