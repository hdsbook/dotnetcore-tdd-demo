using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Reporter
{
    public class ExcelExportStrategy: IExportStrategy
    {
        public string Export(string fileName, object data)
        {
            return $"{fileName}.excel";
        }
    }
}
