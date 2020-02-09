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
        internal static Dictionary<int, Admin> user = new Dictionary<int, Admin>();
        static SqlConnection sqlConnection = UserRepositary.GetDBConnection();
        public static int SignUp(UserManager userManager)
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
                param.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Role";
                param.Value = UserManager.role;
                param.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(param);
                sqlConnection.Open();
                int userID = Convert.ToInt32(sqlCommand.ExecuteScalar());
                string selectQuery = "SPSelect";
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, sqlConnection);
                DataSet products = new DataSet();
                ArrayList userData = new ArrayList();
                int rows = sqlCommand.ExecuteNonQuery();
                if (rows >= 1)
                {


                    adapter.Fill(products, "UserDetails");
                    foreach (DataTable data in products.Tables)
                    {
                        if (data.TableName == "UserDetails")
                        {
                            for (int row = 0; row < data.Rows.Count; row++)
                            {
                                for (int rowColumn = 0; rowColumn < data.Columns.Count; rowColumn++)
                                {
                                    userData.Add(data.Rows[row][rowColumn]);
                                }
                            }
                        }
                    }

                    Admin admin = new Admin(userID, userData);
                    user.Add(userID, admin);
                    userData.Clear();
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
        public static SqlConnection GetDBConnection()
        {
            string dataSource = @"LAPTOP-8VF3GIKH\SQLEXPRESS";
            string dataBase = "RealEstate";
            string connectionString = @"Data Source=" + dataSource + ";Initial Catalog=" + dataBase + ";Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;

            //string connectionstring = ConfigurationManager.ConnectionStrings["RealEstate"].ConnectionString;
            //SqlConnection sqlConnection = new SqlConnection(connectionstring);
            //return sqlConnection;
        }
        public static bool Login(string username, string password)
        {
            // bool flag = false;
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
            /*private static void AddAdminDetails()
            {
                Admin admin = new Admin("Karthika", "Karthika20", "admin", "994494218", "karthika@gmail.com");

            }*/
        }
        public static void RefreshData(GridView userGrid)
        {
            SqlCommand sqlCommand = new SqlCommand("SPSelect", sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            userGrid.DataSource = dataTable;
            userGrid.DataBind();
            sqlConnection.Close();
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
                param.ParameterName = "@Phone_Number";
                param.Value = phoneNumber.Text;
                param.SqlDbType = SqlDbType.VarChar;
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
