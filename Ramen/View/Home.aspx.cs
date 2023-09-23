using Ramen.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ramen.View
{
    public partial class Home : System.Web.UI.Page
    {
        public List<User> userlist = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string role = "";
            if(Session["user"] != null)
            {
                User user = (User)Session["user"];
                if(user.RoleId == 1)
                {
                    role = "Admin";
                    userlist = UserController.getUserByRole(2);
                }
                else if(user.RoleId == 2)
                {
                    role = "Staff";
                    userlist = UserController.getUserByRole(3);
                }
                else if (user.RoleId == 3)
                {
                    role = "Member";
                }
            }
            else if(Session["guest"] != null)
            {
                role = "guest";
            }
            lblRole.Text = role;
            GridViewUsers.DataSource = userlist;
            GridViewUsers.DataBind();
        }
    }
}