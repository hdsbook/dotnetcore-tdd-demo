using DotnetCoreTDD.DesignPatterns.Bridge.Report.Implementors;

namespace DotnetCoreTDD.DesignPatterns.Bridge.Report.Abstractions
{
    /// <summary>
    /// 財金報表
    /// </summary>
    public class FinancialReport: ReportAbstract
    {
        private IExportImplementor _exporter;

        public FinancialReport(IExportImplementor exporter) : base(exporter) { }

        public override string GetData()
        {
            return "財金報表資料";
        }
    }
}
