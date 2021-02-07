namespace DotnetCoreTDD.DesignPatterns.Bridge.Report.Implementors
{
    /// <summary>
    /// PDF 匯出器
    /// </summary>
    public class PDFExporter : IExportImplementor
    {
        public string Export(string fileName, string data)
        {
            return $"{fileName}.pdf: {data}";
        }
    }
}
