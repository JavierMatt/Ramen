using Ramen.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ramen.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null || Session["guest"] != null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User user = UserController.getUser(0, username, password);

            if (user != null)
            {
                Session["user"] = user;

                if(checkBoxRememberMe.Checked)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = user.Id.ToString();
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }
                

                Response.Redirect("Home.aspx");
            }
            else
            {
                lblErrUsername.Text = "Must be filled and appropriate with the data in the database";
                lblErrPassword.Text = "Must be filled and appropriate with the data in the database";
            }
        }

        protected void btnLoginAsGuest_Click(object sender, EventArgs e)
        {
            Session["guest"] = "guest";
            Response.Redirect("Home.aspx");
        }
    }
}