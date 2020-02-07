using System;
using OnlineRealEstateCommon;
namespace OnlineRealEstateEntity
{
    public class UserManager
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string password { get; set; }
        public static string role { get; set; }
        public string location { get; set; }
        public UserManager(string name,string password, string email, string location, string phoneNumber, string Role)
        {
            Validation validation = new Validation();
            while (true)
            {
                try
                {
             
                    this.name = name;
                    if (name == "")
                    {
                        throw new NullReferenceException("Name");
                    }
                    else
                    {
                        bool flag = validation.IsValidName(name);
                        if (!flag)
                        {
                            Console.WriteLine("Enter valid name");
                            Console.WriteLine("Registration failed and fill the details correctly");
                            throw new NullReferenceException("Name");
                        }

                    }
                    Console.WriteLine("Enter your mail id");
                    this.email = email;
                    if (email == "")
                    {
                        throw new NullReferenceException("Email");
                    }
                    else
                    {
                        bool flag = validation.IsValidMailId(email);
                        if (!flag)
                        {
                            Console.WriteLine("Enter valid mail");
                            Console.WriteLine("Registration failed and fill the details correctly");
                            throw new NullReferenceException("Email");
                        }
                    }
                    Console.WriteLine("Enter your phone number");
                    this.phoneNumber = phoneNumber;
                    if (phoneNumber == "")
                    {
                        throw new NullReferenceException("PhoneNumber");
                    }
                    else
                    {
                        bool flag = validation.IsValidMobileNumber(phoneNumber);
                        if (!flag)
                        {
                            Console.WriteLine("Enter valid phone number");
                            Console.WriteLine("Registration failed and fill the details correctly");
                            throw new NullReferenceException("PhoneNumber");
                        }
                    }

                    Console.WriteLine("Enter your password");
                    this.password = password;
                    if (password == "")
                    {
                        throw new NullReferenceException("Password");
                    }
                    else
                    {
                        bool flag = validation.IsValidPassword(password);
                        if (!flag)
                        {
                            Console.WriteLine("Enter valid password it should be 8 characters like upper case,lower case and number");
                            Console.WriteLine("Registration failed and fill the details correctly");
                            throw new NullReferenceException("Password");
                        }
                    }
                    Console.WriteLine("Enter your location");
                    this.location= location;
                    if (location == "")
                    {
                        throw new NullReferenceException("location");
                    }
                    else
                    {
                        bool flag = validation.IsValidLocation(location);
                        if (!flag)
                        {
                            Console.WriteLine("Enter valid locatiion");
                            Console.WriteLine("Registration failed and fill the details correctly");
                            throw new NullReferenceException("location");
                        }
                    }
                    Console.WriteLine("Enter your role\n1.Buyer\n2.Seller");
                    role=Role ;
                    if(role=="")
                    {
                        throw new NullReferenceException("role");
                    }
                    else
                    {
                        bool flag = validation.IsValidRole(role);
                        if (!flag)
                        {
                            Console.WriteLine("Enter valid role");
                            Console.WriteLine("Registration failed and fill the details correctly");
                            throw new NullReferenceException("role");
                        }
                    }
                    break;
                }
                catch (NullReferenceException exception) when (exception.Message == "Name")
                {
                    Console.WriteLine("Enter correct username ");

                }
                catch (NullReferenceException exception) when (exception.Message == "Email")
                {
                    Console.WriteLine("Enter correct mail id");

                }
                catch (NullReferenceException exception) when (exception.Message == "PhoneNumber")
                {
                    Console.WriteLine("Enter correct phone number");

                }
                catch (NullReferenceException exception) when (exception.Message == "Password")
                {
                    Console.WriteLine("Enter correct password");

                }
                catch (NullReferenceException exception) when (exception.Message == "location")
                {
                    Console.WriteLine("Enter correct location");

                }
                catch (NullReferenceException exception) when (exception.Message == "role")
                {
                    Console.WriteLine("Enter correct role");

                }
            }
        }
        public override string ToString()
        {
            return "Name:" + name + "\nEmail:" + email + "\nPhone number:" + phoneNumber;
        }

    }
}
