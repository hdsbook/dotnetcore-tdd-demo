using System;

namespace DotnetCoreTDD.DesignPatterns.ChainOfResponsibility
{
    public interface IImageLoader
    {
        public string Load();
    }

    /// <summary>
    /// 抽象圖片Loader
    /// </summary>
    public abstract class AbstractImageLoader : IImageLoader
    {
        private AbstractImageLoader NextLoader { get; set; }

        public AbstractImageLoader SetNext(AbstractImageLoader nextLoader)
        {
            NextLoader = nextLoader;
            return NextLoader;
        }

        public virtual string Load()
        {
            return NextLoader == null
                ? null
                : NextLoader.Load();
        }
    }

    /// <summary>
    /// 圖片Loader (from memory)
    /// </summary>
    public class MemoryImageLoader : AbstractImageLoader
    {
        public override string Load()
        {
            return HasImageCache()
                ? "image from memory cache"
                : base.Load();
        }

        public virtual bool HasImageCache()
        {
            return true;
        }
    }

    /// <summary>
    /// 圖片Loader (from disk)
    /// </summary>
    public class DiskImageLoader : AbstractImageLoader
    {
        public override string Load()
        {
            return HasImageCache()
                ? "image from disk"
                : base.Load();
        }

        public virtual bool HasImageCache()
        {
            return true;
        }
    }
}