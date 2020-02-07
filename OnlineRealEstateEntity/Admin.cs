using System.Collections;
using System;
namespace OnlineRealEstateEntity
{
    public class Admin
    {
        internal string name { get; set; }
        internal string password { get; set; }
        internal string email { get; set; }
        internal string location { get; set; }
        internal string phoneNumber { get; set; }
        internal string role { get; set; }
        internal int userID { get; set; }
        public  Admin(int userID, ArrayList userData)
        {
            this.userID = userID;
            this.name =Convert.ToString( userData[0]);
            this.password = Convert.ToString(userData[1]);
            this.email = Convert.ToString(userData[2]);
            this.location = Convert.ToString(userData[3]);
            this.phoneNumber = Convert.ToString(userData[4]);
            this.role = Convert.ToString(userData[5]);
        }
    }
    /* {
         private enum AdminOption
         {
             ViewBuyer,
             ViewSeller,
             AddBuyer,
             Exit
         };
         internal string adminName;
         internal string adminPassword;
         internal string adminNumber;
         internal string adminMail;
         internal string role;
         internal Admin(string adminName, string adminPassword, string role, string adminNumber, string adminMail)
         {
             this.adminName = adminName;
             this.adminPassword = adminPassword;
             this.role = role;
             this.adminNumber = adminNumber;
             this.adminMail = adminMail;

         }
         private static void ViewBuyer()
         {
             if (UserRepositary.user.Count != 0 && User.role == "Buyer")
             {
                 Console.WriteLine("Buyer Details");
                 foreach (User user in UserRepositary.user.Values)
                 {
                     Console.WriteLine(user.ToString());
                 }
             }
         }
         internal static void ViewSeller()
         {
             if (UserRepositary.user.Count != 0 && User.role == "Seller")
             {
                 Console.WriteLine("Seller Details");
                 foreach (User user in UserRepositary.user.Values)
                 {
                     Console.WriteLine(user.ToString());
                 }
             }
         }
         private static void AddBuyer()
         {
             User register = new User();
             Console.WriteLine("You are\n1.Buyer\n2.Seller");
             User.role = Console.ReadLine();
             UserRepositary.SignUp(register.name, register);
             Console.WriteLine("Successfully Registered");
         }
         internal static void AccessAdmin()
         {
             while (true)
             {
                 foreach (string enumOption in Enum.GetNames(typeof(AdminOption)))
                 {
                     Console.WriteLine(enumOption);
                 }
                 string choice = Console.ReadLine();
                 AdminOption option = (AdminOption)Enum.Parse(typeof(AdminOption), choice);
                 bool flag = true;
                 if (choice == "Exit")
                 {
                     break;
                 }
                 while (flag)
                 {
                     switch (option)
                     {
                         case AdminOption.ViewBuyer:
                             Admin.ViewBuyer();
                             flag = false;
                             break;
                         case AdminOption.ViewSeller:
                             Admin.ViewSeller();
                             flag = false;
                             break;
                         case AdminOption.AddBuyer:
                             Admin.AddBuyer();
                             flag = false;
                             break;
                         default:
                             Console.WriteLine("Enter correct option");
                             break;
                     }
                 }
             }
         }
     }*/
}
