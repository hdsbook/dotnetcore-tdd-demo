namespace DotnetCoreTDD.DesignPatterns.FactoryMethod
{
    public abstract class Enemy
    {
        protected int X { get; set; }
        protected int Y { get; set; }

        protected Enemy(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public abstract string Show();
    }

    /// <summary>
    /// 敵機
    /// </summary>
    class Airplane : Enemy
    {
        public Airplane(int x, int y) : base(x, y)
        {
        }

        public override string Show()
        {
            return $"飛機出現在座標({this.X}, {this.Y})";
        }
    }
    
    /// <summary>
    /// 坦克
    /// </summary>
    class Tank : Enemy
    {
        public Tank(int x, int y) : base(x, y)
        {
        }

        public override string Show()
        {
            return $"坦克出現在座標({this.X}, {this.Y})";
        }
    }
}