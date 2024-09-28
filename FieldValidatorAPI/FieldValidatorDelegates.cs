using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FieldValidatorAPI
{
    public delegate bool RequiredValidDel(string FieldValue);
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
    public delegate bool DateValidDel(string fieldVal, out DateTime validDateTime);
    public delegate bool PatternMatchValidDel(string fieldVal, string pattern);
    public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCompare);
    public class FieldValidatorDelegates
    {
        private static RequiredValidDel _requiredValidDel = null;
        private static StringLengthValidDel _stringLengthValifDel = null;
        private static DateValidDel _dataValidDel = null;
        private static PatternMatchValidDel _patternMatchValidDel = null;
        private static CompareFieldsValidDel _compareFieldsValidDel = null;


        public static RequiredValidDel FieldRequiredValidDel
        {
            get
            {
                if (_requiredValidDel == null)
                    _requiredValidDel = new RequiredValidDel(IsrequiredValidation);
                return _requiredValidDel;
            }
        }

        public static StringLengthValidDel FieldLengthValidDel
        {
            get
            {
                if (_stringLengthValifDel == null)
                    _stringLengthValifDel = new StringLengthValidDel(LengthValidation);
                return _stringLengthValifDel;
            }
        }

        public static DateValidDel FieldDateValidDel
        {
            get
            {
                if (_dataValidDel == null)
                    _dataValidDel = new DateValidDel(DateValidation);
                return _dataValidDel;
            }
        }

        public static PatternMatchValidDel FieldPatternMatchValidDel
        {
            get
            {
                if (_patternMatchValidDel == null)
                    _patternMatchValidDel = new PatternMatchValidDel(PatternMatchValidation);
                return _patternMatchValidDel;
            }
        }

        public static CompareFieldsValidDel FieldComparisionDel
        {
            get
            {
                if (_compareFieldsValidDel == null)
                    _compareFieldsValidDel = new CompareFieldsValidDel(CompareFieldValidation);
                return _compareFieldsValidDel;
            }
        }


        private static bool IsrequiredValidation(string fieldVal)
        {
            if (!string.IsNullOrEmpty(fieldVal))
                return true;

            return false;

        }

        private static bool LengthValidation(string fieldVal, int minLength, int maxLength)
        {
            if (fieldVal.Length <= maxLength && fieldVal.Length >= minLength)
                return true;
            return false;
        }

        private static bool DateValidation(string fieldVal, out DateTime validDateTime)
        {
            if (DateTime.TryParse(fieldVal, out validDateTime))
                return true;
            return false;
        }

        private static bool PatternMatchValidation(string fieldVal, string pattern)
        {
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(fieldVal))
                return true;
            return false;
        }

        private static bool CompareFieldValidation(string fieldVal, string fieldValueCompare)
        {
            if (fieldVal.Equals(fieldValueCompare))
                return true;
            return false;
        }
    }
}
