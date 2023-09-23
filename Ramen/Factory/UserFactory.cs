using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Factory
{
    public class UserFactory
    {
        public static User createUser(string username, string email, int roleId, string gender, string password)
        {
            User newUser = new User();

            newUser.Username = username;
            newUser.Email = email;
            newUser.RoleId = roleId;
            newUser.Gender = gender;
            newUser.Password = password;

            return newUser;
        }
    }
}