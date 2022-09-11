using DotnetCoreTDD.DesignPatterns.AbstractFactory;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.AbstractFactory
{
    [TestFixture]
    public class AbstractFactoryTests
    {
        [Test]
        public void AbstractFactory_Demo()
        {
            // 以 Excel5Factory 生產物件
            IExcelFactory factory = new Excel5Factory();
            var excel5Reader = factory.CreateReader();
            var excel5Writer = factory.CreateWriter();
            
            // 以 Excel2007Factory 生產物件
            factory = new Excel2007Factory();
            var excel2007Reader = factory.CreateReader();
            var excel2007Writer = factory.CreateWriter();
            
            // 以 OdsFactory 生產物件
            factory = new OdsFactory();
            var odsReader = factory.CreateReader();
            var odsWriter = factory.CreateWriter();

            // assert
            Assert.AreEqual("xls", excel5Reader.GetExtension());
            Assert.AreEqual("xls", excel5Writer.GetExtension());
            Assert.AreEqual("xlsx", excel2007Reader.GetExtension());
            Assert.AreEqual("xlsx", excel2007Writer.GetExtension());
            Assert.AreEqual("ods", odsReader.GetExtension());
            Assert.AreEqual("ods", odsWriter.GetExtension());
        }
    }
}