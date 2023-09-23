using Ramen.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ramen.View
{
    public partial class TransactionDetail : System.Web.UI.Page
    {
        public List<Detail> detaillist = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                if (user.RoleId != 3 && user.RoleId != 1)
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
                string id = Request.QueryString["id"];

                if (string.IsNullOrEmpty(id))
                {
                    Response.Redirect("History.aspx");
                }
                int HeaderId = Convert.ToInt32(id);
                detaillist = TransactionDetailController.getDetailByHeaderId(HeaderId);
                BindGridView();
            }
        }
        private void BindGridView()
        {

            GridView.DataSource = detaillist;
            GridView.DataBind();
        }

        protected string getRamenName(object RamenId)
        {
            if (RamenId != null)
            {
                int id;
                if (int.TryParse(RamenId.ToString(), out id))
                {
                    Raman ramen = RamenController.getRamenById(id);
                    string ramenname = ramen.Name;
                    return ramenname;
                }
            }
            return string.Empty;
        }

    }
}