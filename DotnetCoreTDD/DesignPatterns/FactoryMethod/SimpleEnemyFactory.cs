using System;

namespace DotnetCoreTDD.DesignPatterns.FactoryMethod
{
    /// <summary>
    /// 簡單敵人工廠 (非 Factory Method 模式)
    /// </summary>
    public class SimpleEnemyFactory
    {
        private readonly int _screenWidth;
        private readonly Random _random;

        public SimpleEnemyFactory(int screenWidth)
        {
            this._screenWidth = screenWidth;
            this._random = new Random();
        }

        public Enemy Create(string type)
        {
            var x = _random.Next(_screenWidth);
            Enemy enemy = null;
            switch (type)
            {
                case "Airplane":
                    enemy = new Airplane(x, 0);
                    break;
                case "Tank":
                    enemy = new Tank(x, 0);
                    break;
            }

            return enemy;
        }
    }
}