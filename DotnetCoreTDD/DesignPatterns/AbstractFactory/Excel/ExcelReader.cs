namespace DotnetCoreTDD.DesignPatterns.AbstractFactory.Excel
{
    public abstract class ExcelReader
    {
        public abstract string GetExtension();

        public abstract string ExcelToArray(string fileName);
    }

    public class Excel5Reader : ExcelReader
    {
        public override string GetExtension() => "xls";

        public override string ExcelToArray(string fileName) => $"以 Excel5 的格式讀取檔案 {fileName}";
    }
    
    public class Excel2007Reader : ExcelReader
    {
        public override string GetExtension() => "xlsx";

        public override string ExcelToArray(string fileName) => $"以 Excel2007 的格式讀取檔案 {fileName}";
    }
    
    public class OdsReader : ExcelReader
    {
        public override string GetExtension() => "ods";

        public override string ExcelToArray(string fileName) => $"以 ODS 的格式讀取檔案 {fileName}";
    }
}