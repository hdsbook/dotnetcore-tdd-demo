using System.Threading;

namespace DotnetCoreTDD.DesignPatterns.Prototype
{
    public class PrototypeExample
    {
        /// <summary>
        /// 敵機 Prototype
        /// </summary>
        public abstract class EnemyPlanePrototype
        {
            /// <summary>敵機X座標</summary>
            protected int X { get; set; }

            /// <summary>敵機Y座標</summary>
            protected int Y = 0;

            protected EnemyPlanePrototype(int x)
            {
                this.X = x;
            }

            public int GetX() => X;
            public int GetY() => Y;

            public abstract EnemyPlanePrototype Clone();

            public void Fly()
            {
                this.Y = this.Y + 1;
            }
        }

        /// <summary>
        /// 敵機類別
        /// </summary>
        public class EnemyPlane : EnemyPlanePrototype
        {
            public EnemyPlane(int x) : base(x)
            {
                Thread.Sleep(1); // 睡1毫秒，模擬建立此物件需要一些時間
            }
            
            /// <summary>
            /// 此方法讓複製後的敵機原型的X座標可以被改變
            /// </summary>
            /// <param name="x"></param>
            public void SetX(int x)
            {
                this.X = x;
            }

            public override EnemyPlanePrototype Clone()
            {
                return (EnemyPlanePrototype) this.MemberwiseClone();
            }
        }

        /// <summary>
        /// 敵機工廠
        /// </summary>
        public static class EnemyPlaneFactory
        {
            /// <summary>
            /// 用單例餓漢模式(eager initialization，詳見singleton模式範例)造一個敵機原型
            /// </summary>
            private static EnemyPlane protoType = new EnemyPlane(200);
            public static EnemyPlane GetInstance(int x)
            {
                var clonePlane = (EnemyPlane) protoType.Clone();
                clonePlane.SetX(x);
                return clonePlane;
            }
        }
    }
}