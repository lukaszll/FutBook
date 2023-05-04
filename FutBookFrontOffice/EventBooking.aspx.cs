using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FutBookClassLibrary;
using System.Data.SqlClient;

namespace FutBookFrontOffice
{
    public partial class EventBooking : System.Web.UI.Page
    {
        //create an instance of the security class with page level scope
        clsSecurity Sec;


        private string GetFirstNameFromDatabase(int accountNo)
        {
            // Get the first name from the database using the AccountNo
            string firstName = Sec.GetFirstNameByAccountNo(accountNo);

            // Return the first name
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



        protected void btnBook_Click(object sender, EventArgs e)
        {

            Add();

        }

        void Add()
        {
            // Create an instance of the clsEventBookingCollection
            clsEventBookingCollection MyEventBookingCollection = new clsEventBookingCollection();

            // Validate the data on the web form
            String Error = MyEventBookingCollection.ThisEvent.Valid(
                EventName.Text,
                //EventDate.Text,
                EventDate.SelectedDate.ToString(),

                SpecialRequests.Text,
                Participants.Value
            );

            // If the data is OK, then add it to the object
            if (Error == "")
            {
                // Get the data entered by the user
                MyEventBookingCollection.ThisEvent.EventName = EventName.Text;
                //MyEventBookingCollection.ThisEvent.EventDate = DateTime.Parse(EventDate.Text);
                MyEventBookingCollection.ThisEvent.EventDate = Convert.ToDateTime(EventDate.SelectedDate);

                MyEventBookingCollection.ThisEvent.SpecialRequests = SpecialRequests.Text;
                

                int participants;
                if (int.TryParse(Participants.Value, out participants))
                {
                    MyEventBookingCollection.ThisEvent.NumParticipants = participants;

                    // Calculate the price per person
                    decimal pricePerPerson = CalculatePricePerPerson(participants);

                    // Set the price per person in the event object
                    MyEventBookingCollection.ThisEvent.PricePerPerson = pricePerPerson;

                    // Calculate the total price and set it in the event object
                    MyEventBookingCollection.ThisEvent.TotalPrice = participants * pricePerPerson;

                    // Add the record
                    MyEventBookingCollection.Add();

                    // Display success message
                    lblError.Text = "Event has been added successfully.";
                }
                else
                {
                    lblError.Text = "There was a problem with the number of participants.";
                }
            }
            else
            {
                // Report an error
                lblError.Text = "There was a problem " + Error;
            }
        }

        decimal CalculatePricePerPerson(int participants)
        {
            // Your logic to calculate the price per person based on the number of participants
            // For example, you could use a switch or if-else statement to set the price based on the participant count
            // This is just an example, adjust it according to your pricing rules
            if (participants >= 3 && participants <= 10)
            {
                return 20m;
            }
            else if (participants > 10 && participants <= 30)
            {
                return 18m;
            }
            else
            {
                return 15m;
            }
        }



        //protected void btnBook_Click(object sender, EventArgs e)
        //{
        //    // Create a new instance of the event booking class
        //    clsEventBooking booking = new clsEventBooking();

        //    // Set the values of the properties
        //    booking.EventName = EventName.Text;
        //    booking.Date = DateTime.Parse(Date.Text);
        //    booking.SpecialRequests = SpecialRequests.Text;
        //    //booking.NumParticipants = NumParticipants.Text;

        //    int participants;
        //    if (int.TryParse(Participants.Text, out participants))
        //    {
        //        booking.NumParticipants = participants;

        //        // Calculate the price per person
        //        decimal pricePerPerson = CalculatePricePerPerson(participants);

        //        // Set the price per person in the booking object
        //        booking.PricePerPerson = pricePerPerson;

        //        // Calculate the total price and set it in the booking object
        //        booking.TotalPrice = participants * pricePerPerson;

        //        // Insert the data into the database
        //        bool success = booking.InsertBookingData();

        //        // Display a message to the user
        //        if (success)
        //        {
        //            lblMessage.Text = "Event booking successful!";
        //        }
        //        else
        //        {
        //            lblMessage.Text = "Event booking failed.";
        //        }
        //    }
        //    else
        //    {
        //        lblMessage.Text = "There was a problem with the number of participants.";
        //    }
        //}











        //protected void btnBook_Click(object sender, EventArgs e)
        //{

        //}

        //protected void btnBookEvent_Click(object sender, EventArgs e)
        //{
        //    Add();
        //}

        //void Add()
        //{
        //    //create an instance of the clsEventBookingCollection
        //    clsEventBookingCollection MyEventBookingCollection = new clsEventBookingCollection();
        //    //validate the data on the web form
        //    String Error = MyEventBookingCollection.ThisEvent.Valid(idEmail.Text, idEventName.Text, idSpecialRequests.Text);
        //    //if the data is OK then add it to the object
        //    if (Error == "")
        //    {
        //        //get the data entered by the user

        //        MyEventBookingCollection.ThisEvent.Email = idEmail.Text;
        //        MyEventBookingCollection.ThisEvent.Email = idEventName.Text;
        //        MyEventBookingCollection.ThisEvent.Email = idSpecialRequests.Text;



        //        //add the record
        //        MyEventBookingCollection.Add();
        //        //display success message
        //        lblError.Text = "Event has been added successfully.";
        //    }
        //    else
        //    {
        //        //report an error
        //        lblError.Text = "There was a problem " + Error;
        //    }
        //}

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    //create a new instance of the event booking class
        //    clsEventBooking booking = new clsEventBooking();

        //    //set the values of the properties
        //    booking.EventName = idEventName;
        //    //booking.Email = idEmail;
        //    booking.Date = DateTime.Parse(idDate);
        //    //booking.NumParticipants = int.Parse(idNumParticipants);
        //    //booking.PricePerPerson = decimal.Parse(idPricePerPerson);
        //    //booking.TotalPrice = decimal.Parse(idTotalPrice);
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
