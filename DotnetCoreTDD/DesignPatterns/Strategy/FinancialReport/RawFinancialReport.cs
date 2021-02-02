using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.FinancialReport
{
    /// <summary>
    /// Reporter without using Strategy
    /// </summary>
    public class RawFinancialReport
    {

        public string Export(string fileName, string exportType, object data)
        {
            IExportStrategy exportStrategy = null;
            switch (exportType)
            {
                case "excel":
                    exportStrategy = new ExcelExportStrategy();
                    break;
                case "pdf":
                default:
                    exportStrategy = new PDFExportStrategy();
                    break;
            }
            return exportStrategy.Export(fileName, data);
        }
    }
}
