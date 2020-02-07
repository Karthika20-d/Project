using System;
using OnlineRealEstateDAL;

namespace Online_Real_Estate
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submit_Click(object sender, EventArgs e)
        {
            UserRepositary userRepositary = new UserRepositary();
            string userName = Convert.ToString(txtName.Text);
            string password = Convert.ToString(txtPassword.Text);
            if (userRepositary.Login(userName, password))
            {
                Response.Write("<script>alert('login successful');</script>");
            }
            else
            {
                Response.Write("<script>alert('login not successful');</script>");
            }

        }
    }
}