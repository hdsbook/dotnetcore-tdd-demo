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
            var actual = (new EmailFacade()).SendNewsNotifyEmail(_account);

            Assert.AreEqual(_expected.Content, actual.Content);
            Assert.AreEqual(_expected.Email, actual.Email);
            Assert.AreEqual(_expected, actual);
        }

        [Test()]
        public void WithoutFacadeTest()
        {
            var email = (new User()).GetUserEmail(_account);
            var content = (new News()).GetNewsNotifyContent();
            var actual = (new EmailSender()).SendEmail(email, content);

            Assert.AreEqual(_expected.Content, actual.Content);
            Assert.AreEqual(_expected.Email, actual.Email);
            Assert.AreEqual(_expected, actual);
        }
    }
}