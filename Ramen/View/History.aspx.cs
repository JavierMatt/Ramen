using Ramen.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ramen.View
{
    public partial class History : System.Web.UI.Page
    {
        public List<Header> headerlist = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                if (user.RoleId != 3 && user.RoleId != 1)
                {
                    Response.Redirect("Home.aspx");
                }
                if(user.RoleId == 1)
                {
                    headerlist = TransactionHeaderController.getAllHeader();
                }
                else if (user.RoleId == 3)
                {
                    headerlist = TransactionHeaderController.getHeaderByCustomerId(user.Id);
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
            
            GridView.DataSource = headerlist;
            GridView.DataBind();
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("TransactionDetail.aspx?id=" + Id);


            BindGridView();
        }

        protected void btnDetail_Click(object sender, EventArgs e)
        {

        }

    }
}