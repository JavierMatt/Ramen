using Ramen.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ramen.View
{
    public partial class InsertRamen : System.Web.UI.Page
    {
        public List<Meat> meatlist = null;
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
            meatlist = MeatController.getAllMeat();

            if (!IsPostBack)
            {
                meatlist = MeatController.getAllMeat();
                BindMeatList();
            }
        }

      
        protected void BindMeatList()
        {
            ddlMeat.DataSource = meatlist;
            ddlMeat.DataTextField = "Name";
            ddlMeat.DataValueField = "Id";
            ddlMeat.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int meatId = Convert.ToInt32(ddlMeat.SelectedValue);
            string broth = txtBroth.Text;
            string price = txtPrice.Text;

            List<string> output = RamenController.insertRamen(name, meatId, broth, price);
            lblErrName.Text = output[0];
            lblErrBroth.Text = output[1];
            lblErrPrice.Text = output[2];
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageRamen.aspx");
        }
    }
}