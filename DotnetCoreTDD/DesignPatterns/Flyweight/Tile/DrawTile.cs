using System.Collections.Generic;

namespace DotnetCoreTDD.DesignPatterns.Flyweight.Tile
{
    public class DrawTile
    {
        /// <summary>
        /// 抽象享元物件 (圖塊父類別)
        /// </summary>
        public abstract class Tile
        {
            /// <summary>
            /// 內部狀態 (圖片，每次畫上圖塊，都是畫上相同的圖塊)
            /// </summary>
            protected string Image { get; set; }

            /// <summary>
            /// 繪製
            /// </summary>
            /// <param name="x">x座標 (外部狀態，每次進行繪製的坐標都不相同)</param>
            /// <param name="y">y座標 (外部狀態，每次進行繪製的坐標都不相同)</param>
            /// <returns></returns>
            public abstract string Draw(int x, int y);
        }

        /// <summary>
        /// 實體享元物件(草地)
        /// </summary>
        public class Grass : Tile
        {
            protected string Image = "草地";

            public override string Draw(int x, int y)
            {
                return $"在({x}, {y})處繪製" + Image + "，並切換圖層至底層";
            }
        }

        /// <summary>
        /// 實體享元物件(河川)
        /// </summary>
        public class River : Tile
        {
            protected string Image = "河川";

            public override string Draw(int x, int y)
            {
                return $"在({x}, {y})處繪製" + Image;
            }
        }

        /// <summary>
        /// 實體享元物件(房屋)
        /// </summary>
        public class House : Tile
        {
            protected string Image = "房屋";

            public override string Draw(int x, int y)
            {
                return $"在({x}, {y})處繪製" + Image + "，並切換圖層至頂層";
            }
        }


        /// <summary>
        /// 享元工廠
        /// </summary>
        public class TileFactory
        {
            /// <summary>
            /// 暫存器
            /// </summary>
            private readonly Dictionary<TileType, Tile> _tiles = new Dictionary<TileType, Tile>();

            /// <summary>
            /// 工廠方法：取得圖塊物件
            /// </summary>
            /// <param name="type">圖塊類型</param>
            /// <returns></returns>
            public Tile GetTile(TileType type)
            {
                
                // 用懶載入的方式初始化暫存的 dictionary (若無暫存，才建立實體)
                if (!_tiles.ContainsKey(type))
                {
                    switch (type)
                    {
                        case TileType.River:
                            _tiles.Add(type, new River());
                            break;
                        case TileType.Grass:
                            _tiles.Add(type, new Grass());
                            break;
                        case TileType.House:
                            _tiles.Add(type, new House());
                            break;
                    }
                }

                return _tiles[type];
            }

            /// <summary>
            /// 圖塊類型列舉
            /// </summary>
            public enum TileType
            {
                River = 1,
                Grass = 2,
                House = 3
            }
        }
    }
}