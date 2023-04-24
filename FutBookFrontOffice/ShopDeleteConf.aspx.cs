using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FutBookClassLibrary;

namespace FutBookFrontOffice
{
    public partial class ShopDeleteConf : System.Web.UI.Page
    {
        //var to store the primary key value of the record to be deleted
        Int32 StockNo;

        protected void Page_Load(object sender, EventArgs e)
        {
            //get the number of the stock to be deleted from the session object
            StockNo = Convert.ToInt32(Session["StockNo"]);
        }

        //function to delete the selected record
        void DeleteStock()
        {
            //create a new instance of the clsStockCollection
            clsStockCollection MyStock = new clsStockCollection();
            //find the record to be deleted
            MyStock.ThisStock.Find(StockNo);
            //delete the record
            MyStock.Delete();
        }

        protected void btnDeleteStock_Click(object sender, EventArgs e)
        {
            //delete the record
            DeleteStock();
            //redirect back to the previous page
            Response.Redirect("ShopDelete.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //redirect to previous page
            Response.Redirect("ShopDelete.aspx");
        }

    }
}