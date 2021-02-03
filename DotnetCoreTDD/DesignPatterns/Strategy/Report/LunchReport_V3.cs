using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Report
{
    /// <summary>
    /// 午餐明細報表
    /// </summary>
    public class LunchReport_V3
    {
        private IExportStrategy _exporter;

        public LunchReport_V3(IExportStrategy exporter)
        {
            _exporter = exporter;
        }

        public string Export(string fileName)
        {
            // get data ...

            return _exporter.Export(fileName);
        }
    }
}
