using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ramen.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ramen.View
{
    public partial class OrderRamen : System.Web.UI.Page
    {
        public class CartItem
        {
            public Raman Ramen { get; set; }
            public int Quantity { get; set; }
        }

        public List<Raman> ramenlist = null;
        public List<CartItem> CartItems = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                if (user.RoleId != 3)
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
                CartItems = Session["CartItems"] as List<CartItem>;
                BindGridView();
                BindGridViewCart();
            }
        }

        private void BindGridView()
        {
            ramenlist = RamenController.getAllRamen();
            GridView.DataSource = ramenlist;
            GridView.DataBind();
        }
        private void BindGridViewCart()
        {
            CartGridView.DataSource = CartItems;
            CartGridView.DataBind();
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int ramenId = Convert.ToInt32(e.CommandArgument);

            Raman selectedRamen = RamenController.getRamenById(ramenId);
            if (selectedRamen != null)
            {
                if (Session["CartItems"] == null)
                {
                    CartItems = new List<CartItem>();
                }
                else
                {
                    CartItems = (List<CartItem>)Session["CartItems"];
                }

                CartItem existingCartItem = CartItems.FirstOrDefault(item => item.Ramen == selectedRamen);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity++;
                }
                else
                {
                    CartItems.Add(new CartItem
                    {
                        Ramen = selectedRamen,
                        Quantity = 1
                    });

                }

                Session["CartItems"] = CartItems;
            }
            BindGridViewCart();
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {

            
        }

        protected string getMeatName(object MeatId)
        {
            if(MeatId != null)
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
        protected string getMeatNameSession(CartItem cartItem)
        {
            if (cartItem != null && cartItem.Ramen != null)
            {
                int meatId = cartItem.Ramen.MeatId;
                string meatName = MeatController.getMeatName(meatId);
                return meatName;
            }
            return string.Empty;
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            CartItems = (List<CartItem>)Session["CartItems"];
            
            User user = (User)Session["user"];
            int customerId = user.Id;
            DateTime currentDate = DateTime.Today;
            Session.Remove("CartItems");
            int headerId = TransactionHeaderController.insertHeader(customerId, currentDate);
            foreach (CartItem cartItem in CartItems)
            {
                int ramenId = cartItem.Ramen.Id;
                int quantity = cartItem.Quantity;
                TransactionDetailController.insertDetail(headerId, ramenId, quantity);
            }
            CartItems = null;
            BindGridViewCart();
        }

        protected void btnClearCart_Click(object sender, EventArgs e)
        {
            Session.Remove("CartItems");
            CartItems = null;
            BindGridViewCart();
        }
    }
}