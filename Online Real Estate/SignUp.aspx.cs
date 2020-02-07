using System;
using OnlineRealEstateDAL;
using OnlineRealEstateEntity;

namespace Online_Real_Estate
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submit_Click(object sender, EventArgs e)
        {
            string role = "";
            if (btnBuyer.Checked)
            {
                role = btnBuyer.Text;
            }
            else
            {
                role = btnSeller.Text;
            }
            UserManager userManager = new UserManager(txtName.Text, txtPassword.Text, txtMail.Text, txtLocation.Text, txtNumber.Text, role);
            UserRepositary userRepositary = new UserRepositary();
            int userId = userRepositary.SignUp(userManager);
            Response.Write("<script>alert(' successful');</script>");
        }
    }
}