using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<PhoneBook> PhoneBooks { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    }
}
