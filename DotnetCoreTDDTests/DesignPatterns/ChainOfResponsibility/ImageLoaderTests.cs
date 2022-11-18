using DotnetCoreTDD.DesignPatterns.ChainOfResponsibility;
using FluentAssertions;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.ChainOfResponsibility
{
    [TestFixture]
    public class ImageLoaderTests
    {
        [Test]
        public void GivenLoaders_WhenImageInMemory_ReturnsImageFromMemory()
        {
            // given testable loaders，並改寫 CheckHasCache 行為，使圖片存在 memory cache
            var memory = new TestableMemoryImageLoader();
            var disk = new TestableDiskImageLoader();
            memory.SetHasCache(true);
            disk.SetHasCache(false);

            // given loaders with sequence: memory -> disk
            memory.SetNext(disk);

            // when load image
            var image = memory.Load();

            // then
            image.Should().Contain("image from memory cache");
        }
        
        [Test]
        public void GivenLoaders_WhenImageInDisk_ReturnsImageFromDisk()
        {
            // given testable loaders，並改寫 CheckHasCache 行為，使圖片存在 disk
            var memory = new TestableMemoryImageLoader();
            var disk = new TestableDiskImageLoader();
            memory.SetHasCache(false);
            disk.SetHasCache(true);

            // given loaders with sequence: memory -> disk
            memory.SetNext(disk);

            // when load image
            var image = memory.Load();

            // then
            image.Should().Contain("image from disk");
        }
        
        [Test]
        public void GivenLoaders_WhenImageNotExist_ReturnsNull()
        {
            // given testable loaders，並改寫 CheckHasCache 行為，使圖片不存在 memory，也不存在於 disk
            var memory = new TestableMemoryImageLoader();
            var disk = new TestableDiskImageLoader();
            memory.SetHasCache(false);
            disk.SetHasCache(false);

            // given loaders with sequence: memory -> disk
            memory.SetNext(disk);

            // when load image
            var image = memory.Load();

            // then
            image.Should().BeNull();
        }


        public class TestableDiskImageLoader : DiskImageLoader
        {
            private bool _hasCache = true;

            public void SetHasCache(bool hasCache)
            {
                _hasCache = hasCache;
            }

            public override bool CheckHasCache()
            {
                return _hasCache;
            }
        }

        public class TestableMemoryImageLoader : MemoryImageLoader
        {
            private bool _hasCache = true;

            public void SetHasCache(bool hasCache)
            {
                _hasCache = hasCache;
            }

            public override bool CheckHasCache()
            {
                return _hasCache;
            }
        }
    }
}