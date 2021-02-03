using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Report
{
    public interface IExportStrategy
    {
        public string Export(string fileName);
    }
}
