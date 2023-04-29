﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FutBookClassLibrary;

namespace FutBookFrontOffice
{
    public partial class ShopAdd : System.Web.UI.Page
    {
        //create an instance of the security class with page level scope
        clsSecurity Sec;
        private string GetFirstNameFromDatabase()
        {
            // Fetch the first name from the database and return it
            // Replace this with your actual database fetching code
            string firstName = "John";
            return firstName;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
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

            if (Sec.Authenticated)
            {
                // Fetch the firstName from the database
                string firstName = GetFirstNameFromDatabase();

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
            hypSignIn.Visible = !Authenticated;
            //set the state of the following to authenticated i.e. they will be visible when user is logged in
            hypShop.Visible = Authenticated;
            hypDeleteStock.Visible = Authenticated;
            hypAddStock.Visible = Authenticated;
            hypUpdateStock.Visible = Authenticated;
        }

        protected void btnAddStock_Click(object sender, EventArgs e)
        {
            //create a new instance of the clsStockCollection
            //clsStockCollection MyStockCollection = new clsStockCollection();
            //try to add stock
            //string Outcome = MyStockCollection.Add(idStockName.Text, Convert.ToInt32(idStockQuantity.Text), Convert.ToDecimal(idStockPrice.Text), idStockCategory.Text, idStockImage.FileBytes);
            //report the outcome of the operation
            //lblError.Text = Outcome;
            //add the new record
            Add();
        }

        //function for adding new records
        void Add()
        {
            //create an instance of the clsStockCollection
            clsStockCollection MyStockCollection = new clsStockCollection();
            //validate the data on the web form
            String Error = MyStockCollection.ThisStock.Valid(idStockName.Text, idStockQuantity.Text, idStockPrice.Text, idStockCategory.Text, idStockImage.FileBytes);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                MyStockCollection.ThisStock.StockName = idStockName.Text;
                MyStockCollection.ThisStock.StockCategory = idStockCategory.Text;
                MyStockCollection.ThisStock.StockPrice = Convert.ToDecimal(idStockPrice.Text);
                MyStockCollection.ThisStock.StockQuantity = Convert.ToInt32(idStockQuantity.Text);
                MyStockCollection.ThisStock.StockImage = idStockImage.FileBytes;
                //add the record
                MyStockCollection.Add();
                //display success message
                lblError.Text = "Stock has been added successfully.";
            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered " + Error;
            }
        }
        /* add code here
        void DisplayStock()
        {
            //create an instance of the clsStockCollection
            clsStockCollection AStock = new clsStockCollection();
            //find the record to update
            AStock.ThisStock.Find(StockNo);
            //display the data for this record
            idStockName.Text = AStock.ThisStock.StockName;
            idStockCategory.Text = AStock.ThisStock.StockCategory;
            idStockPrice.Text = AStock.ThisStock.StockPrice.ToString();
            idStockQuantity.Text = AStock.ThisStock.StockQuantity.ToString();
            idStockImage. = AStock.ThisStock.StockImage.ToString();
        }*/

    }
}