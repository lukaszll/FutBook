using System;
using System.Collections.Generic;

namespace FutBookClassLibrary
{
    public class clsEventBookingCollection
    {
        private List<clsEventBooking> mBookingList = new List<clsEventBooking>();

        public bool AddBooking(string eventName, string email, DateTime date, int numParticipants, decimal pricePerPerson, decimal totalPrice, string specialRequests)
        {
            clsEventBooking newBooking = new clsEventBooking();
            newBooking.EventName = eventName;
            newBooking.Email = email;
            newBooking.Date = date;
            newBooking.NumParticipants = numParticipants;
            newBooking.PricePerPerson = pricePerPerson;
            newBooking.TotalPrice = totalPrice;
            newBooking.SpecialRequests = specialRequests;

            try
            {
                // Save to database
                clsDataConnection DB = new clsDataConnection();
                DB.AddParameter("@EventName", eventName);
                DB.AddParameter("@Email", email);
                DB.AddParameter("@Date", date);
                DB.AddParameter("@NumParticipants", numParticipants);
                DB.AddParameter("@PricePerPerson", pricePerPerson);
                DB.AddParameter("@TotalPrice", totalPrice);
                DB.AddParameter("@SpecialRequests", specialRequests);
                int result = DB.Execute("sproc_AddEventBooking");

                if (result == 1)
                {
                    // Add to collection
                    mBookingList.Add(newBooking);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                // Error occurred while saving to database
                return false;
            }
        }
    }
}
