using DotnetCoreTDD.DesignPatterns.Composite.FileSystem;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.Composite
{
    [TestFixture]
    public class FileSystemTests
    {
        [Test]
        public void Print_Works_Correctly()
        {
            // given 預期的列印結果
            var expected = "D槽\n" +
                           "\t音樂\n" +
                           "\t\t周杰倫\n" +
                           "\t\t\t告白氣球.mp3\n" +
                           "\t\t\t聽媽媽的話.mp3\n" +
                           "\t\t盧廣仲\n" +
                           "\t\t\t魚仔.mp3\n" +
                           "\t\t\t100種生活.mp3\n" +
                           "\t書籍\n" +
                           "\t\t哈利波特.pdf\n" +
                           "\t\t航海王.epub\n";
            
            // given 建立好的資料夾、檔案
            var rootDir = new Directory("D槽");

            var musicDir = new Directory("音樂");
            var bookDir = new Directory("書籍");
            rootDir.Add(musicDir);
            rootDir.Add(bookDir);

            var musicJayDir = new Directory("周杰倫");
            musicDir.Add(musicJayDir);
            musicJayDir.Add(new File("告白氣球.mp3"));
            musicJayDir.Add(new File("聽媽媽的話.mp3"));

            var musicCrowdDir = new Directory("盧廣仲");
            musicDir.Add(musicCrowdDir);
            musicCrowdDir.Add(new File("魚仔.mp3"));
            musicCrowdDir.Add(new File("100種生活.mp3"));

            bookDir.Add(new File("哈利波特.pdf"));
            bookDir.Add(new File("航海王.epub"));

            // when 印出資料夾、檔案結構
            var print = rootDir.Print();

            // then 驗證預期結果正確
            Assert.AreEqual(expected, print);
        }
    }
}