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
        public virtual string Load(string imageUrl)
        {
            return NextLoader == null
                ? null
                : NextLoader.Load(imageUrl);
        }
    }

    /// <summary>
    /// 圖片Loader (from memory)
    /// </summary>
    public class MemoryImageLoader : AbstractImageLoader
    {
        protected Dictionary<string, string> Cache = new Dictionary<string, string>();

        public override string Load(string imageUrl)
        {
            string picture = null;
            if (CheckHasCache(imageUrl))
            {
                picture = Cache[imageUrl];
            }
            else
            {
                picture = base.Load(imageUrl);
                if (picture != null) PutCache(imageUrl); // 若於下一層有取到快取，在此層也存入快取
            }
            return picture;
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

        public override string Load(string imageUrl)
        {
            string image;
            if (CheckHasCache(imageUrl))
            {
                image = Cache[imageUrl];
            }
            else
            {
                image = base.Load(imageUrl);
                if (image != null) PutCache(imageUrl); // 若於下一層有取到快取，在此層也存入快取
            }
            return image;
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