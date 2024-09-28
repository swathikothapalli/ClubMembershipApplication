using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ClubMembershipApplication.Views
{
    internal class LoginView : IView
    {
        public IFieldValidator fieldValidator => null;
        ILogin login = null;
        

        public LoginView(ILogin login)
        {
            this.login = login;
        }
        public void RunView()
        {
            CommonOuputText.WriteMainHeading();
            CommonOuputText.WriteLoginHeading();

            Console.Write("Enter your email : ");
            string email = Console.ReadLine();

            Console.Write("Enter your password : ");
            string password = Console.ReadLine();
            
            User user1 = login.UserLogin(email, password);

            if (user1 != null)
            {
                WelcomeUserView wv = new WelcomeUserView(user1);
                wv.RunView();
            }
            else
            {
                Console.Clear();
                CommonOutputFormat.fontChange(Fonts.Error);
                Console.WriteLine("Invalid Credentials Please try again!!!");
                CommonOutputFormat.fontChange(Fonts.Default);

                Console.ReadKey();
            }
            

        }
    }
}
