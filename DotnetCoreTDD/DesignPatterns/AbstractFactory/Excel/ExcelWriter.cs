namespace DotnetCoreTDD.DesignPatterns.AbstractFactory.Excel
{
    public abstract class ExcelWriter
    {
        public abstract string GetExtension();

        public abstract string ArrayToExcel(string fileName, string[] data);
    }

    public class Excel5Writer : ExcelWriter
    {
        public override string GetExtension() => "xls";

        public override string ArrayToExcel(string fileName, string[] data) => $"以 Excel5 的格式寫入檔案 {fileName}";
    }
    
    public class Excel2007Writer : ExcelWriter
    {
        public override string GetExtension() => "xlsx";

        public override string ArrayToExcel(string fileName, string[] data) => $"以 Excel2007 的格式寫入檔案 {fileName}";
    }
    
    public class OdsWriter : ExcelWriter
    {
        public override string GetExtension() => "ods";

        public override string ArrayToExcel(string fileName, string[] data) => $"以 ODS 的格式寫入檔案 {fileName}";
    }
}