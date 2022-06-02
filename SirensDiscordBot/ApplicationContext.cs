using Microsoft.EntityFrameworkCore;
using SirensDiscordBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace SirensDiscordBot
{
    public class ApplicationContext :DbContext
    {
        public DbSet<DiscordServer> DiscordServers { get; set; }

        public ApplicationContext() => Database.Migrate();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                mySqlOptions =>
                 mySqlOptions.EnableRetryOnFailure(
                     maxRetryCount: 10,
                     maxRetryDelay: TimeSpan.FromSeconds(30),
                     errorNumbersToAdd: null));
        }
    }
}
