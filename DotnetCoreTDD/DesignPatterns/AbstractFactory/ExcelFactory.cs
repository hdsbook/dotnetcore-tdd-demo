using DotnetCoreTDD.DesignPatterns.AbstractFactory.Excel;

namespace DotnetCoreTDD.DesignPatterns.AbstractFactory
{
    /// <summary>
    /// 抽象工廠 介面
    /// 定義每一個子工廠都包含建立 Reader 和 Writer 此二產品的方法
    /// </summary>
    public interface IExcelFactory
    {
        public ExcelReader CreateReader();
        
        public ExcelWriter CreateWriter();
    }

    /// <summary>
    /// Excel 5 工廠
    /// </summary>
    public class Excel5Factory : IExcelFactory
    {
        public ExcelReader CreateReader()
        {
            return new Excel5Reader();
        }

        public ExcelWriter CreateWriter()
        {
            return new Excel5Writer();
        }
    }
    
    /// <summary>
    /// Excel 2007 工廠
    /// </summary>
    public class Excel2007Factory : IExcelFactory
    {
        public ExcelReader CreateReader()
        {
            return new Excel2007Reader();
        }

        public ExcelWriter CreateWriter()
        {
            return new Excel2007Writer();
        }
    }
    
    /// <summary>
    /// ODS 工廠
    /// </summary>
    public class OdsFactory : IExcelFactory
    {
        public ExcelReader CreateReader()
        {
            return new OdsReader();
        }

        public ExcelWriter CreateWriter()
        {
            return new OdsWriter();
        }
    }
}