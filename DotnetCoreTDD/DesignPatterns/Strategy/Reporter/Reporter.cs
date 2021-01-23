using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Reporter
{
    public class Reporter
    {
        private object _data;
        private IExportStrategy _exportStrategy;

        public Reporter(object data, IExportStrategy exportStrategy)
        {
            _data = data;
            _exportStrategy = exportStrategy;
        }

        public string Export(string fileName)
        {
            return _exportStrategy.Export(fileName, _data);
        }
    }
}
