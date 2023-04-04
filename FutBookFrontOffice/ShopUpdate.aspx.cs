﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FutBookClassLibrary;

namespace FutBookFrontOffice
{
    public partial class ShopUpdate : System.Web.UI.Page
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

        protected void btnStockSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdateStock_Click(object sender, EventArgs e)
        {

        }
    }
}