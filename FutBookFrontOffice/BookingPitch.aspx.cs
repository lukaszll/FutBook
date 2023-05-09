using FutBookClassLibrary;
using System;
using System.Collections.Generic;
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
                    ddlDate.Items.Add(DateTime.Today.AddDays(i).ToString("yyyy-MM-dd"));
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
            else
            {
                clsBookingPitch booking = new clsBookingPitch();
                booking.BookingPitchDate = DateTime.Parse(ddlDate.SelectedValue);
                booking.BookingPitchTime = TimeSpan.Parse(DropDownList1.SelectedValue);
                booking.AccountNo = (int)Session["AccountNo"];
                booking.PitchNo = int.Parse(Request.QueryString["PitchNo"]);
                booking.AddBooking();

                // Redirect to the booking confirmation page
                Response.Redirect("EventBooking.aspx");
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the selection change event here
        }

    }
}