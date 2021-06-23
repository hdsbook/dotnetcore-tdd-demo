using System;
using System.Collections.Generic;
using DotnetCoreTDD.DesignPatterns.Facade.Email.SubSystem;

namespace DotnetCoreTDD.DesignPatterns.Facade.Email
{
    public class EmailFacade
    {
        private User _user;
        private EmailSender _emailSender;
        private News _news;

        public EmailFacade()
        {
            _user = new User();
            _emailSender = new EmailSender();
            _news = new News();
        }

        public EmailModel SendNewsNotifyEmail()
        {
            var email = _user.GetSubscribedUserEmails();
            var content = _news.GetNewsContent();
            return _emailSender.SendEmail(email, content);
        }
    }

    /// <summary>
    /// 定義回傳值格式
    /// </summary>
    public class EmailModel : IEquatable<EmailModel>
    {
        public List<string> Emails { get; set; }
        public string Content { get; set; }

        public override bool Equals(object obj)
        {
            var model = obj as EmailModel;
            if (model == null)
            {
                return false;
            }

            return Equals(obj);
        }

        public bool Equals(EmailModel obj)
        {
            return Emails == obj.Emails && Content == obj.Content;
        }
    }
}
