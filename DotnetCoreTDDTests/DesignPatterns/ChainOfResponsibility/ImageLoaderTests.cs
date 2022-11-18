using DotnetCoreTDD.DesignPatterns.ChainOfResponsibility;
using FluentAssertions;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.ChainOfResponsibility
{
    [TestFixture]
    public class ImageLoaderTests
    {
        [Test]
        public void GivenLoaders_WhenImageNotExist_ReturnsNull()
        {
            // given image url
            var imageUrl = "image url";
            
            // given loaders
            var memory = new MemoryImageLoader();
            var disk = new DiskImageLoader();

            // when 設定載入順序為： memory -> disk
            memory.SetNext(disk);

            // when load image
            var image = memory.Display(imageUrl);

            // then
            image.Should().BeNull();
        }

        [Test]
        public void GivenLoaders_WhenImageInMemory_ReturnsImageFromMemory()
        {
            // given image url
            var imageUrl = "image url";
            
            // given loaders
            var memory = new MemoryImageLoader();
            var disk = new DiskImageLoader();
            
            // when 圖片存在 memory cache
            memory.PutCache(imageUrl);

            // when 設定載入順序為： memory -> disk
            memory.SetNext(disk);

            // when load image
            var image = memory.Display(imageUrl);

            // then
            image.Should().Be("image from memory");
        }

        [Test]
        public void GivenLoaders_WhenImageInDisk_ReturnsImageFromDisk()
        {
            // given image url
            var imageUrl = "image url";
            
            // given loaders
            var memory = new MemoryImageLoader();
            var disk = new DiskImageLoader();
            
            // when 使圖片存在 disk
            disk.PutCache(imageUrl);

            // when 設定載入順序為： memory -> disk
            memory.SetNext(disk);

            // when load image
            var image = memory.Display(imageUrl);

            // then 預期圖片在disk
            image.Should().Be("image from disk");

            // when 再次顯示圖片
            var imageAgain = memory.Display(imageUrl);

            // then 第二次應該從記憶體取得
            imageAgain.Should().Be("image from memory");
        }
    }
}