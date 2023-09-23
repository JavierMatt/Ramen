using Ramen.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ramen.View
{
    public partial class ManageRamen : System.Web.UI.Page
    {
        public List<Raman> ramenlist = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] != null)
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


            ramenlist = RamenController.getAllRamen();

            if (!IsPostBack) 
            {
                BindGridView(); 
            }
        }

        private void BindGridView()
        {
            ramenlist = RamenController.getAllRamen();
            GridView.DataSource = ramenlist;
            GridView.DataBind();
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Update")
            {
                Response.Redirect("UpdateRamen.aspx?id=" + Id);
            }
            else if (e.CommandName == "Delete")
            {
                RamenController.deleteRamen(Id);
            }
            BindGridView();

        }

        protected string getMeatName(object MeatId)
        {
            if (MeatId != null)
            {
                int id;
                if (int.TryParse(MeatId.ToString(), out id))
                {
                    string meatName = MeatController.getMeatName(id);
                    return meatName;
                }
            }
            return string.Empty;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertRamen.aspx");
        }
    }
}