using DotnetCoreTDD.DesignPatterns.Bridge.Report.Implementors;

namespace DotnetCoreTDD.DesignPatterns.Bridge.Report.Abstractions
{
    /// <summary>
    /// 報表 (抽象)
    /// </summary>
    public abstract class ReportAbstract
    {          
        private IExportImplementor _exporter;

        protected ReportAbstract(IExportImplementor exporter)
        {
            _exporter = exporter;
        }

        public abstract string GetData();

        public string Export(string fileName)
        {
            var data = GetData();
            return _exporter.Export(fileName, data);
        }
    }
}

