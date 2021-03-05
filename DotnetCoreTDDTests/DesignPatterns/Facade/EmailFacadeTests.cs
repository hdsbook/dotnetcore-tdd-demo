using NUnit.Framework;
using DotnetCoreTDD.DesignPatterns.Facade.Email;
using DotnetCoreTDD.DesignPatterns.Facade.Email.SubSystem;

namespace DotnetCoreTDDTests.DesignPatterns.Facade
{
    [TestFixture()]
    public class EmailFacadeTests
    {
        private string _account;
        private EmailModel _expected;

        [SetUp()]
        public void Init()
        {
            _account = "hander";
            _expected = new EmailModel
            {
                Email = $"{_account}@gmail.com",
                Content = "最新消息通知",
            };
        }

        [Test()]
        public void FacadeTest()
        {
            // given facade
            var facade = new EmailFacade();

            // when send email
            var actual = facade.SendNewsNotifyEmail(_account);

            // then assert
            Assert.AreEqual(_expected.Content, actual.Content);
            Assert.AreEqual(_expected.Email, actual.Email);
            Assert.AreEqual(_expected, actual);
        }

        [Test()]
        public void WithoutFacadeTest()
        {
            // given objects
            var userObj = new User();
            var newsObj = new News();
            var senderObj = new EmailSender();

            // when send email
            var email = userObj.GetUserEmail(_account);
            var content = newsObj.GetNewsNotifyContent();
            var actual = senderObj.SendEmail(email, content);

            // then assert
            Assert.AreEqual(_expected.Content, actual.Content);
            Assert.AreEqual(_expected.Email, actual.Email);
            Assert.AreEqual(_expected, actual);
        }
    }
}