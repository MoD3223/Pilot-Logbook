﻿using Microsoft.EntityFrameworkCore;

namespace PilotLogbook
{
    public class MyDbContext : DbContext
    {

        public DbSet<PilotID> Pilots { get; set; }
        internal DbSet<Logbook> Logbooks { get; set; }
        public DbSet<Certifications> Certifications { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
        public DbSet<SyntheticLogbook> SynthethicFlights { get; set; }
        public DbSet<MedicalCertificates> MedicalCerts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (MainPage.IsLocal)
            {
                #if WINDOWS
                optionsBuilder.UseSqlite("Data Source=MyDatabase.db");
                #endif
                #if ANDROID
                optionsBuilder.UseSqlite($"Data Source={FileSystem.AppDataDirectory}/MyDatabase.db");
                #endif
            }
            else
            {

                try
                {
                    optionsBuilder.UseSqlite($"Data Source={ExternalDatabaseLogin.DomainName};Port={ExternalDatabaseLogin.PortNumber};Database={ExternalDatabaseLogin.DatabaseName};User Id={ExternalDatabaseLogin.Login};Password={ExternalDatabaseLogin.Password};");
                    //Example: optionsBuilder.UseSqlite("Data Source=myserver.com;Port=5432;Database=mydatabase;User Id=myusername;Password=mypassword;");
                }
                catch (Exception)
                {
                    //TODO: Give some sort of error
                    throw;
                }   

            }
        }

        protected override void OnModelCreating(ModelBuilder mod)
        {
            mod.Entity<Certifications>().HasKey(e => e.Number);
            mod.Entity<Logbook>().HasKey(e => e.LogbookID);
            mod.Entity<Ratings>().HasKey(e => e.RatingID);
            mod.Entity<SyntheticLogbook>().HasKey(s => s.SynthID);
            mod.Entity<MedicalCertificates>().HasKey(m => m.MedicalID);


            mod.Entity<PilotID>().HasMany(p => p.Logbooks).WithOne(l => l.pilot);
            mod.Entity<PilotID>().HasMany(p => p.Certifications).WithOne(l => l.pilot);
            mod.Entity<PilotID>().HasMany(p => p.Ratings).WithOne(l => l.pilot);
            mod.Entity<PilotID>().HasMany(p => p.Synths).WithOne(s => s.pilot);
            mod.Entity<PilotID>().HasMany(p => p.Med).WithOne(m => m.pilot);


            mod.Entity<SyntheticLogbook>().Property(t => t.TotalTime).HasColumnType("TEXT"); //Changing from TimeSpan to TEXT because SQLite doesn't support TimeSpan values
        }
    }
}
