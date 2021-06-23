using System.Collections.Generic;
using DotnetCoreTDD.DesignPatterns.Facade.Email;

namespace DotnetCoreTDD.DesignPatterns.Facade.Email.SubSystem
{
    /// <summary>
    /// 寄信物件
    /// </summary>
    public class EmailSender
    {
        public EmailModel SendEmail(List<string> emails, string content)
        {
            return new EmailModel
            {
                Emails = emails,
                Content = content,
            };
        }
    }
}
