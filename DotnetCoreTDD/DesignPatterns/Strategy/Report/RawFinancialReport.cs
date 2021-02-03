using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Report
{
    /// <summary>
    /// Reporter without using Strategy
    /// </summary>
    public class RawFinancialReport
    {

        public string Export(string fileName, string exportType)
        {
            IExportStrategy exportStrategy = null;
            switch (exportType)
            {
                case "excel":
                    exportStrategy = new ExcelExporter();
                    break;
                case "pdf":
                default:
                    exportStrategy = new PDFExporter();
                    break;
            }
            return exportStrategy.Export(fileName);
        }
    }
}
