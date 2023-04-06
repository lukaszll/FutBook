using System.Collections.Generic;

namespace FutBookClassLibrary
{
    public class clsStockCollection
    {
        //private data member for the list
        List<clsStock> mStockList = new List<clsStock>();
        //private data member thisStock
        clsStock mThisStock = new clsStock();

        //constructor for the class
        

        //public property for the stock list
        public List<clsStock> StockList
        {
            get
            {
                //return the private data
                return mStockList;
            }
            set
            {
                //set the private data
                mStockList = value;
            }
        }

        public int Count
        {
            get
            {
                //return the count of the list
                return mStockList.Count;
            }
            set
            {
                //
            }
        }
        public clsStock ThisStock
        {
            get
            {
                //return the private data
                return mThisStock;
            }
            set
            {
                //set the private data
                mThisStock = value;
            }
        }

        public int Add()
        {
            //adds a new record to the database based on the values of mThisStock
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@StockName", mThisStock.StockName);
            DB.AddParameter("@StockQuantity", mThisStock.StockQuantity);
            DB.AddParameter("@StockPrice", mThisStock.StockPrice);
            DB.AddParameter("@StockCategory", mThisStock.StockCategory);
            DB.AddParameter("@StockImage", mThisStock.StockImage);
            //execute the query returning the primary key value
            return DB.Execute("sproc_tblStockAdd");
        }


        

    }
}