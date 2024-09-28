using ClubMembershipApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Data
{
    internal class ClubMembershipDBcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($" Data Source = {AppDomain.CurrentDomain.BaseDirectory}(ClubMembershipDBcontext.db)");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> users { get; set; }
    }
}
