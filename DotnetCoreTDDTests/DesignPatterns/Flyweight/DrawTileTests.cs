using DotnetCoreTDD.DesignPatterns.Flyweight.Tile;
using FluentAssertions;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.Flyweight
{
    [TestFixture]
    public class DrawTileTests
    {
        [Test]
        public void Draw_Works_Correctly()
        {
            // given 坐標
            var x = 0;
            var y = 0;
            
            // given 圖塊工廠
            var factory = new DrawTile.TileFactory();
            
            // when 取得各式各樣的圖塊
            var grass = factory.GetTile(DrawTile.TileFactory.TileType.Grass);
            var river = factory.GetTile(DrawTile.TileFactory.TileType.River);
            var house = factory.GetTile(DrawTile.TileFactory.TileType.House);
            
            // when 執行繪製
            var grassDrawResult = grass.Draw(x, y);
            var riverDrawResult = river.Draw(x, y);
            var houseDrawResult = house.Draw(x, y);

            // then 驗證結果正確
            var expectedCoordinate = $"({x}, {y})";
            grassDrawResult.Should().Contain("草地");
            grassDrawResult.Should().Contain(expectedCoordinate);
            riverDrawResult.Should().Contain("河川");
            riverDrawResult.Should().Contain(expectedCoordinate);
            houseDrawResult.Should().Contain("房屋");
            houseDrawResult.Should().Contain(expectedCoordinate);
        }
        
        [Test]
        public void GetBy_SameKey_ReturnsSameObject()
        {
            // given 圖塊工廠
            var factory = new DrawTile.TileFactory();
            
            // when 取得多次同一種圖塊
            var grass1 = factory.GetTile(DrawTile.TileFactory.TileType.Grass);
            var grass2 = factory.GetTile(DrawTile.TileFactory.TileType.Grass);

            // then 驗證這些圖塊是相同物件
            (grass1 == grass2).Should().BeTrue();
        }
    }
}