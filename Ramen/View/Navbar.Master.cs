using Ramen.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ramen.View
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            orderRamenBtn.Visible = false;
            manageRamenBtn.Visible = false;
            transactionQueueBtn.Visible = false;
            profileBtn.Visible = false;
            historyBtn.Visible = false;
            reportBtn.Visible = false;
            registerBtn.Visible = false;

            if (Session["user"] == null && Request.Cookies["user_cookie"] == null && Session["guest"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                User user;
                if (Session["user"] == null && Session["guest"] == null)
                {
                    var id = Int32.Parse(Request.Cookies["user_cookie"].Value);
                    user = UserController.getUser(id, null, null);
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }

                if(Session["user"] != null)
                {
                    if (user.RoleId == 1)
                    {
                        manageRamenBtn.Visible = true;
                        transactionQueueBtn.Visible = true;
                        profileBtn.Visible = true;
                        historyBtn.Visible = true;
                        reportBtn.Visible = true;
                        registerBtn.Visible = true;
                    }
                    else if (user.RoleId == 2)
                    {
                        manageRamenBtn.Visible = true;
                        transactionQueueBtn.Visible = true;
                        profileBtn.Visible = true;
                    }
                    else if (user.RoleId == 3)
                    {
                        orderRamenBtn.Visible = true;
                        historyBtn.Visible = true;
                        profileBtn.Visible = true;
                    }
                }
                

            }

        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void orderRamenBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderRamen.aspx");
        }

        protected void manageRamenBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageRamen.aspx");
        }

        protected void transactionQueueBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionQueue.aspx");
        }

        protected void profileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void historyBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("History.aspx");
        }

        protected void reportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Report.aspx");
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            if(Request.Cookies["user_cookie"] != null)
            {
                HttpCookie cookie = Request.Cookies["user_cookie"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Login.aspx");


        }
    }
}