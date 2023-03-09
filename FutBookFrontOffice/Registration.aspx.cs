using FutBookClassLibrary;
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            //create a new instance of the security class
            clsSecurity Sec = new clsSecurity();
            //try to sign up using the supplied credentials
            string Outcome = Sec.SignUp(idEmail.Text, idPassword1.Text, idPassword2.Text, false, idFirstName.Text, idSurname.Text, Convert.ToInt64(idPhoneNo.Text));
            //report the outcome of the operation
            lblError.Text = Outcome;
            //store the object in the session objec for other pages to access
            Session["Sec"] = Sec;
        }
    }
}