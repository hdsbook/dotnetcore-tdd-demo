using System;
using System.Collections.Generic;

namespace DotnetCoreTDD.DesignPatterns.ChainOfResponsibility
{
    /// <summary>
    /// 抽象圖片Loader
    /// </summary>
    public abstract class AbstractImageLoader
    {
        private AbstractImageLoader NextLoader { get; set; }

        /// <summary>
        /// 設定下一關
        /// </summary>
        /// <param name="nextLoader"></param>
        /// <returns></returns>
        public AbstractImageLoader SetNext(AbstractImageLoader nextLoader)
        {
            NextLoader = nextLoader;
            return NextLoader;
        }

        /// <summary>
        /// 顯示圖片
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        public virtual string Display(string imageUrl)
        {
            return NextLoader == null
                ? null
                : NextLoader.Display(imageUrl);
        }
    }

    /// <summary>
    /// 圖片Loader (from memory)
    /// </summary>
    public class MemoryImageLoader : AbstractImageLoader
    {
        protected Dictionary<string, string> Cache = new Dictionary<string, string>();

        public override string Display(string imageUrl)
        {
            if (CheckHasCache(imageUrl))
            {
                return Cache[imageUrl];
            }
            else
            {
                var image = base.Display(imageUrl);
                if (image != null)
                {
                    PutCache(imageUrl); // 若於下一層有取到快取，在此層也存入快取
                }
                return image;
            }
        }

        public bool CheckHasCache(string imageUrl)
        {
            return Cache.ContainsKey(imageUrl);
        }

        public void PutCache(string imageUrl)
        {
            Cache[imageUrl] = "image from memory";
        }
    }

    /// <summary>
    /// 圖片Loader (from disk)
    /// </summary>
    public class DiskImageLoader : AbstractImageLoader
    {
        protected Dictionary<string, string> Cache = new Dictionary<string, string>();

        public override string Display(string imageUrl)
        {
            if (CheckHasCache(imageUrl))
            {
                return Cache[imageUrl];
            }
            else
            {
                var image = base.Display(imageUrl);
                if (image != null)
                {
                    PutCache(imageUrl); // 若於下一層有取到快取，在此層也存入快取
                }
                return image;
            }
        }

        public bool CheckHasCache(string imageUrl)
        {
            return Cache.ContainsKey(imageUrl);
        }

        public void PutCache(string imageUrl)
        {
            Cache[imageUrl] = "image from disk";
        }
    }
}