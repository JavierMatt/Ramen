using Ramen.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ramen.View
{
    public partial class Profile : System.Web.UI.Page
    {
        public User user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                 Response.Redirect("Home.aspx");
            }
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void BindGridView()
        {
            user = (User)Session["user"];
            List<User> showUser = new List<User> { user };
            GridViewProfile.DataSource = showUser;
            GridViewProfile.DataBind();
        }


        protected void btnChangeProfileInformation_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string gender = null;
            if (radioBtnGenderMale.Checked) gender = "Male";
            else if (radioBtnGenderFemale.Checked) gender = "Female";
            User user = (User)Session["user"];

            List<string> output = UserController.updateUser(user.Username, user.Email, user.Gender, user.Password, username, email, gender, password);
            lblErrUsername.Text = output[0];
            lblErrEmail.Text = output[1];
            lblErrGender.Text = output[2];
            lblErrPassword.Text = output[3];
            BindGridView(); 
        }
    }
  
}