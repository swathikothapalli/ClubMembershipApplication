using ClubMembershipApplication.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    internal class MainView : IView
    {
        public IFieldValidator fieldValidator => null;
        RegisterView runRegisterView = null;
        LoginView runLoginView = null;

        public MainView(RegisterView runRegister, LoginView runLogin)
        {
            runRegisterView = runRegister;
            runLoginView = runLogin;
        }

        public void RunView()
        {
            CommonOuputText.WriteMainHeading();
            Console.WriteLine("To Register Press R key or To Login Press L key");
            Console.WriteLine("If you wish to exit press any key...");
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.R)
            {
                runRegisterView.RunView();
                runLoginView.RunView();
            }
            else if(key == ConsoleKey.L)
                runLoginView.RunView();
            else
            {
                Console.Clear();
                Console.WriteLine("GoodBye!");
                Console.ReadKey();
            }

        }
    }
}
