using System.Collections.Generic;

namespace DotnetCoreTDD.DesignPatterns.Flyweight
{
    /// <summary>
    /// 享元模式UML
    /// </summary>
    public class FlyweightUml
    {
        /// <summary>
        /// 抽象享元物件
        /// </summary>
        public abstract class Flyweight
        {
            /// <summary>
            /// 內部狀態 (可共享的部分：每次使用此物件時，這個值都是一樣的，不會有所改變)
            /// </summary>
            protected char IntrinsicState { get; set; }
            
            /// <summary>
            /// Operation
            /// </summary>
            /// <param name="extrinsicState">外部狀態 (不可共享的部份：會根據每次使用這個物件的情境，而使用不同的資料)</param>
            /// <returns></returns>
            public abstract string Operation(int extrinsicState);
        }

        /// <summary>
        /// 實體享元物件X
        /// </summary>
        public class ConcreteFlyweightX : Flyweight
        {
            private readonly char Type = 'X';
            
            public override string Operation(int extrinsicState)
            {
                return Type.ToString() + extrinsicState;
            }
        }
        
        /// <summary>
        /// 實體享元物件Y
        /// </summary>
        public class ConcreteFlyweightY : Flyweight
        {
            private readonly char Type = 'Y';
            
            public override string Operation(int extrinsicState)
            {
                return Type.ToString() + extrinsicState;
            }
        }
        
        /// <summary>
        /// 實體享元物件Z
        /// </summary>
        public class ConcreteFlyweightZ : Flyweight
        {
            private readonly char Type = 'Z';
            
            public override string Operation(int extrinsicState)
            {
                return Type.ToString() + extrinsicState;
            }
        }
        
        /// <summary>
        /// 享元工廠
        /// </summary>
        public class FlyweightFactory
        {
            /// <summary>
            /// 用私有成員快取各多型物件
            /// </summary>
            private readonly Dictionary<string, Flyweight> _flyweights = new Dictionary<string, Flyweight>();

            public FlyweightFactory()
            {
            }

            /// <summary>
            /// 工廠方法取得物件時，先確認快取池中是否有，若有直接回傳，若無才進行建立
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public Flyweight GetFlyweight(string key)
            {
                if (!_flyweights.ContainsKey(key))
                {
                    switch (key)
                    {
                        case "X":
                            _flyweights.Add(key, new ConcreteFlyweightX());
                            break;
                        
                        case "Y":
                            _flyweights.Add(key, new ConcreteFlyweightY());
                            break;
                        
                        case "Z":
                            _flyweights.Add(key, new ConcreteFlyweightZ());
                            break;
                    }
                }

                return _flyweights[key];
            }
        }
    }
}