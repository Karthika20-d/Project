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
                RefreshData();
            }
        }
        void RefreshData()
        {

            UserRepositary userRepositary = new UserRepositary();
            userRepositary.RefreshData(UserData); 
        }
        protected void UserGrid_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            UserRepositary userRepositary = new UserRepositary();
            userRepositary.DeleteUserDetails(UserData, e);
            RefreshData();
        }

        protected void UserGrid_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            UserData.EditIndex = e.NewEditIndex;
            RefreshData();
        }

        protected void UserGrid_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            UserData.EditIndex = -1;
            RefreshData();
        }

        protected void UserGrid_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            UserRepositary userRepositary = new UserRepositary();
            userRepositary.UpdateUserDetails(UserData,e);
        }
    }
}