using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Data
{
    internal class Register : IRegister
    {
        public bool EmailExists(string email)
        {
            bool result = false;
            using(var dbcontext = new ClubMembershipDBcontext())
            {
                result = dbcontext.users.Any(u => u.Email.Trim().ToLower() == email.ToLower().Trim());
            }
            return result;
        }

        public bool UserRegister(string[] fields)
        {
           
            using (var dbcontext = new ClubMembershipDBcontext())
            {
                User user = new User
                {
                    Email = fields[(int)FieldConstants.UserRegistrationField.Email],
                    FirstName = fields[(int)FieldConstants.UserRegistrationField.FirstName],
                    LastName = fields[(int)FieldConstants.UserRegistrationField.LastName],
                    Password = fields[(int)FieldConstants.UserRegistrationField.Password],
                    DateOfBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationField.DateOfBirth]),
                    PhoneNumber = fields[(int)FieldConstants.UserRegistrationField.PhoneNumber],
                    Address = fields[(int)FieldConstants.UserRegistrationField.Address],
                    City = fields[(int)FieldConstants.UserRegistrationField.City],
                    Country = fields[(int)FieldConstants.UserRegistrationField.Country],
                    PostCode = fields[(int)FieldConstants.UserRegistrationField.PostCode]
                };
                dbcontext.users.Add(user);
                dbcontext.SaveChanges();
            }
            return true;
        }
    }
}
