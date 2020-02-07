using System.Collections.Generic;
using System.Collections;
using System.Data;
using System;
using OnlineRealEstateEntity;
using System.Data.SqlClient;

namespace OnlineRealEstateRepositary
{
     
    class UserRepositary
    {
        internal  Dictionary<int,Admin> user = new Dictionary<int, Admin>();
        DataSet products = new DataSet();
        SqlConnection sqlConnection =UserRepositary. GetDBConnection();
        ArrayList userData = new ArrayList();
        //internal static                           string propertyType;
        internal int SignUp(UserManager userManager)
        {
         
            sqlConnection.Open();
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
                param.Value =userManager.location ;
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
                int userID = Convert.ToInt32(sqlCommand.ExecuteScalar());
                string selectQuery = "SPSelect";
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery,sqlConnection);
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
                  
                    Admin admin = new Admin(userID,userData);
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
        static SqlConnection GetDBConnection()
        {
            string dataSource = @"LAPTOP-8VF3GIKH\SQLEXPRESS";
            string dataBase = "RealEstate";
            string connectionString = @"Data Source=" + dataSource + ";Initial Catalog=" + dataBase + ";Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }
        internal bool SellerLogin(int sellerID,string password)
         {
            bool flag = false;
            string selectQuery = "SPSellerLogin";
            SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, sqlConnection);
            adapter.Fill(products, "UserDetails");
            foreach (DataTable data in products.Tables)
            {
                
                if (data.TableName == "UserDetails")
                {
                    for (int row = 0; row < data.Rows.Count; row++)
                    {
                        for (int rowColumn = 0; rowColumn < data.Columns.Count; rowColumn++)
                        {
                            string user = Convert.ToString(data.Rows[row][rowColumn]);
                            int 
                            if (sellerID == Convert.ToInt32(data.Rows[row][rowColumn]))
                            {
                                for (int column = 0; column < data.Columns.Count; column++)
                                {
                                    if (password == Convert.ToString(data.Rows[row][rowColumn]))
                                    {
                                        flag = true;
                                        
                                    }
                                }
                            }
                        }
                    }
                }
                
            }
            if (flag)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
         /*private static void AddAdminDetails()
         {
             Admin admin = new Admin("Karthika", "Karthika20", "admin", "994494218", "karthika@gmail.com");

         }*/
    }
}
