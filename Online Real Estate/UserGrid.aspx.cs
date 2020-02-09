using System;
using OnlineRealEstateBL;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Real_Estate
{
    public partial class UserGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if((string)Session["UserName"]=="Karthika" && (string)Session["Password"]=="Karthika@20admin")
                {
                    UserBL.RefreshData(UserData);
                }
               
            }
        }
        protected void UserGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            UserBL.IsDeleteUserDetails(UserData, e);
            UserBL.RefreshData(UserData);
        }

        protected void UserGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            UserData.EditIndex = e.NewEditIndex;
            UserBL.RefreshData(UserData);
        }

        protected void UserGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            UserData.EditIndex = -1;
            UserBL.RefreshData(UserData);
        }

        protected void UserGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            UserBL.IsUpdateUserDetails(UserData, e);
            UserBL.RefreshData(UserData);

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            UserBL.IsInsertUserDetails(UserData);
            UserBL.RefreshData(UserData);
        }
    }
}