using System.Collections.Generic;
using System.Collections;
using System.Data;
using System;
using System.Configuration;
using OnlineRealEstateEntity;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace OnlineRealEstateDAL
{

    public class UserRepositary
    {
        static SqlConnection sqlConnection = UserRepositary.GetDBConnection();
        public static int SignUp(UserManager userManager)
        {
            try
            {
                string insertQuery = "SPInsert";

                using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@UserName";
                    param.Value = userManager.name;
                    param.SqlDbType = SqlDbType.VarChar;
                    sqlCommand.Parameters.Add(param);

                    param = new SqlParameter();
                    param.ParameterName = "@Password";
                    param.Value = userManager.password;
                    param.SqlDbType = SqlDbType.VarChar;
                    sqlCommand.Parameters.Add(param);

                    param = new SqlParameter();
                    param.ParameterName = "@Mail_id";
                    param.Value = userManager.email;
                    param.SqlDbType = SqlDbType.VarChar;
                    sqlCommand.Parameters.Add(param);

                    param = new SqlParameter();
                    param.ParameterName = "@Location";
                    param.Value = userManager.location;
                    param.SqlDbType = SqlDbType.VarChar;
                    sqlCommand.Parameters.Add(param);

                    param = new SqlParameter();
                    param.ParameterName = "@Phone_Number";
                    param.Value = userManager.phoneNumber;
                    param.SqlDbType = SqlDbType.BigInt;
                    sqlCommand.Parameters.Add(param);

                    param = new SqlParameter();
                    param.ParameterName = "@Role";
                    param.Value = UserManager.role;
                    param.SqlDbType = SqlDbType.VarChar;
                    sqlCommand.Parameters.Add(param);
                    sqlConnection.Open();
                    int userID = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    int rows = sqlCommand.ExecuteNonQuery();
                    if (rows >= 1)
                    {
                        sqlCommand.Dispose();
                        sqlConnection.Close();
                        return userID;
                    }
                    else
                    {
                        sqlCommand.Dispose();
                        sqlConnection.Close();
                        return 0;
                    }

                }
            }
            catch(Exception)
            {
                return 0;
            }

        }
        public static SqlConnection GetDBConnection()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["RealEstate"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            return sqlConnection;
        }
        public static bool Login(string username, string password)
        {
            try
            {
                string selectQuery = "SPUserLogin";
                using (SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@UserName";
                    param.Value = username;
                    param.SqlDbType = SqlDbType.VarChar;
                    sqlCommand.Parameters.Add(param);

                    param = new SqlParameter();
                    param.ParameterName = "@Password";
                    param.Value = password;
                    param.SqlDbType = SqlDbType.VarChar;
                    sqlCommand.Parameters.Add(param);
                    sqlConnection.Open();
                    string role = sqlCommand.ExecuteScalar().ToString();
                    sqlConnection.Close();
                    return true;

                }
            }
            catch(Exception)
            {
                return false;
            }
            
        }
        public static void RefreshData(GridView userGrid)
        {
            SqlCommand sqlCommand = new SqlCommand("SPSelect", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            userGrid.DataSource = dataTable;
            userGrid.DataBind();
        }
        public static void DeleteUserDetails(GridView gridView, GridViewDeleteEventArgs gridViewDeleteEventArgs)
        {
            int userId = Convert.ToInt32(gridView.DataKeys[gridViewDeleteEventArgs.RowIndex].Values["UserID"]);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SP_DeleteUserDetails", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@userId";
            param.Value = userId;
            param.SqlDbType = SqlDbType.Int;
            sqlCommand.Parameters.Add(param);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public static void UpdateUserDetails(GridView gridView, GridViewUpdateEventArgs gridViewUpdateEventArgs)
        {
            TextBox userName = gridView.Rows[gridViewUpdateEventArgs.RowIndex].FindControl("txtName") as TextBox;
            TextBox role = gridView.Rows[gridViewUpdateEventArgs.RowIndex].FindControl("txtRoleId") as TextBox;
            TextBox location = gridView.Rows[gridViewUpdateEventArgs.RowIndex].FindControl("txtLocationId") as TextBox;
            int userId = Convert.ToInt32(gridView.DataKeys[gridViewUpdateEventArgs.RowIndex].Values["UserID"]);
            SqlCommand sqlCommand = new SqlCommand("SP_UpdateUserDetails", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@userId";
            param.Value = userId;
            param.SqlDbType = SqlDbType.Int;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@userName";
            param.Value = userName.Text;
            param.SqlDbType = SqlDbType.VarChar;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Role";
            param.Value = role.Text;
            param.SqlDbType = SqlDbType.VarChar;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Location";
            param.Value = location.Text;
            param.SqlDbType = SqlDbType.VarChar;
            sqlCommand.Parameters.Add(param);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
       public static void InsertUserDetails(GridView gridView) 
        {
            TextBox userName = gridView.FooterRow.FindControl("txtNameInsert") as TextBox;
            TextBox role = gridView.FooterRow.FindControl("txtRoleInsert") as TextBox;
            TextBox location = gridView.FooterRow.FindControl("txtLocationInsert") as TextBox;
            TextBox mail = gridView.FooterRow.FindControl("txtmailInsert") as TextBox;
            TextBox password = gridView.FooterRow.FindControl("txtPasswordInsert") as TextBox;
            TextBox phoneNumber = gridView.FooterRow.FindControl("txtPhoneInsert") as TextBox;

            string insertQuery = "SPInsert";

            using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@UserName" ;
                param.Value = userName.Text;
                param.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Password";
                param.Value = password.Text;
                param.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Mail_id";
                param.Value = mail.Text;
                param.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Location";
                param.Value = location.Text;
                param.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(param);

                param = new SqlParameter();
                param.Value = phoneNumber.Text;
                param.ParameterName = "@Phone_Number";
                param.SqlDbType = SqlDbType.BigInt;
                sqlCommand.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Role";
                param.Value = role.Text;
                param.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(param);
                sqlConnection.Open();
                int rows = sqlCommand.ExecuteNonQuery();

            }
        }
    }
}
