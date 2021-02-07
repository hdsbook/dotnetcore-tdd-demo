namespace DotnetCoreTDD.DesignPatterns.Strategy.Report
{
    /// <summary>
    /// 財金報表
    /// </summary>
    public class FinancialReport
    {
        IExportStrategy _exportStrategy;

        public FinancialReport(IExportStrategy exportStrategy)
        {
            _exportStrategy = exportStrategy; 
        }

        public string Export(string fileName)
        {
            return _exportStrategy.Export(fileName);
        }
    }
}
