using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    internal class RegisterView : IView
    {

        public IFieldValidator _fieldValidator = null;
        public IRegister _register = null;
        public SuccessfulRegistration successfulRegister = null;

        public RegisterView(IFieldValidator fieldValidator, IRegister register, SuccessfulRegistration successRegister)
        {
            _fieldValidator = fieldValidator;
            _register = register;
            successfulRegister = successRegister;
        }

        public IFieldValidator fieldValidator => _fieldValidator;

        public void RunView()
        {
            CommonOuputText.WriteMainHeading();

            CommonOuputText.WriteRegistrationHeading();

            _fieldValidator.FieldValues[(int)FieldConstants.UserRegistrationField.Email] = GetUserInput(FieldConstants.UserRegistrationField.Email, "Please enter your email address: ");
            _fieldValidator.FieldValues[(int)FieldConstants.UserRegistrationField.FirstName] = GetUserInput(FieldConstants.UserRegistrationField.FirstName, "Please enter your First Name: ");
            _fieldValidator.FieldValues[(int)FieldConstants.UserRegistrationField.LastName] = GetUserInput(FieldConstants.UserRegistrationField.LastName, "Please enter your Last Name : ");
            _fieldValidator.FieldValues[(int)FieldConstants.UserRegistrationField.Password] = GetUserInput(FieldConstants.UserRegistrationField.Password, "Please enter your Password : ");
            _fieldValidator.FieldValues[(int)FieldConstants.UserRegistrationField.DateOfBirth] = GetUserInput(FieldConstants.UserRegistrationField.DateOfBirth, "Please enter your Date Of Birth: ");
            _fieldValidator.FieldValues[(int)FieldConstants.UserRegistrationField.PhoneNumber] = GetUserInput(FieldConstants.UserRegistrationField.PhoneNumber, "Please enter your Mobile Number: ");
            _fieldValidator.FieldValues[(int)FieldConstants.UserRegistrationField.Address] = GetUserInput(FieldConstants.UserRegistrationField.Address, "Please enter your Address: ");
            _fieldValidator.FieldValues[(int)FieldConstants.UserRegistrationField.City] = GetUserInput(FieldConstants.UserRegistrationField.City, "Please enter your City: ");
            _fieldValidator.FieldValues[(int)FieldConstants.UserRegistrationField.Country] = GetUserInput(FieldConstants.UserRegistrationField.Country, "Please enter your Country: ");
            _fieldValidator.FieldValues[(int)FieldConstants.UserRegistrationField.PostCode] = GetUserInput(FieldConstants.UserRegistrationField.PostCode, "Please enter your Postal Code: ");

            RegisterUser();
            
        }

        private void RegisterUser()
        {
            _register.UserRegister(_fieldValidator.FieldValues);
            successfulRegister.RunView();
        }
        
        private string GetUserInput(FieldConstants.UserRegistrationField field, string promptText)
        {
            string fieldvalue = "";
            do
            {
                Console.WriteLine(promptText);
                fieldvalue = Console.ReadLine();
            } while (!FieldValid(field, fieldvalue));

            return fieldvalue;
        }

        private bool FieldValid(FieldConstants.UserRegistrationField field, string fieldValue)
        {
            if(!_fieldValidator.ValidatorDel((int)field,fieldValue, _fieldValidator.FieldValues, out string errorMessage))
            {
                CommonOutputFormat.fontChange(Fonts.Error);
                Console.Write(errorMessage);
                CommonOutputFormat.fontChange(Fonts.Default);
                return false;
            }
            return true;
        }

    }
}
