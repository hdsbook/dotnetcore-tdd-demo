namespace DotnetCoreTDD.DesignPatterns.Singleton
{
    /// <summary>
    /// Eager initialization
    /// 急於初始化的太陽
    /// </summary>
    public class EagerInitializedSun
    {
        /// <summary>
        /// 此 static private 實例將與類別永生同在
        /// </summary>
        private static readonly EagerInitializedSun Sun = new EagerInitializedSun(); // 在初始化階段就進行實例化 => eager initialization
        
        /// <summary>
        /// 建構函式宣告為private，避免外部呼叫建立新的太陽
        /// </summary>
        private EagerInitializedSun()
        {
        }

        /// <summary>
        /// 取得太陽實例
        /// </summary>
        /// <returns></returns>
        public static EagerInitializedSun GetInstance()
        {
            return Sun;
        }
    }
}