using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FutBookClassLibrary
{
    public class clsBookingPitch
    {
        private int mBookingPitchNo;
        public int BookingPitchNo
        {
            get
            {
                return mBookingPitchNo;
            }
            set
            {
                mBookingPitchNo = value;
            }
        }
        private DateTime mBookingPitchDate;
        public DateTime BookingPitchDate
        {
            get
            {
                return mBookingPitchDate;
            }
            set
            {
                mBookingPitchDate = value;
            }
        }
        private TimeSpan mBookingPitchTime;
        public TimeSpan BookingPitchTime 
        {
            get
            {
                return mBookingPitchTime;
            }
            set
            {
                mBookingPitchTime = value;
            }
        }
        private int mAccountNo;
        public int AccountNo
        {
            get
            {
                return mAccountNo;
            }
            set
            {
                mAccountNo = value;
            }
        }
        private int mPitchNo;
        public int PitchNo 
        {
            get
            {
                return mPitchNo;
            }
            set
            {
                mPitchNo = value;
            }
        }
        public void AddBooking()
        {
            // Create a new instance of clsDataConnection
            clsDataConnection DB = new clsDataConnection();

            DateTime bookingDateTime = new DateTime(2023, 5, 10, 16, 0, 0);
            SqlParameter bookingDateParam = new SqlParameter("@BookingPitchDate", SqlDbType.DateTime);
            bookingDateParam.Value = bookingDateTime;
            SqlParameter bookingTimeParam = new SqlParameter("@BookingPitchTime", SqlDbType.DateTime);
            bookingTimeParam.Value = bookingDateTime;

            // Call stored procedure with the parameters


            // Add parameters for the stored procedure
            DB.AddParameter("@BookingPitchDate", mBookingPitchDate);
            DB.AddParameter("@BookingPitchTime", mBookingPitchTime);
            DB.AddParameter("@AccountNo", mAccountNo);
            DB.AddParameter("@PitchNo", mPitchNo);

            // Execute the stored procedure to add the booking
            DB.Execute("sproc_tblBookingPitch_Insert");

        }

    }
}
