using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Report
{
    /// <summary>
    /// 午餐明細報表
    /// </summary>
    public class LunchReport_V2
    {

        public string Export(string fileName, string exportType)
        {
            // get data...

            IExportStrategy exporter = null;
            switch (exportType)
            {
                case "excel":
                    exporter = new ExcelExporter();
                    break;
                case "pdf":
                default:
                    exporter = new PDFExporter();
                    break;
            }
            return exporter.Export(fileName);
        }
    }
}
