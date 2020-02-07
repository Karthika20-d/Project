using System;
using OnlineRealEstateDAL;

using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Web.UI;


namespace Online_Real_Estate
{
    public partial class UserGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                refreshData();
            }
        }
        void refreshData()
        {
            SqlConnection sqlConnection = UserRepositary.GetDBConnection();
            SqlCommand sqlCommand = new SqlCommand("SPSelect",sqlConnection) ;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            userGrid.DataSource = dataTable;
            userGrid.DataBind();
        }


      

        protected void userGrid_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(userGrid.DataKeys[e.RowIndex].Values["UserID"]);
            SqlConnection sqlConnection = UserRepositary.GetDBConnection();
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("delete from UserDetails where userId=@UserID ", sqlConnection);
            sqlCommand.Parameters.AddWithValue("UserID", userId);
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            refreshData();
        }

        protected void userGrid_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            userGrid.EditIndex = e.NewEditIndex;
            refreshData();
        }

        protected void userGrid_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            userGrid.EditIndex = -1;
            refreshData();
        }
    }
}