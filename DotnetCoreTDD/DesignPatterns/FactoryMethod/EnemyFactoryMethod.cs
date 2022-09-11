using System;

namespace DotnetCoreTDD.DesignPatterns.FactoryMethod
{
    /// <summary>
    /// 工廠方法
    /// </summary>
    public abstract class EnemyFactoryMethod
    {
        protected readonly int _screenWidth;
        protected readonly Random _random;

        protected EnemyFactoryMethod(int screenWidth)
        {
            this._screenWidth = screenWidth;
            this._random = new Random();
        }

        public abstract Enemy Create();
    }

    /// <summary>
    /// 敵機工廠
    /// </summary>
    public class AirplaneEnemyFactory : EnemyFactoryMethod
    {
        public AirplaneEnemyFactory(int screenWidth) : base(screenWidth)
        {
        }

        public override Enemy Create()
        {
            return new Airplane(this._random.Next(_screenWidth), 0);
        }
    }
    
    /// <summary>
    /// 坦克工廠
    /// </summary>
    public class TankEnemyFactory : EnemyFactoryMethod
    {
        public TankEnemyFactory(int screenWidth) : base(screenWidth)
        {
        }

        public override Enemy Create()
        {
            return new Tank(this._random.Next(_screenWidth), 0);
        }
    }
}