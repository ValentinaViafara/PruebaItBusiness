using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Prueba_AsfiCredito.Database
{
    public class MyDbContext : DbContext {

        public DbSet<Client> Clients { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<DateTask> DatesTask { get; set; }
        public DbSet<TaskSchedule> TaskSchedules { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder.UseSqlite("Data Source=.it_business.db",sqliteOptionsAction: op =>{
                op.MigrationsAssembly(
                    System.Reflection.Assembly.GetExecutingAssembly().FullName
                );
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Client>(entity=>{
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Area>().ToTable("Areas");
            modelBuilder.Entity<Area>(entity=>{
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Activity>().ToTable("Activities");
            modelBuilder.Entity<Activity>(entity=>{
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<DateTask>().ToTable("DatesTask");
            modelBuilder.Entity<DateTask>(entity=>{
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<TaskSchedule>().ToTable("Tasks");
            modelBuilder.Entity<TaskSchedule>(entity=>{
                entity.HasKey(e => new {e.IdClient, e.IdArea, e.IdActivity, e.IdDateTask});
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}