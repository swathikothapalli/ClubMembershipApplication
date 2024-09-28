using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication
{
    public class Factory
    {
        internal static MainView GetMainViewObject()
        {
            ILogin login = new Login();
            IRegister register = new Register();
            IFieldValidator _fieldValidator = new UserRegistrationValidation(register);
            _fieldValidator.initializeValidatorDels();

            LoginView _loginView = new LoginView(login);
            SuccessfulRegistration _successRegister = new SuccessfulRegistration();
            RegisterView _registerview = new RegisterView(_fieldValidator,register, _successRegister);
            MainView _mainView = new MainView(_registerview, _loginView);

            return _mainView;
        }


        
    }
}
