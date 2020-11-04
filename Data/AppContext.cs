using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Data
{
    public class AppContext:DbContext
    {
        public DbSet<ExchangeHistory> Histories { get; set; }

        public AppContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-8TNDF2C\SQLEXPRESS;Initial Catalog=ExchangeDb_1;Integrated Security=True;");
        }
    }
}
