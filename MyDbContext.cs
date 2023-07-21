using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotLogbook
{
    public class MyDbContext : DbContext
    {

        public DbSet<PilotID> Pilots { get; set; }
        internal DbSet<Logbook> Logbooks { get; set; }
        public DbSet<Certifications> Certs { get; set; }
        public DbSet<Ratings> Rates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: Fix this!!
            if (Preferences.Default.Get("LocalDB","") == "Local")
            {
                optionsBuilder.UseSqlite("Data Source=MyDatabase.db");
            }
            else
            {

                try
                {
                    optionsBuilder.UseSqlite("Data Source=server_ip_or_domain;Port=port_number;Database=your_database_name;User Id=username;Password=password;");
                    //Example: optionsBuilder.UseSqlite("Data Source=myserver.com;Port=5432;Database=mydatabase;User Id=myusername;Password=mypassword;");
                }
                catch (Exception)
                {

                    throw;
                }   

            }
        }

        protected override void OnModelCreating(ModelBuilder mod)
        {
            mod.Entity<Certifications>().HasKey(e => e.Number);
            mod.Entity<Logbook>().HasKey(e => e.LogbookID);
            mod.Entity<Ratings>().HasKey(e => e.RatingID);
            mod.Entity<PilotID>().HasMany(p => p.Logbooks).WithOne(l => l.pilot);
            mod.Entity<PilotID>().HasMany(p => p.Certifications).WithOne(l => l.pilot);
            mod.Entity<PilotID>().HasMany(p => p.Ratings).WithOne(l => l.pilot);
        }
    }
}
