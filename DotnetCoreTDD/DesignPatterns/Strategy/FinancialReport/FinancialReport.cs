using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.FinancialReport
{
    public class FinancialReport
    {
        public string Export(string fileName, IExportStrategy exportStrategy, object data)
        {
            return exportStrategy.Export(fileName, data);
        }
    }
}
