using Ramen.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ramen.View
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                if (user.RoleId != 1)
                {
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string gender = null;
            if (radioBtnGenderMale.Checked) gender = "Male";
            else if (radioBtnGenderFemale.Checked) gender = "Female";
            int roleId = 0;
            if (radioBtnRoleStaff.Checked) roleId = 2;
            else if (radioBtnRoleMember.Checked) roleId = 3;

            List<string> output = UserController.addUser(username, email, roleId, gender, password, confirmPassword);
            lblErrUsername.Text = output[0];
            lblErrEmail.Text = output[1];
            lblErrRole.Text = output[2];
            lblErrGender.Text = output[3];
            lblErrPassword.Text = output[4];
            lblErrConfirmPassword.Text = output[5];
    
        }
    }
}