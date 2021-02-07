namespace DotnetCoreTDD.DesignPatterns.Adapter.Exporter
{
    /// <summary>
    /// Excel匯出器
    /// </summary>
    public class ExcelExporter : IExporter
    {
        public string Export()
        {
            return "匯出EXCEL";
        }
    }
}
