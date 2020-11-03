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

        public AppContext(DbContextOptions<AppContext> options): base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
