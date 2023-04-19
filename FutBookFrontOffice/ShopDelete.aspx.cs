using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FutBookClassLibrary;

namespace FutBookFrontOffice
{
    public partial class ShopDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                //update the list box
                DisplayStock();
            }
        }

        //display all stock
        void DisplayStock()
        {
            //create an instance of the clsStockCollection
            clsStockCollection Stock = new clsStockCollection();
            //set the data source to the list of stock in the collection
            idStockList.DataSource = Stock.StockList;
            //set the name of the primary key
            idStockList.DataValueField = "StockNo";
            //set the data field to display
            idStockList.DataTextField = "StockName";
            //bind the data to the list
            idStockList.DataBind();
        }

        protected void btnDeleteStock_Click(object sender, EventArgs e)
        {
            //var to store the primary key value of the record to be deleted
            Int32 StockNo;
            //if a record has been selected from the list
            if (idStockList.SelectedIndex != -1)
            {
                //get the primary key value of the record to delete
                StockNo = Convert.ToInt32(idStockList.SelectedValue);
                //store the data in the session object
                Session["StockNo"] = StockNo;
                //redirect to the delete page
                Response.Redirect("ShopDeleteConf.aspx");
            }
            else //if no record has been selected
            {
                //display an error
                lblError.Text = "Please select a record to delete from the list";
            }
        }

        protected void btnStockSearch_Click(object sender, EventArgs e)
        {

        }
    }
}