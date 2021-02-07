using System;
namespace DotnetCoreTDD.DesignPatterns.Facade.Email.SubSystem
{
    public class User
    {
        public string GetUserEmail(string account)
        {
            return $"{account}@gmail.com";
        }
    }
}
