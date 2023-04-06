using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FutBookClassLibrary;

namespace FutBookTesting
{
    [TestClass]
    public class tstStock
    {

        //good test data
        //create some test data to pass to the method
        string StockName = "Real Madrid T-Shirt";
        string StockPrice = "59.99";
        string StockCategory = "T-SHIRTS";
        string StockQuantity = "20";

        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class clsStock
            clsStock MyStock = new clsStock();
            //test to see that it exists
            Assert.IsNotNull(MyStock);
        }

        [TestMethod]
        public void StockNoPropertyOK()
        {
            //create an instance of the class clsStock
            clsStock MyStock = new clsStock();
            //create some test data to assign to the property
            Int32 TestData = 1;
            //assign the data to the property
            MyStock.StockNo = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(MyStock.StockNo, TestData);
        }

        [TestMethod]
        public void StockNamePropertyOK()
        {
            //create an instance of the class clsStock
            clsStock MyStock = new clsStock();
            //create some test data to assign to the property
            string TestData = "abc";
            //assign the data to the property
            MyStock.StockName = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(MyStock.StockName, TestData);
        }

        [TestMethod]
        public void StockQuantityPropertyOK()
        {
            //create an instance of the class clsStock
            clsStock MyStock = new clsStock();
            //create some test data to assign to the property
            Int32 TestData = 1;
            //assign the data to the property
            MyStock.StockQuantity = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(MyStock.StockQuantity, TestData);
        }

        [TestMethod]
        public void StockPricePropertyOK()
        {
            //create an instance of the class clsStock
            clsStock MyStock = new clsStock();
            //create some test data to assign to the property
            decimal TestData = 100;
            //assign the data to the property
            MyStock.StockPrice = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(MyStock.StockPrice, TestData);
        }

        [TestMethod]
        public void StockCategoryPropertyOK()
        {
            //create an instance of the class clsStock
            clsStock MyStock = new clsStock();
            //create some test data to assign to the property
            string TestData = "abc";
            //assign the data to the property
            MyStock.StockCategory = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(MyStock.StockCategory, TestData);
        }

        //[TestMethod]
        //public void StockImagePropertyOK()
        //{
            //create an instance of the class clsStock
            //clsStock MyStock = new clsStock();
            //create some test data to assign to the property
            //byte[] TestData = new byte[] { 0x1A, 0x2B, 0x3C };
            //assign the data to the property
            //MyStock.StockImage = TestData;
            //test to see that the two values are the same
            //Assert.AreEqual(MyStock.StockImage, TestData);
       // }

        [TestMethod]
        public void FindMethodOK()
        {
            //create an instance of the class clsStock
            clsStock MyStock = new clsStock();
            //boolean variable to store the results of the validation
            Boolean Found = false;
            //create some test data to use with the method
            Int32 StockNo = 2;
            //invoke the method
            Found = MyStock.Find(StockNo);
            //test to see if the result is true
            Assert.IsTrue(Found);
        }

        [TestMethod]
        public void TestStockNoFound()
        {
            //create an instance of the class clsStock
            clsStock MyStock = new clsStock();
            //boolean variable to store the results of the search
            Boolean Found = false;
            //boolean variable to record if data is OK(assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 StockNo = 2;
            //invoke the method
            Found = MyStock.Find(StockNo);
            //check the stock id
            if (MyStock.StockNo != 2)
            {
                OK = false;
            }
            //test to see if the result is true
            Assert.IsTrue(OK);
        }
    }
}
