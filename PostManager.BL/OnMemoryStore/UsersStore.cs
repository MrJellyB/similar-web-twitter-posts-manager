using System;
using System.Collections.Generic;
using System.Text;

namespace PostManager.BL.OnMemoryStore
{
    public struct User
    {
        string FullName;
    }

    public interface IUsers
    {
        void Add(User user, string userId);
    }

    public class Users : IUsers
    {
        public Dictionary<string, User> UsersList { get; private set; }

        public void Add(User user, string userId)
        {
            try
            {
                lock(UsersList)
                {
                    UsersList.Add(userId, user);
                }
            }
            catch (ArgumentException)
            {

            }
        }
    }
}
