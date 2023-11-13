using KalbeTest.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace KalbeTest.DataContext
{
    public class BaseContext : DbContext
    {

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }
        public DbSet<Study> Studies { get; set; }
        public DbSet<StudyStatus> StudyStatuses { get; set; }
        public DbSet<Molecules> Molecules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseSqlServer(@"Data Source=DESKTOP-TJQ5RPI;Initial Catalog=KalbeTest;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
