using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Report
{
    public class PDFExporter : IExportStrategy
    {
        public string Export(string fileName)
        {
            return $"{fileName}.pdf";
        }
    }
}
