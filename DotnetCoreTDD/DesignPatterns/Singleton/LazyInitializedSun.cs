namespace DotnetCoreTDD.DesignPatterns.Singleton
{
    /// <summary>
    /// Lazy initialization, Double-checked lock
    /// 延遲初始化的太陽
    /// </summary>
    public class LazyInitializedSun
    {
        /// <summary>
        /// 此 static private 實例將與類別永生同在
        /// </summary>
        private static LazyInitializedSun Sun { get; set; } // 此處不實體化
        
        private static object syncRoot = new object();

        /// <summary>
        /// 建構函式宣告為private，避免外部呼叫建立新的太陽
        /// </summary>
        private LazyInitializedSun()
        {
        }

        /// <summary>
        /// 取得太陽實例
        /// </summary>
        /// <returns></returns>
        public static LazyInitializedSun GetInstance()
        {
            if (Sun == null) // 多人同時進入華山
            {
                lock (syncRoot) // 發現沒有太陽，排隊登上造日台
                {
                    if (Sun == null) // 第一個登上造日台的人發現沒有太陽，建立一個太陽
                    {
                        Sun = new LazyInitializedSun();
                    }
                }
            }
            return Sun; // …陽光普照，其餘人不需要再造日
        }
    }
}