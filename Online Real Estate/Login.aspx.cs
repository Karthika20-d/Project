using System;
using OnlineRealEstateBL;

namespace Online_Real_Estate
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submit_Click(object sender, EventArgs e)
        {
            string userName = Convert.ToString(txtName.Text);
            string password = Convert.ToString(txtPassword.Text);
            if(UserBL.IsLogin(userName, password))
            {
                Response.Write("<script>alert('login successful');</script>");
                Session["UserName"] = userName;
                Session["Password"] = password;
                Response.Redirect("UserGrid.aspx");
            }
            else
            {
                Response.Write("<script>alert('login not successful');</script>");
            }

        }
    }
}