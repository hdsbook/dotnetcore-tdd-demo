namespace DotnetCoreTDD.DesignPatterns.Strategy.Report
{
    /// <summary>
    /// Excel 匯出器
    /// </summary>
    public class ExcelExporter: IExportStrategy
    {
        public string Export(string fileName)
        {
            return $"{fileName}.excel";
        }
    }
}
