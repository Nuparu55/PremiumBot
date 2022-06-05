using Microsoft.EntityFrameworkCore;
using PremiumBot.Data.Models;
using PremiumBot.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumBot.Data
{
    public class BotDBContext : DbContext
    {
        public BotDBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlite(Configuration.DB_CONNECTION_STRING);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Achievment> Achievments { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Juice> Juices { get; set; }
    }
}
