using Microsoft.VisualStudio.TestTools.UnitTesting;
using FutBookClassLibrary;
using System;

namespace FutBookTesting
{
    [TestClass]
    public class clsEventBookingTests
    {
        [TestMethod]
        public void TestValid()
        {
            // Arrange
            clsEventBooking booking = new clsEventBooking();
            string eventName = "Test Event";
            string eventDate = DateTime.Now.AddDays(1).ToString();
            string specialRequests = "Test Request";
            string numParticipants = "4";

            // Act
            string result = booking.Valid(eventName, eventDate, specialRequests, numParticipants);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void TestValidInvalidDate()
        {
            // Arrange
            clsEventBooking booking = new clsEventBooking();
            string eventName = "Test Event";
            string eventDate = "invalid date";
            string specialRequests = "Test Request";
            string numParticipants = "4";

            // Act
            string result = booking.Valid(eventName, eventDate, specialRequests, numParticipants);

            // Assert
            Assert.AreEqual("The EventDate must be a valid date. ", result);
        }

    }
}
