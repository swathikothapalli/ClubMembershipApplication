using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    internal class WelcomeUserView : IView
    {
        public IFieldValidator fieldValidator => null;
        User user1 = null;

        public WelcomeUserView(User user) {
            user1 = user;
        }

        public void RunView()
        {
            Console.Clear();
            CommonOuputText.WriteMainHeading();

            CommonOutputFormat.fontChange(Fonts.Success);
            Console.WriteLine($"Welcome {user1.FirstName} !! {Environment.NewLine} You have successfully loggedin, Welcome to Cycling Club!!!");
            CommonOutputFormat.fontChange(Fonts.Default);

            Console.ReadKey();
        }
    }
}
