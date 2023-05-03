using System;

namespace FutBookClassLibrary
{
    public class clsEventBooking
    {
        private int mBookingNo;
        public int BookingNo
        {
            get { return mBookingNo; }
            set { mBookingNo = value; }
        }

        private string mEventName;
        public string EventName
        {
            get { return mEventName; }
            set { mEventName = value; }
        }

        private DateTime mDate;
        public DateTime Date
        {
            get { return mDate; }
            set { mDate = value; }
        }

        private string mSpecialRequests;
        public string SpecialRequests
        {
            get { return mSpecialRequests; }
            set { mSpecialRequests = value; }
        }

        private int mNumParticipants;
        public int NumParticipants
        {
            get { return mNumParticipants; }
            set { mNumParticipants = value; }
        }

        private decimal mPricePerPerson;
        public decimal PricePerPerson
        {
            get { return mPricePerPerson; }
            set { mPricePerPerson = value; }
        }

        private decimal mTotalPrice;
        public decimal TotalPrice
        {
            get { return mTotalPrice; }
            set { mTotalPrice = value; }
        }


        public bool Find(int BookingNo)
        {
            // Create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();

            // Add the parameter for the booking number to search for
            DB.AddParameter("@BookingNo", BookingNo);

            // Execute the stored procedure
            DB.Execute("sproc_tblEventBooking_FilterByBookingNo");

            // If one record is found (there should be either one or zero)
            if (DB.Count == 1)
            {
                // Copy the data from the database to the private data members
                mBookingNo = Convert.ToInt32(DB.DataTable.Rows[0]["BookingNo"]);
                mEventName = Convert.ToString(DB.DataTable.Rows[0]["EventName"]);
                mDate = Convert.ToDateTime(DB.DataTable.Rows[0]["Date"]);
                mSpecialRequests = Convert.ToString(DB.DataTable.Rows[0]["SpecialRequests"]);
                mNumParticipants = Convert.ToInt32(DB.DataTable.Rows[0]["NumParticipants"]);
                mPricePerPerson = Convert.ToDecimal(DB.DataTable.Rows[0]["PricePerPerson"]);
                mTotalPrice = Convert.ToDecimal(DB.DataTable.Rows[0]["TotalPrice"]);

                // Return that everything worked OK
                return true;
            }
            // If no record was found
            else
            {
                // Return false indicating problem
                return false;
            }
        }


        public string Valid(string EventName, string Date, string SpecialRequests, string NumParticipants)
        {
            // Create a string variable to store the error
            String Error = "";

            // Create a variable for the number of participants
            int numParticipants;

            // If the EventName is blank
            if (EventName.Length == 0)
            {
                // Record the error
                Error = Error + "The event name may not be blank: ";
            }
            // If the EventName is greater than 50 characters
            if (EventName.Length > 50)
            {
                // Record the error
                Error = Error + "The event name must be less than 50 characters: ";
            }

            // If the Date is not a valid date
            DateTime tempDate;
            if (!DateTime.TryParse(Date, out tempDate))
            {
                // Record the error
                Error = Error + "The date must be a valid date: ";
            }

            // If the SpecialRequests is greater than 250 characters
            if (SpecialRequests.Length > 250)
            {
                // Record the error
                Error = Error + "The special requests must be less than 250 characters: ";
            }

            // If the NumParticipants is not a valid number or less than 1
            if (!Int32.TryParse(NumParticipants, out numParticipants) || numParticipants < 1)
            {
                // Record the error
                Error = Error + "The number of participants must be a valid number greater than zero: ";
            }

            // Return any error messages
            return Error;
        }
    }
}