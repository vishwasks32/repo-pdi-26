using System;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            string emailId = "vishwas@cloudthat.com";

            if(!emailId.Contains('@'))
            {
                Console.WriteLine("The given string is not a vaild email id");
            } else
            {
                int cutpoint = emailId.IndexOf('@');
                string username = emailId.Substring(0, cutpoint);

                Console.WriteLine($"The username is: {username}");
            }
        }
    }
    
}