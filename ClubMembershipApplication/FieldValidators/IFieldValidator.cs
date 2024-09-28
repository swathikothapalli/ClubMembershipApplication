using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.FieldValidators
{
    public delegate bool FieldValidatorDel(int fieldIndex, String fieldValue, String[] fields, out string errormessage);

    internal interface IFieldValidator
    { 
        void initializeValidatorDels();
        string[] FieldValues { get; }
        FieldValidatorDel ValidatorDel { get;  }

    }
}
