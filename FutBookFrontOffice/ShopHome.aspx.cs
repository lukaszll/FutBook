using FutBookClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FutBookFrontOffice
{
    public partial class ShopHome : System.Web.UI.Page
    {
        //create an instance of the security class with page level scope
        clsSecurity Sec;

        //find first name of the user
        private string GetFirstNameFromDatabase(int accountNo)
        {
            // Get the first name from the database using the AccountNo
            string firstName = Sec.GetFirstNameByAccountNo(accountNo);

            // Return the first name
            return firstName;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayStockItems();
            }
            //on load get the current state from the session
            Sec = (clsSecurity)Session["Sec"];
            //if the object is null then it needs initialising
            if (Sec == null)
            {
                //initialise the object
                Sec = new clsSecurity();
                //update the session
                Session["Sec"] = Sec;
            }
            //set the state of the linsk based on the cureent state of authentication
            SetLinks(Sec.Authenticated);
            //display user firstName
            if (Sec.Authenticated)
            {
                // Get the AccountNo of the logged-in user from the session
                int accountNo = Convert.ToInt32(Session["AccountNo"]);

                // Fetch the firstName from the database
                string firstName = GetFirstNameFromDatabase(accountNo);

                // Set the text of the lblGreeting
                lblGreeting.Text = $"Hello, {firstName}";
            }
            else
            {
                lblGreeting.Text = "";
            }
        }

        private void SetLinks(Boolean Authenticated)
        {
            ///sets the visiible state of the links based on the authentication state
            ///

            //set the state of the following to not authenticated i.e. they will be visible when not logged in
            hypSignUp.Visible = !Authenticated;
            hypSignIn.Visible = !Authenticated;
            //set the state of the following to authenticated i.e. they will be visible when user is logged in
            hypSignOut.Visible = Authenticated;
        }

        private void DisplayStockItems()
        {
            clsStockCollection stockCollection = new clsStockCollection();
            stockCollection.FetchAll();

            StringBuilder html = new StringBuilder();
            string currentCategory = "";
            foreach (clsStock stockItem in stockCollection.StockList)
            {
                if (currentCategory != stockItem.StockCategory)
                {
                    if (currentCategory != "")
                    {
                        html.Append("</div>");
                    }
                    currentCategory = stockItem.StockCategory;
                    html.Append($"<div class=\"row text-center product-category\" id=\"category-{stockItem.StockCategory.ToLower()}\">");
                }

                html.Append($"<div class=\"col-sm-4\"><div class=\"thumbnail\"><a href=\"ShopDescription.aspx?stockNo={stockItem.StockNo}\"><img src=\"data:image;base64,{Convert.ToBase64String(stockItem.StockImage)}\" alt=\"{stockItem.StockName}\"><p><strong>{stockItem.StockName}</strong></p></a></div></div>");
            }
            html.Append("</div>");

            stockItemsContainer.InnerHtml = html.ToString();
        }
    }
}