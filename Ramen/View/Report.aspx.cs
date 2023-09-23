using Ramen.Report;
using Ramen.Dataset;
using System;
using System.Collections.Generic;
using Ramen.Handler;
using Ramen.Controller;

namespace Ramen.View
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                if (user.RoleId != 1)
                {
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                Response.Redirect("Home.aspx");
            }

            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;
            DataSet1 data = getData(TransactionHeaderHandler.getAllHeader());

            int totalProfit = calculateTotalProfit(data);
            lblTotalProfit.Text = "Total Profit: " + totalProfit.ToString();

            report.SetDataSource(data);
        }

        private DataSet1 getData(List<Header> headers)
        {
            DataSet1 data = new DataSet1();
            var headertable = data.Header;
            var detailtable = data.Detail;

            foreach (Header header in headers)
            {
                var hrow = headertable.NewRow();
                hrow["Id"] = header.Id;
                hrow["CustomerId"] = header.CustomerId;
                hrow["StaffId"] = header.StaffId;
                hrow["Date"] = header.Date;
                

                decimal profitPerHeader = 0;

                foreach (Detail detail in header.Details)
                {
                    var drow = detailtable.NewRow();
                    drow["Headerid"] = detail.Headerid;
                    drow["Ramenid"] = detail.Ramenid;
                    drow["Quantity"] = detail.Quantity;

                    decimal profit = calculateDetailProfit(detail.Ramenid, detail.Quantity);
                    drow["ProfitPerDetail"] = profit;
                    detailtable.Rows.Add(drow);

                    profitPerHeader += profit;
                }
                hrow["ProfitPerHeader"] = profitPerHeader;
                headertable.Rows.Add(hrow);
            }

            CrystalReport1 report = new CrystalReport1();
            report.SetDataSource(data);
            CrystalReportViewer1.ReportSource = report;

            return data;
        }

        private int calculateDetailProfit(int ramenId, int quantity)
        {
            int ramenPrice = Convert.ToInt32(RamenController.getRamenById(ramenId).Price);
            return quantity * ramenPrice;

        }

        private int calculateTotalProfit(DataSet1 data)
        {
            int totalProfit = 0;

            foreach (DataSet1.DetailRow detailRow in data.Detail.Rows)
            {
                int quantity = Convert.ToInt32(detailRow.Quantity);
                int ramenId = Convert.ToInt32(detailRow.Ramenid);
                int ramenPrice = Convert.ToInt32(RamenController.getRamenById(ramenId).Price);
                totalProfit += quantity * ramenPrice;
            }

            return totalProfit;
        }
    }
}