using DotnetCoreTDD.DesignPatterns.Facade.Email;

namespace DotnetCoreTDD.DesignPatterns.Facade.Email.SubSystem
{
    /// <summary>
    /// 寄信物件
    /// </summary>
    public class EmailSender
    {
        public EmailModel SendEmail(string email, string content)
        {
            return new EmailModel
            {
                Email = email,
                Content = content,
            };
        }
    }
}
