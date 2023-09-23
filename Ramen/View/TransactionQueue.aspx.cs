using Ramen.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ramen.View
{
    public partial class TransactionQueue : System.Web.UI.Page
    {
        public List<Header> headerlist = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                if (user.RoleId != 1 && user.RoleId != 2)
                {
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                Response.Redirect("Home.aspx");
            }    

            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            headerlist = TransactionHeaderController.getAllUnhandledHeader();
            GridView.DataSource = headerlist;
            GridView.DataBind();
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument);
            User user = (User)Session["user"];
            int staffId = user.Id;

            TransactionHeaderController.handleHeader(Id, staffId);

            BindGridView();
        }

        protected void btnHandleHeader_Click(object sender, EventArgs e)
        {

        }
    }
}