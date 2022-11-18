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
            // given testable loaders
            var memory = new TestableMemoryImageLoader();
            var disk = new TestableDiskImageLoader();
            
            // when 改寫 CheckHasCache 行為，使圖片存在 memory cache
            memory.SetHasImageCache(true);
            disk.SetHasImageCache(false);

            // when 設定載入順序為： memory -> disk
            memory.SetNext(disk);

            // when load image
            var image = memory.Load();

            // then
            image.Should().Contain("image from memory cache");
        }
        
        [Test]
        public void GivenLoaders_WhenImageInDisk_ReturnsImageFromDisk()
        {
            // given testable loaders
            var memory = new TestableMemoryImageLoader();
            var disk = new TestableDiskImageLoader();
            
            // when 改寫 CheckHasCache 行為，使圖片存在 disk
            memory.SetHasImageCache(false);
            disk.SetHasImageCache(true);

            // when 設定載入順序為： memory -> disk
            memory.SetNext(disk);

            // when load image
            var image = memory.Load();

            // then
            image.Should().Contain("image from disk");
        }
        
        [Test]
        public void GivenLoaders_WhenImageNotExist_ReturnsNull()
        {
            // given testable loaders
            var memory = new TestableMemoryImageLoader();
            var disk = new TestableDiskImageLoader();
            
            // when 改寫 CheckHasCache 行為，使圖片不存在 memory，也不存在於 disk
            memory.SetHasImageCache(false);
            disk.SetHasImageCache(false);

            // when 設定載入順序為： memory -> disk
            memory.SetNext(disk);

            // when load image
            var image = memory.Load();

            // then
            image.Should().BeNull();
        }


        public class TestableDiskImageLoader : DiskImageLoader
        {
            private bool _hasImageCache = true;

            public void SetHasImageCache(bool hasImageCache)
            {
                _hasImageCache = hasImageCache;
            }

            public override bool HasImageCache()
            {
                return _hasImageCache;
            }
        }

        public class TestableMemoryImageLoader : MemoryImageLoader
        {
            private bool _hasImageCache = true;

            public void SetHasImageCache(bool hasCache)
            {
                _hasImageCache = hasCache;
            }

            public override bool HasImageCache()
            {
                return _hasImageCache;
            }
        }
    }
}