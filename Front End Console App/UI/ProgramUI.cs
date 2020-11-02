using Front_End_Console_App.Models.Register;
using FrontEndConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Front_End_Console_App.UI
{
    public class ProgramUI
    {
        RegisterService registerService = new RegisterService();
        public void Run()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("Weclome to Trail AID!");
                Console.WriteLine("Select your option");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Create Account");

                string response = Console.ReadLine();

                if(response == "1" || response == "Login") Login();

                if (response == "2" || response == "Create Account") CreateAccount();
                
            }
        }
        private void CreateAccount()
        {
            Console.Clear();
            var information = new RegisterBindingModel();
            Console.WriteLine("Please enter an email address");
            information.Email = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Please enter a password");
            information.Password = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Please confirm the password");
            information.ConfirmPassword = Console.ReadLine();
            Console.Clear();

            if (registerService.Register(information) != null)
            {
                Console.WriteLine("Account Created!");
                Console.Clear();
                Login();
            }
            else
            {
                Console.WriteLine(registerService.Register(information));
                Console.ReadKey();
            }

        }

        private string Login()
        {
            var information = new TokenCreate();
            Console.WriteLine("Please enter your registered email address");
            information.username = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Please enter your password");
            information.password = Console.ReadLine();
            Console.Clear();

            string token = Convert.ToString(registerService.GetToken(information));
            Console.WriteLine(token);
            Console.Clear();
        }
    }
}
