using DotnetCoreTDD.DesignPatterns.Composite.Form;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.Composite
{
    [TestFixture]
    public class FormTests
    {
        [Test]
        public void Print_Works_Correctly()
        {
            // given 測試表單、預期的列印結果
            var form = new Form("測試表單")
                .Add(new QuestionGroup("第一部分、選擇題")
                    .Add(new RadioQuestion("請問您的年齡？")
                        .Add(new QuestionOption("18歲以下"))
                        .Add(new QuestionOption("19-28歲"))
                        .Add(new QuestionOption("29歲以上"))
                    )
                    .Add(new RadioQuestion("您對本活動主題安排之滿意程度？")
                        .Add(new QuestionOption("非常滿意"))
                        .Add(new QuestionOption("滿意"))
                        .Add(new QuestionOption("尚可"))
                        .Add(new QuestionOption("不滿意"))
                        .Add(new QuestionOption("非常不滿意"))
                    )
                )
                .Add(new QuestionGroup("第二部分、多選題")
                    .Add(new RadioQuestion("如何得知活動？")
                        .Add(new QuestionOption("臉書動態牆"))
                        .Add(new QuestionOption("親朋好友推薦"))
                        .Add(new QuestionOption("其它方式"))
                    )
                )
                .Add(new QuestionGroup("第三部份、回饋")
                    .Add(new TextAreaQuestion("其它建議")
                    )
                );

            var expected =
                "【表單】測試表單\n" +
                "\t【題組】第一部分、選擇題\n" +
                "\t\t【題目(選擇題)】請問您的年齡？\n" +
                "\t\t\t【選項】18歲以下\n" +
                "\t\t\t【選項】19-28歲\n" +
                "\t\t\t【選項】29歲以上\n" +
                "\t\t【題目(選擇題)】您對本活動主題安排之滿意程度？\n" +
                "\t\t\t【選項】非常滿意\n" +
                "\t\t\t【選項】滿意\n" +
                "\t\t\t【選項】尚可\n" +
                "\t\t\t【選項】不滿意\n" +
                "\t\t\t【選項】非常不滿意\n" +
                "\t【題組】第二部分、多選題\n" +
                "\t\t【題目(選擇題)】如何得知活動？\n" +
                "\t\t\t【選項】臉書動態牆\n" +
                "\t\t\t【選項】親朋好友推薦\n" +
                "\t\t\t【選項】其它方式\n" +
                "\t【題組】第三部份、回饋\n" +
                "\t\t【題目(簡答題)】其它建議\n";

            // when print 表單
            var actual = form.Print();

            // then assert
            Assert.AreEqual(expected, actual);
        }
    }
}