using CYX.Interface;
using System;

namespace CYX.Class
{
    public class UserService : IUserService
    {
        public void Add()
        {
            Console.WriteLine("a user added.");
        }
    }
}
