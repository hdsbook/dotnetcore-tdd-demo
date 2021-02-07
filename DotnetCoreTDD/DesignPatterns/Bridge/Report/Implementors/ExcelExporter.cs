namespace DotnetCoreTDD.DesignPatterns.Bridge.Report.Implementors
{
    /// <summary>
    /// Excel 匯出器
    /// </summary>
    public class ExcelExporter: IExportImplementor
    {
        public string Export(string fileName, string data)
        {
            return $"{fileName}.excel: {data}";
        }
    }
}
