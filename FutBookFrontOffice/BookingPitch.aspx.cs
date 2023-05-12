using FutBookClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FutBookFrontOffice
{
    public partial class BookingPitch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged in
            if (Session["AccountNo"] == null)
            {
                // Redirect the user to the login page
                Response.Redirect("SignIn.aspx");
            }
            if (!IsPostBack)
            {
                // Add the today date and the next 7 days to the dropdown list
                for (int i = 0; i < 8; i++)
                {
                    ddlDate.Items.Add(DateTime.Today.AddDays(i).ToString("dd-MMMM"));
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = DateTime.Parse(ddlDate.SelectedValue);
            TimeSpan selectedTime = TimeSpan.Parse(DropDownList1.SelectedValue);

            if (selectedDate == DateTime.Today && selectedTime < DateTime.Now.TimeOfDay)
            {
                lblError.Text = "You cannot select a time that has already passed today.";
                return;
            }

           try
            {
            clsBookingPitch booking = new clsBookingPitch();
            booking.BookingPitchDate = DateTime.Parse(ddlDate.SelectedValue);
            booking.BookingPitchTime = TimeSpan.Parse(DropDownList1.SelectedValue);
            booking.AccountNo = (int)Session["AccountNo"];
            booking.AddBooking();
            Response.Redirect("EventBooking.aspx"); 
            }


                catch (SqlException ex)
            {
                if (ex.Number == 50000)
                {
                    lblError.Text = ex.Message;
                }
                else
                {
                    // Handle other SQL exceptions
                    lblError.Text = "All pitches are already booked for the selected date and time";
                }
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Nothing
        }

    }
}
