using System;
using FieldValidatorAPI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMembershipApplication.Data;


namespace ClubMembershipApplication.FieldValidators
{

    internal class UserRegistrationValidation : IFieldValidator
    {
        const int FirstName_Min_Length = 2;
        const int FirstName_Max_Length = 100;
        const int LastName_Min_Length = 2;
        const int LastName_Max_Length = 100;

        delegate bool EmailExistsDel(string emailAddress);

        EmailExistsDel _emailExistsDel = null;
        IRegister _register = null;

        string[] _fieldArray = null;

         FieldValidatorDel _fieldValidatorDel = null;
         RequiredValidDel _fieldrequiredValidDel = null;
         DateValidDel _fieldDateValidDel = null;
         StringLengthValidDel _fieldLengthValidDel = null;
         CompareFieldsValidDel _fieldsCompareValidDel = null;
         PatternMatchValidDel _fieldPatternmatchValidDel = null;

        public UserRegistrationValidation(IRegister register)
        {
            _register = register;
        }
        
        
        public string[] FieldValues
        {
            get
            {
                if (_fieldArray == null)
                    _fieldArray = new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationField)).Length];
                return _fieldArray;
            }
        }

        public FieldValidatorDel ValidatorDel
        {
            get
            {
                if (_fieldValidatorDel == null)
                    _fieldValidatorDel = new FieldValidatorDel(ValidFields);
                return _fieldValidatorDel;
            }
        }
       

        public void initializeValidatorDels()
        {
            _fieldValidatorDel = ValidatorDel;
            _emailExistsDel = new EmailExistsDel(_register.EmailExists);

            _fieldrequiredValidDel = FieldValidatorDelegates.FieldRequiredValidDel;
            _fieldDateValidDel= FieldValidatorDelegates.FieldDateValidDel;
            _fieldLengthValidDel= FieldValidatorDelegates.FieldLengthValidDel;
            _fieldPatternmatchValidDel= FieldValidatorDelegates.FieldPatternMatchValidDel;
            _fieldsCompareValidDel = FieldValidatorDelegates.FieldComparisionDel;

        }


        private bool ValidFields(int fieldIndex, string fieldValue, string[] fields, out string errorMessage)
        {
            errorMessage = "";
            FieldConstants.UserRegistrationField userRegistrationField = (FieldConstants.UserRegistrationField)fieldIndex;

            switch(userRegistrationField)
            {
                case FieldConstants.UserRegistrationField.Email:
                    errorMessage = (!_fieldrequiredValidDel(fieldValue)) ? $"Please enter a valid {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine} : " : "";
                    errorMessage = (errorMessage == "" && (!_fieldPatternmatchValidDel(fieldValue, CommonRegularExpressions.Email_Address_RegEx_Pattern))) ? $"Your email must contain a valid domain name{Environment.NewLine} : " : errorMessage;
                    
                    break;
                    

                case FieldConstants.UserRegistrationField.Password:
                    errorMessage = (!_fieldrequiredValidDel(fieldValue)) ? $"Please enter a valid {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine} : " : "";
                    errorMessage = (errorMessage=="" && (!_fieldPatternmatchValidDel(fieldValue, CommonRegularExpressions.Strong_Password_RegEx_Pattern))) ? $"Your password must contain at least 1 small-case letter, 1 capital letter, 1 special character and the length should be between 6 - 10 characters{Environment.NewLine} : " : errorMessage;
                    break;

                case FieldConstants.UserRegistrationField.FirstName:
                    errorMessage = (!_fieldrequiredValidDel(fieldValue)) ? $"Please enter a valid {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine} : " : "";
                    errorMessage = (errorMessage=="" && !_fieldLengthValidDel(fieldValue, FirstName_Min_Length, FirstName_Max_Length)) ? $"The length for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} must be between {FirstName_Min_Length} and {FirstName_Max_Length}{Environment.NewLine}" : errorMessage;
                    break;

                case FieldConstants.UserRegistrationField.LastName:
                    errorMessage = (!_fieldrequiredValidDel(fieldValue)) ? $"Please enter a valid {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine} : " : "";
                    errorMessage = (errorMessage == "" && !_fieldLengthValidDel(fieldValue, LastName_Min_Length, LastName_Max_Length)) ? $"The length for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} must be between {LastName_Min_Length} and {LastName_Max_Length}{Environment.NewLine}" : errorMessage;
                    break;

                case FieldConstants.UserRegistrationField.DateOfBirth:
                    errorMessage = (!_fieldrequiredValidDel(fieldValue)) ? $"Please enter a valid {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine} : " : "";
                    errorMessage = (errorMessage == "" && !_fieldDateValidDel(fieldValue, out DateTime validDateTime)) ?  $"You did not enter a valid date{Environment.NewLine}" : errorMessage;
                    break;

                case FieldConstants.UserRegistrationField.Address:
                    errorMessage = (!_fieldrequiredValidDel(fieldValue)) ? $"Please enter a valid {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine} : " : "";
                    break;

                case FieldConstants.UserRegistrationField.City:
                    errorMessage = (!_fieldrequiredValidDel(fieldValue)) ? $"Please enter a valid {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine} : " : "";
                    break;
                case FieldConstants.UserRegistrationField.PhoneNumber:
                    errorMessage = (!_fieldrequiredValidDel(fieldValue)) ? $"Please enter a valid {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine} : " : "";
                    errorMessage = errorMessage=="" && !_fieldPatternmatchValidDel(fieldValue, CommonRegularExpressions.Uk_PhoneNumber_RegEx_Pattern) ? $"You did not enter a valid UK phone number{Environment.NewLine}" : errorMessage;
                    break;
                case FieldConstants.UserRegistrationField.PostCode:
                    errorMessage = (!_fieldrequiredValidDel(fieldValue)) ? $"Please enter a valid {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine} : " : "";
                    errorMessage = errorMessage == "" && !_fieldPatternmatchValidDel(fieldValue, CommonRegularExpressions.Uk_Post_Code_RegEx_Pattern) ? $"You did not enter a valid UK postal code{Environment.NewLine}" : errorMessage;
                    break;
                case FieldConstants.UserRegistrationField.Country:
                    errorMessage = (!_fieldrequiredValidDel(fieldValue)) ? $"Please enter a valid {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine} : " : "";
                    break;

            }
            return (errorMessage == "");
        }
    }
}
