using ClubMembershipApplication.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    internal class SuccessfulRegistration : IView
    {
        public IFieldValidator fieldValidator => null;

        public void RunView()
        {
            CommonOuputText.WriteMainHeading();
            CommonOutputFormat.fontChange(Fonts.Success);
            Console.WriteLine("Successfully Registered!!!");
            CommonOutputFormat.fontChange(Fonts.Default);
            Console.ReadKey();
        }
    }
}
