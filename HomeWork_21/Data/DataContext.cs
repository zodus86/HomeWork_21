using HomeWork_21.Data.AuthApp;
using HomeWork_21.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_21.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<PhoneBook> PhoneBooks { get; set; }

        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source = ZCORP; Initial Catalog = HM21; Integrated Security = True");
        //}
    }
}
