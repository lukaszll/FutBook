using FutBookClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace FutBookFrontOffice
{
    public partial class BookingPitchStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            string sprocName = "sproc_tblBookingPitch_SelectAll";
            clsDataConnection DB = new clsDataConnection();
            DB.Execute(sprocName);
            DataTable dt = DB.DataTable;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int bookingPitchNo = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@BookingPitchNo", bookingPitchNo);
            DB.Execute("sproc_tblBookingPitch_Delete");
            BindGrid();
        }
    }
}