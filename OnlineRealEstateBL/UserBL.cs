using OnlineRealEstateEntity;
using OnlineRealEstateDAL;
using System.Web.UI.WebControls;

namespace OnlineRealEstateBL
{
    public class UserBL
    {
        public static int SignUp(UserManager userManager)
        {
            int userId = UserRepositary.SignUp(userManager);
            if(userId!=0)
            {
                return userId;
            }
            else
            {
                return 0;
            }
        }
        public static bool IsLogin(string userName,string password)
        {
            return UserRepositary.Login(userName,password);
        }
        public static void RefreshData(GridView gridView)
        {
            UserRepositary.RefreshData(gridView);
        }
        public static void IsDeleteUserDetails(GridView gridView, GridViewDeleteEventArgs gridViewDeleteEventArgs)
        {
            UserRepositary.DeleteUserDetails(gridView,gridViewDeleteEventArgs);
        }
        public static void IsUpdateUserDetails(GridView UserData, GridViewUpdateEventArgs e)
        {
            UserRepositary.UpdateUserDetails(UserData, e);

        }
        public static void IsInsertUserDetails(GridView gridView)
        {
            UserRepositary.InsertUserDetails(gridView); 
        }
    }
}
