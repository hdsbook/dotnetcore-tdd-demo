using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Report
{
    public class ExcelExporter: IExportStrategy
    {
        public string Export(string fileName)
        {
            return $"{fileName}.excel";
        }
    }
}
