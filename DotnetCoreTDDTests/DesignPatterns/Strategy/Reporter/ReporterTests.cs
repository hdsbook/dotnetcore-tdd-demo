using NUnit.Framework;
using DotnetCoreTDD.DesignPatterns.Strategy.Reporter;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Reporter.Tests
{
    [TestFixture()]
    public class ReporterTests
    {
        private string _fileName;
        private object _data;

        [SetUp]
        public void Init()
        {
            _fileName = "test";
            _data = new List<string>();
        }

        [Test()]
        public void ExportExcelTest()
        {
            // Arrange
            var exportStrategy = new ExcelExportStrategy();
            var reporter = new Reporter(_data, exportStrategy);

            // Act
            var expected = $"{_fileName}.excel";
            var actual = reporter.Export(_fileName);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void ExportPDFTest()
        {
            // Arrange
            var exportStrategy = new PDFExportStrategy();
            var reporter = new Reporter(_data, exportStrategy);

            // Act
            var expected = $"{_fileName}.pdf";
            var actual = reporter.Export(_fileName);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}