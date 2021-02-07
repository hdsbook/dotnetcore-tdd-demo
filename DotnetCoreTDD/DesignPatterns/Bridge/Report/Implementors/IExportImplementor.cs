namespace DotnetCoreTDD.DesignPatterns.Bridge.Report.Implementors
{
    /// <summary>
    /// 匯出 (實作)
    /// </summary>
    public interface IExportImplementor
    {
        public string Export(string fileName, string data);
    }
}
