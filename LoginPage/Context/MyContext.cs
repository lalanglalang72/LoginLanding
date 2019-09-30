using LoginPage.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPage.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("DbConnectionString")
        {
        }

        public DbSet<Users> Users { get; set; }
    }
}
