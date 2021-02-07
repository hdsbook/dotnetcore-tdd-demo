using DotnetCoreTDD.DesignPatterns.Bridge.Report.Implementors;

namespace DotnetCoreTDD.DesignPatterns.Bridge.Report.Abstractions
{
    /// <summary>
    /// 午餐明細報表
    /// </summary>
    public class LunchReport: ReportAbstract
    {
        private IExportImplementor _exporter;

        public LunchReport(IExportImplementor exporter) : base(exporter) { }

        public override string GetData()
        {
            return "午餐明細資料";
        }
    }
}
