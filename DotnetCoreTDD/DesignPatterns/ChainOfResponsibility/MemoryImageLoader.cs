using System;

namespace DotnetCoreTDD.DesignPatterns.ChainOfResponsibility
{
    public interface IImageLoader
    {
        public string Load();
    }

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


    public class MemoryImageLoader : AbstractImageLoader
    {
        public override string Load()
        {
            return CheckHasCache()
                ? "image from memory cache"
                : base.Load();
        }

        public virtual bool CheckHasCache()
        {
            return true;
        }
    }

    public class DiskImageLoader : AbstractImageLoader
    {
        public override string Load()
        {
            return CheckHasCache()
                ? "image from disk"
                : base.Load();
        }

        public virtual bool CheckHasCache()
        {
            return true;
        }
    }
}