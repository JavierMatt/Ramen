using Ramen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Handler
{
    public class UserHandler
    {
        public static string addUser(string username, string email, int roleId, string gender, string password)
        {
            return UserRepository.registerUser(username, email, roleId, gender, password);
        }

        public static User getUser(int id, string username, string password)
        {
            return UserRepository.getUser(id, username, password);
        }

        public static List<User> getUserByRole(int roleId)
        {
            return UserRepository.getUserByRole(roleId);
        }

        public static string updateUser(string username, string email, string gender, string password, string newUsername, string newEmail, string newGender)
        {
            return UserRepository.updateUser(username, email, gender, password, newUsername, newEmail, newGender);
        }

    }
}