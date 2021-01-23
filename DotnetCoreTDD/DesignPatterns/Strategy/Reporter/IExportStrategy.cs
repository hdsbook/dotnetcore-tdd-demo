using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Reporter
{
    public interface IExportStrategy
    {
        public string Export(string fileName, object data);
    }
}
