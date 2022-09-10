using System.Collections.Generic;
using NUnit.Framework;
using DotnetCoreTDD.DesignPatterns.Facade.Email;
using DotnetCoreTDD.DesignPatterns.Facade.Email.SubSystem;

namespace DotnetCoreTDDTests.DesignPatterns.Facade
{
    [TestFixture()]
    public class EmailFacadeTests
    {
        private EmailModel _expected;

        [SetUp()]
        public void Init()
        {
            _expected = new EmailModel
            {
                Emails = new List<string>() {"hander@gmail.com"},
                Content = "最新消息通知",
            };
        }

        [Test()]
        public void FacadeTest()
        {
            // given facade
            var facade = new EmailFacade();

            // when send email
            var actual = facade.SendNewsNotifyEmail();

            // then assert
            StringAssert.Contains(_expected.Content, actual.Content);
            Assert.AreEqual(_expected.Emails, actual.Emails);
        }

        [Test()]
        public void WithoutFacadeTest()
        {
            // given objects
            var userObj = new User();
            var newsObj = new News();
            var senderObj = new EmailSender();

            // when send email
            var emails = userObj.GetSubscribedUserEmails();
            var content = newsObj.GetNewsContent();
            var actual = senderObj.SendEmail(emails, content);

            // then assert
            StringAssert.Contains(_expected.Content, actual.Content);
            Assert.AreEqual(_expected.Emails, actual.Emails);
        }
    }
}