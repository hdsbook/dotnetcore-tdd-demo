using DotnetCoreTDD.DesignPatterns.Builder;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.Builder
{
    [TestFixture]
    public class CellBuilderTests
    {
        [Test]
        public void Build_Works_Correctly()
        {
            // given expected
            var text = "標題";
            var colspan = 10;
            var rowspan = 2;
            var color = "red";
            var alignment = "center";
            
            // when build cell
            var cell = new CellBuilder(text)
                .SetColspan(colspan)
                .SetRowspan(rowspan)
                .SetColor(color)
                .SetAlignment(alignment)
                .Build();
            
            // then assert
            Assert.AreEqual(text, cell.Text);
            Assert.AreEqual(colspan, cell.Colspan);
            Assert.AreEqual(rowspan, cell.Rowspan);
            Assert.AreEqual(color, cell.Color);
            Assert.AreEqual(alignment, cell.Alignment);
        }
        
        [Test]
        public void SetFooterStyle_Works_Correctly()
        {
            // given expected
            var text = "標題";
            var colspan = 10;
            var rowspan = 1;
            var color = "gray";
            var alignment = "right";
            
            // when build cell
            var cell = new CellBuilder(text)
                .SetFooterStyle()
                .Build();
            
            // then assert
            Assert.AreEqual(text, cell.Text);
            Assert.AreEqual(colspan, cell.Colspan);
            Assert.AreEqual(rowspan, cell.Rowspan);
            Assert.AreEqual(color, cell.Color);
            Assert.AreEqual(alignment, cell.Alignment);
        }
    }
}