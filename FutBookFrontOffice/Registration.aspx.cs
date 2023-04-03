﻿using FutBookClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FutBookFrontOffice
{
    public partial class Registration : System.Web.UI.Page
    {

        //create a copy of the security object with page level scope
        clsSecurity Sec;
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

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            //create a new instance of the security class
            clsSecurity Sec = new clsSecurity();
            //try to sign up using the supplied credentials
            string Outcome = Sec.SignUp(idEmail.Text, idPassword1.Text, idPassword2.Text, false, idFirstName.Text, idSurname.Text, Convert.ToInt64(idPhoneNo.Text), Convert.ToInt32(idHouseNo.Text), idStreet.Text, idCity.Text, idPostCode.Text);
            //report the outcome of the operation
            lblError.Text = Outcome;
            //store the object in the session objec for other pages to access
            Session["Sec"] = Sec;
        }
    }
}