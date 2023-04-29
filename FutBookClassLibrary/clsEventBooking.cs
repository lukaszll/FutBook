using System;

namespace FutBookClassLibrary
{
    public class clsEventBooking
    {
        //BookingNo private member variable
        private Int32 mBookingNo;
        //BookingNo public property
        public Int32 BookingNo
        {
            get
            {
                //this line of code sends data out of the property
                return mBookingNo;
            }
            set
            {
                //this line of code allows data into the property
                mBookingNo = value;
            }
        }

        //FirstName private member variable
        private string mFirstName;
        //FirstName public property
        public string FirstName
        {
            get
            {
                //this line of code sends data out of the property
                return mFirstName;
            }
            set
            {
                //this line of code allows data into the property
                mFirstName = value;
            }
        }

        //event name private member variable
        private string mEventName;
        //FirstName public property
        public string EventName
        {
            get
            {
                //this line of code sends data out of the property
                return mEventName;
            }
            set
            {
                //this line of code allows data into the property
                mEventName = value;
            }
        }


        //FirstName private member variable
        private string mSurname;
        //Surname public property
        public string Surname
        {
            get
            {
                //this line of code sends data out of the property
                return mSurname;
            }
            set
            {
                //this line of code allows data into the property
                mSurname = value;
            }
        }


        //FirstName private member variable
        private string mEmail;
        //Surname public property
        public string Email
        {
            get
            {
                //this line of code sends data out of the property
                return mEmail;
            }
            set
            {
                //this line of code allows data into the property
                mEmail = value;
            }
        }

        public string Valid(string text1, string text2, string text3)
        {
            throw new NotImplementedException();
        }




        //NumParticipants private member variable
        private Int32 mNumParticipants;
        //NumParticipants public property
        public Int32 NumParticipants
        {
            get
            {
                //this line of code sends data out of the property
                return mNumParticipants;
            }
            set
            {
                //this line of code allows data into the property
                mNumParticipants = value;
            }
        }

        ////PricePerPerson private member variable
        private decimal mPricePerPerson;
        ////PricePerPerson public property
        public decimal PricePerPerson
        {
            get
            {
                //this line of code sends data out of the property
                return mPricePerPerson;
            }
            set
            {
                //this line of code allows data into the property
                mPricePerPerson = value;
            }
        }


        public bool Find(int BookingNo)
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //add the parameter for the stock id to search for
            DB.AddParameter("@BookingNo", BookingNo);
            //execute the stored procedure
            DB.Execute("sproc_tblEventBooking_FilterByBookingNo");
            //if one record is found (there should be either one or zero)
            if (DB.Count == 1)
            {
                //copy the data from the database to the private data members
                mBookingNo = Convert.ToInt32(DB.DataTable.Rows[0]["BookingNo"]);
                mFirstName = Convert.ToString(DB.DataTable.Rows[0]["FirstName"]);
                mSurname = Convert.ToString(DB.DataTable.Rows[0]["Surname"]);
                mEventName = Convert.ToString(DB.DataTable.Rows[0]["EventName"]);


                mPricePerPerson = Convert.ToInt32(DB.DataTable.Rows[0]["PricePerPerson"]);


                mNumParticipants = Convert.ToInt32(DB.DataTable.Rows[0]["NumParticipants"]);
                //mPricePerPerson = Convert.ToDecimal(DB.DataTable.Rows[0]["PricePerPerson"]);

                //return that everything worked OK
                return true;
            }
            //if no record was found
            else
            {
                //return false indicating problem
                return false;
            }
        }

        public string Valid(string FirstName, string Surname, string EventName, string PricePerPerson, string NumParticipants, string Email)
        {
            //create a string variable to store the error
            String Error = "";
            //create variables for price and quantity
            decimal pricePerPerson;
            int quantity;

            //if the FirstName is blank
            if (FirstName.Length == 0)
            {
                //record the error
                Error = Error + "The first name may not be blank : ";
            }
            //if the FirstName is greater than 50 characters
            if (FirstName.Length > 50)
            {
                //record the error
                Error = Error + "The first name must be less than 50 characters : ";
            }


            //if the EventName is blank
            if (EventName.Length == 0)
            {
                //record the error
                Error = Error + "The event name may not be blank : ";
            }
            //if the FirstName is greater than 50 characters
            if (EventName.Length > 50)
            {
                //record the error
                Error = Error + "The event name must be less than 50 characters : ";
            }


            //if the Surname is blank
            if (Surname.Length == 0)
            {
                //record the error
                Error = Error + "The first name may not be blank : ";
            }
            //if the Surname is greater than 50 characters
            if (FirstName.Length > 50)
            {
                //record the error
                Error = Error + "The surname must be less than 50 characters : ";
            }



            //if the email is blank
            if (Email.Length == 0)
            {
                //record the error
                Error = Error + "The email may not be blank : ";
            }
            //if the email is greater than 50 characters
            if (Email.Length > 50)
            {
                //record the error
                Error = Error + "The email must be less than 50 characters : ";
            }


            ////if the NumParticipants is not a valid number
            if (!Int32.TryParse(PricePerPerson, out quantity) || quantity < 0)
            {
                //record the error
               Error = Error + "The number of participants must be a valid number greater than zero : ";
            }
            //if the NumParticipants is greater than 50
            if (quantity > 50)
            {
                //record the error
                Error = Error + "The price per persons must be less than 50 : ";
            }


            ////if the NumParticipants is not a valid number
            //if (!Int32.TryParse(NumParticipants, out quantity) || quantity < 0)
            //{
            //    //record the error
            //    Error = Error + "The number of participants must be a valid number greater than zero : ";
            //}
            ////if the NumParticipants is greater than 50
            //if (quantity > 50)
            //{
            //    //record the error
            //    Error = Error + "The number of participants must be less than 50 : ";
            //}



            //return any error messages
            return Error;
        }
    }
}