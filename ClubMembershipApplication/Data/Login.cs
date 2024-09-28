using ClubMembershipApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Data
{
    internal class Login : ILogin
    {
        public User UserLogin(string email, string password)
        {
            User user = null;
            using(var dbcontext = new ClubMembershipDBcontext())
            {
                user = dbcontext.users.FirstOrDefault(u => u.Email.Trim().ToLower() == email.Trim().ToLower() && u.Password==password);
            }
            return user;

        }
    }
}
