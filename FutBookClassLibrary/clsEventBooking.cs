using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FutBookClassLibrary
{
    public class clsEventBooking
    {
        //properties for the event booking
        public int BookingID { get; set; }
        public string EventName { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public int NumParticipants { get; set; }
        public decimal PricePerPerson { get; set; }
        public decimal TotalPrice { get; set; }
        public string SpecialRequests { get; set; }

        //private variable for the database connection string
        private string ConnectionString;

        //constructor method for the class
        public clsEventBooking()
        {
            ConnectionString = GetConnectionString();
        }

        //method to get the connection string
        private string GetConnectionString()
        {
            System.Net.WebClient client = new System.Net.WebClient();
            string downloadString = "Data Source=v00egd00001l.lec-admin.dmu.ac.uk;User ID=p2577974;Password=inspiration1;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return downloadString;
        }

        //method to insert event booking data into the database
        public bool InsertBookingData()
        {
            //variable to store whether the data was inserted successfully
            bool success = false;

            //create a new connection to the database
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    //open the connection to the database
                    connection.Open();

                    //create a new SQL command to insert the data
                    using (SqlCommand command = new SqlCommand("INSERT INTO tblEventBooking (EventName, Email, Date, NumParticipants, PricePerPerson, TotalPrice, SpecialRequests) VALUES (@EventName, @Email, @Date, @numParticipants, @PricePerPerson, @TotalPrice, @SpecialRequests)", connection))
                    {
                        //add parameters to the command
                        command.Parameters.AddWithValue("@EventName", EventName);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Date", Date);
                        command.Parameters.AddWithValue("@Participants", NumParticipants);
                        command.Parameters.AddWithValue("@PricePerPerson", PricePerPerson);
                        command.Parameters.AddWithValue("@TotalPrice", TotalPrice);
                        command.Parameters.AddWithValue("@SpecialRequests", SpecialRequests);

                        //execute the command and get the number of rows affected
                        int rowsAffected = command.ExecuteNonQuery();

                        //check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            success = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //handle any exceptions
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //close the connection to the database
                    connection.Close();
                }
            }

            return success;
        }
    }
}
