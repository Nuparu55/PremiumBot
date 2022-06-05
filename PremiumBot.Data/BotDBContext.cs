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
        private string _connectionString;
        public BotDBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(Configuration.DB_CONNECTION_STRING);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Achievment> Achievments { get; set; }
    }
}
