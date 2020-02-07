
using System.Text.RegularExpressions;

namespace OnlineRealEstateCommon
{
    public class Validation
    {
       public bool IsValidName(string name)
        {
            Regex regex = new Regex(@"^[A-Za-z]+$", RegexOptions.IgnoreCase);
            return regex.IsMatch(name);
        }
        public bool IsValidMailId(string mail)
        {
            Regex regex = new Regex("^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$");
            return regex.IsMatch(mail);
        }
        public bool IsValidMobileNumber(string number)
        {
            Regex regex = new Regex(@"^[6-9]\d{9}$");
            return regex.IsMatch(number);
        }
        public bool IsValidPassword(string password)
        {
            Regex regex = new Regex("^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*s).*$");
            return regex.IsMatch(password);
        }
        public bool IsValidLocation(string location)
        {
            Regex regex = new Regex(@"^[A-Za-z]+$", RegexOptions.IgnoreCase);
            return regex.IsMatch(location);
        }
        public bool IsValidRole(string role)
        {
            if(role=="Buyer" || role=="Seller")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
