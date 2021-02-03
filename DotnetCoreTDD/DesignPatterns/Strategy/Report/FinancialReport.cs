using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Report
{
    public class FinancialReport
    {
        IExportStrategy _exportStrategy;

        public FinancialReport(IExportStrategy exportStrategy)
        {
            _exportStrategy = exportStrategy; 
        }

        public string Export(string fileName)
        {
            return _exportStrategy.Export(fileName);
        }
    }
}
