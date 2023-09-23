using Ramen.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Controller
{
    public class UserController
    {
        public static List<string> addUser(string username, string email, int roleId, string gender, string password, string confirmPassword)
        {
            string errMessageUsername = "";
            string errMessageEmail = "";
            string errMessageRole = "";
            string errMessageGender = "";
            string errMessagePassword = "";
            string errMessageConfirmPassword = "";
            bool isRegisterValid = true;

            if (username == "")
            {
                errMessageUsername = "Username must be filled";
                isRegisterValid = false;
            }
            else if (username.Length < 5 || username.Length > 15 || !username.All(c => Char.IsLetter(c) || c == ' '))
            {
                errMessageUsername = "Username length must be between 5 and 15 and alphabet with space only";
                isRegisterValid = false;
            }

            if (email == "")
            {
                errMessageEmail = "Email must be filled";
                isRegisterValid = false;
            }
            else if (!email.EndsWith(".com"))
            {
                errMessageEmail = "Email must end with '.com' ";
                isRegisterValid = false;
            }

            if (roleId == 0)
            {
                errMessageRole = "Role must be choosen";
                isRegisterValid = false;
            }

            if (gender == null)
            {
                errMessageGender = "Gender must be choosen";
                isRegisterValid = false;
            }

            if (password == "")
            {
                errMessagePassword = "Password must be filled";
                isRegisterValid = false;
            }

            if (confirmPassword == "")
            {
                errMessageConfirmPassword = "Confirm password must be filled";
                isRegisterValid = false;
            }
            else if (confirmPassword != password)
            {
                errMessageConfirmPassword = "Must be the same with confirm password";
                isRegisterValid = false;
            }

            List<string> output = new List<string> { errMessageUsername, errMessageEmail, errMessageRole, errMessageGender, errMessagePassword, errMessageConfirmPassword };
            if (isRegisterValid == true)
            {
                UserHandler.addUser(username, email, roleId, gender, password);
            }
            return output;
        }

        public static User getUser(int id, string username, string password)
        {
            return UserHandler.getUser(id, username, password);
        }

        public static List<User> getUserByRole(int roleId)
        {
            return UserHandler.getUserByRole(roleId);
        }

        public static List<string> updateUser(string username, string email, string gender, string password, string newUsername, string newEmail, string newGender, string newPassword)
        {
            string errMessageUsername = "";
            string errMessageEmail = "";
            string errMessageGender = "";
            string errMessagePassword = "";
            bool isRegisterValid = true;

            if (newUsername == "")
            {
                errMessageUsername = "Username must be filled";
                isRegisterValid = false;
            }
            else if (newUsername.Length < 5 || newUsername.Length > 15 || !newUsername.All(c => Char.IsLetter(c) || c == ' '))
            {
                errMessageUsername = "Username length must be between 5 and 15 and alphabet with space only";
                isRegisterValid = false;
            }

            if (newEmail == "")
            {
                errMessageEmail = "Email must be filled";
                isRegisterValid = false;
            }
            else if (!newEmail.EndsWith(".com"))
            {
                errMessageEmail = "Email must end with '.com' ";
                isRegisterValid = false;
            }

            if (newGender == null)
            {
                errMessageGender = "Gender must be choosen";
                isRegisterValid = false;
            }

            if (password == "")
            {
                errMessagePassword = "Password must be filled";
                isRegisterValid = false;
            }
            if (password != newPassword)
            {
                errMessagePassword = "Password be the same with the current password";
                isRegisterValid = false;
            }

            List<string> output = new List<string> { errMessageUsername, errMessageEmail, errMessageGender, errMessagePassword};
            if (isRegisterValid == true)
            {   
                UserHandler.updateUser(username, email, gender, password, newUsername, newEmail, newGender);
            }
            return output;
        }
    }
}