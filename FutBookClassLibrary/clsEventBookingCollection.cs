using System;
using System.Collections.Generic;

namespace FutBookClassLibrary
{
    public class clsEventBookingCollection
    {
        //private data member for the list
        List<clsEventBooking> mEventList = new List<clsEventBooking>();
        //private data member thisEvent
        clsEventBooking mThisEvent = new clsEventBooking();

        //constructor for the class
        public clsEventBookingCollection()
        {
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the stored procedure
            DB.Execute("sproc_tblEvent_SelectAll");
            //populate the array list with the data table
            PopulateArray(DB);

        }

        //public property for the stock list
        public List<clsEventBooking> EventList
        {
            get
            {
                //return the private data
                return mEventList;
            }
            set
            {
                //set the private data
                mEventList = value;
            }
        }

        public int Count
        {
            get
            {
                //return the count of the list
                return mEventList.Count;
            }
            set
            {
                //
            }
        }
        public clsEventBooking ThisEvent
        {
            get
            {
                //return the private data
                return mThisEvent;
            }
            set
            {
                //set the private data
                mThisEvent = value;
            }
        }

        public int Add()
        {
            //adds a new record to the database based on the values of mThisEvent
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@FirstName", mThisEvent.FirstName);
            DB.AddParameter("@Surname", mThisEvent.Surname);
            DB.AddParameter("@NumParticipants", mThisEvent.NumParticipants);
            DB.AddParameter("@PricePerPerson", mThisEvent.PricePerPerson);


            //DB.AddParameter("@PricePerPerson", mThisEvent.PricePerPerson);
            //DB.AddParameter("@PricePerPerson", mThisEvent.PricePerPerson);

            //execute the query returning the primary key value
            return DB.Execute("sproc_tblEventAdd");
        }

        public void Delete()
        {
            // deletes the record pointed to by thisEvent
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@BookingNo", mThisEvent.BookingNo);
            //execute the stored procedure
            DB.Execute("sproc_tblEvent_Delete");
        }

        void PopulateArray(clsDataConnection DB)
        {
            //populates the array list based on the data table in the parameter DB
            //var for the index
            Int32 Index = 0;
            //var to store the record count
            Int32 RecordCount;
            //get the count of records
            RecordCount = DB.Count;
            //clear the private array list
            mEventList = new List<clsEventBooking>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank address
                clsEventBooking MyEvent = new clsEventBooking();
                //read in the fields from the current record
                MyEvent.BookingNo = Convert.ToInt32(DB.DataTable.Rows[Index]["BookingNo"]);
                MyEvent.FirstName = Convert.ToString(DB.DataTable.Rows[Index]["FirstName"]);
                MyEvent.PricePerPerson = Convert.ToInt32(DB.DataTable.Rows[Index]["PricePerPerson"]);
                MyEvent.NumParticipants = Convert.ToInt32(DB.DataTable.Rows[Index]["NumParticipants"]);
                //add the record to the private data member
                mEventList.Add(MyEvent);
                //point at the next record
                Index++;
            }
        }

        public void Update()
        {
            //update an existing record based on the values of thisEvent
            //connect to database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@BookingNo", mThisEvent.BookingNo);
            DB.AddParameter("@FirstName", mThisEvent.FirstName);
            DB.AddParameter("@Surname", mThisEvent.Surname);
            //DB.AddParameter("@NumParticipants", mThisEvent.NumParticipants);


            //DB.AddParameter("@PricePerPerson", mThisEvent.PricePerPerson);


            //execute the stored procedure
            DB.Execute("sproc_tblStockUpdate");
        }
    }
}