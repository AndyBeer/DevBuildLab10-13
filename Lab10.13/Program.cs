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
            UserNames.Add("User1!abc");
            List<string> Passwords = new List<string>();
            Passwords.Add("Pass1!abc");


            bool keepGoing = true;
            bool userCheck = false;
            

            while (keepGoing)
            {
                string userPass = GetInput("Please provide your preferred password:  ");
                bool pwCheck = CheckPasswordRules(userPass);

                if (pwCheck == true)
                {
                    string userName = GetInput("Please provide your preferred username:  ");

                    userCheck = CheckUserNameRules(userName, UserNames);

                    if (pwCheck && userCheck)//verify that BOTH have to be true
                    {
                        Passwords.Add(userPass);
                        UserNames.Add(userName);
                        Console.WriteLine($"The username {userName} has been added to the user list.  Remember your password: {userPass}.\n");
                    }
                }

                keepGoing = ContinueLoop("Would you like to add another password and user name? Y/N");
            }
            bool printLists = ContinueLoop("Would you like to print the current list of users? Y/N");
            if (printLists == true)
            {
                Console.WriteLine("USERNAME----------PASSWORD");
                for (int i = 0; i <= UserNames.Count() - 1; i++)
                {
                    Console.Write(UserNames[i] + "-----------");
                    Console.WriteLine(Passwords[i]);
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
        public static bool ContinueLoop(string input)
        {
            string answer = GetInput(input);
            if (answer.ToLower() == "y")
            {
                return true;
            }
            else if (answer == "n" || answer == "N")
            {
                Console.WriteLine("OK.");
                return false;
            }
            else
            {
                return ContinueLoop("I'm sorry, I didn't catch that.\nLet's try that again.");
            }
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
