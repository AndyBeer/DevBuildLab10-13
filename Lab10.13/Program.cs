using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab10._13
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> UserNames = new List<string>();
            UserNames.Add("UserName1");
            UserNames.Add("UserName2");
            UserNames.Add("UserName3");
            UserNames.Add("UserName4");
            List<string> Passwords = new List<string>();
            Passwords.Add("Pw1@12345");
            Passwords.Add("Pw2!12345");
            Passwords.Add("Pw3$12345");
            Passwords.Add("Pw4%12345");
            



            string userPass = GetInput("Please provide your preferred password:  ");
            string userName = GetInput("Please provide your preferred username:  ");
            //while


            bool pwCheck = CheckPasswordRules(userPass);
            bool userCheck = CheckUserNameRules(userName, UserNames) ;

            if (pwCheck && userCheck)
            {
                Passwords.Add(userPass);
                UserNames.Add(userName);
            }

            foreach (string u in UserNames)
            {
                
                foreach (string pw in Passwords)
                {
                    Console.WriteLine(u);
                    Console.Write("---" + pw);
                }
            }
        }

        public static string GetInput(string input)
        {
            Console.WriteLine(input);
            string output = Console.ReadLine();
            return output;
        }
        public static bool SpecCharValidation(string input)
        {
            string specialChar = "!@#$%^&*";
            foreach (var item in specialChar)
            {
                if (input.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool NumeralValidation(string input)
        {
            string numeralString = "0123456789";
            foreach (var item in numeralString)
            {
                if (input.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckPasswordRules(string input)
        {
            if (input.Length > 12 || input.Length < 7)
            {
                Console.WriteLine("I'm sorry, that password does not meet length requirements.  Please choose a password of 7-12 characters.\n");
                return false;
            }
            else if (input.ToLower() == input || input.ToUpper() == input)
            {
                Console.WriteLine("I'm sorry, that password does not meet case requirements.  Please include at least one capital and one lower-case letter.\n");
                return false;
            }
            else if (input.Any(char.IsDigit) == false)//found this .All and .Any method on stack overflow, got the lightbulb to pop up "using System.Linq"
            {
                Console.WriteLine("I'm sorry, but this password does not contain any numbers.  Please include at least one integer in the password.\n");
                return false;
            }
            else if (input.Any(char.IsLetter) == false)
            {
                Console.WriteLine("I'm sorry, but this password does not contain any letters.  Please include at least one letter in the password.\n");
                return false;
            }
            else if (SpecCharValidation(input) == false)
            {
                Console.WriteLine("I'm sorry, but your password did not contain a special character.  Please include one of the following symbols and try again:\n!, @, #, $, %, ^, &, *.");
                return false;
            }
            else
            {
                return true;
            }

        }
        public static bool CheckUserNameRules(string input, List<string> userlist)
        {
            List<string> badWords = new List<string>();
            badWords.Add("poop");
            badWords.Add("stupid");
            badWords.Add("butt");
            badWords.Add("loser");

            if (input.Length > 12 || input.Length < 7)
            {
                Console.WriteLine("I'm sorry, this user name does not meet length requirements.  Please choose a user name of 7-12 characters.\n");
                return false;
            }
            else if (input.Any(char.IsDigit) == false)
            {
                Console.WriteLine("I'm sorry, but this user name does not contain any numbers.  Please include at least one integer in the user name.\n");
                return false;
            }
            else if (input.Any(char.IsLetter) == false)
            {
                Console.WriteLine("I'm sorry, but this user name does not contain any letters.  Please include at least FIVE letters in the user name.\n");
                return false;
            }
            else if (input.Count(char.IsLetter) < 5)
            {
                Console.WriteLine("I'm sorry, but this user name does not contain enough letters.  Please include at least FIVE letters in the user name.\n");
                return false;
            }
            else if (badWords.Contains(input.ToLower()))
            {
                Console.WriteLine("RUDE!  Don't use that kind of language here!\n");
                return false;
            }
            else if (userlist.Contains(input))
            {
                Console.WriteLine($"Sorry, {input} already exists in the system.  Please try another user name.\n");
                return false;
            }
            else
            {
                return true;
            }
        
        }
    }
}
