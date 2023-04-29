using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FutBookClassLibrary;

namespace FutBookFrontOffice
{
    public partial class EventBooking : System.Web.UI.Page
    {
        //create an instance of the security class with page level scope
        clsSecurity Sec;


        private string GetFirstNameFromDatabase()
        {
            // Fetch the first name from the database and return it
            // Replace this with your actual database fetching code
            string firstName = "Bob";
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

        protected void btnBookEvent_Click(object sender, EventArgs e)
        {
            Add();
        }

        void Add()
        {
            //create an instance of the clsEventBookingCollection
            clsEventBookingCollection MyEventBookingCollection = new clsEventBookingCollection();
            //validate the data on the web form
            String Error = MyEventBookingCollection.ThisEvent.Valid(idFirstName.Text, idSurname.Text, idEmail.Text); /*idPricePerPerson.Text, idNumParticipants.Text*/
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                MyEventBookingCollection.ThisEvent.FirstName = idFirstName.Text;
                MyEventBookingCollection.ThisEvent.Surname = idSurname.Text;
                MyEventBookingCollection.ThisEvent.Email = idEmail.Text;

                //MyEventBookingCollection.ThisEvent.NumParticipants = Convert.ToInt32(idNumParticipants.Text);

                //MyEventBookingCollection.ThisEvent.PricePerPerson = Convert.ToInt32(idPricePerPerson.Text);


                //add the record
                MyEventBookingCollection.Add();
                //display success message
                lblError.Text = "Event has been added successfully.";
            }
            else
            {
                //report an error
                lblError.Text = "There was a problem " + Error;
            }
        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    //create a new instance of the event booking class
        //    clsEventBooking booking = new clsEventBooking();

        //    //set the values of the properties
        //    booking.EventName = idEventName;
        //    booking.Email = idEmail;
        //    booking.Date = DateTime.Parse(idDate);
        //    booking.NumParticipants = int.Parse(idNumParticipants);
        //    booking.PricePerPerson = decimal.Parse(idPricePerPerson);
        //    booking.TotalPrice = decimal.Parse(idTotalPrice);
        //    booking.SpecialRequests = idSpecialRequests;

        //    //insert the data into the database
        //    bool success = booking.InsertBookingData();

        //    //display a message to the user
        //    if (success)
        //    {
        //        lblMessage.Text = "Event booking successful!";
        //    }
        //    else
        //    {
        //        lblMessage.Text = "Event booking failed.";
        //    }
        //}
    }
}
