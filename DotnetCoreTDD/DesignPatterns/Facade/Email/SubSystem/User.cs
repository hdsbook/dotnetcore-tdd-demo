using System;
using System.Collections.Generic;

namespace DotnetCoreTDD.DesignPatterns.Facade.Email.SubSystem
{
    public class User
    {
        public List<string> GetSubscribedUserEmails()
        {
            return new List<string> { "hander@gmail.com" };
        }
    }
}
