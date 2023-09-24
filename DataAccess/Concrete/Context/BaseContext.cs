using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class BaseContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS; Initial Catalog=WordBank; Integrated Security=SSPI;TrustServerCertificate=True;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Learned> Learneds { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Word>()
                .HasOne(w => w.Category)
                .WithMany(c => c.Words)
                .HasForeignKey(w => w.CategoryId);



            modelBuilder.Entity<Favorites>()
                .HasKey(f => new { f.UserId, f.WordId });
            modelBuilder.Entity<Favorites>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId);
            modelBuilder.Entity<Favorites>()
                .HasOne(f => f.Word)
                .WithMany(w => w.Favorites)
                .HasForeignKey(f => f.WordId);

            modelBuilder.Entity<Learned>()
                .HasKey(l => new { l.UserId, l.WordId});
            modelBuilder.Entity<Learned>()
                .HasOne(l => l.User)
                .WithMany(u => u.Learned)
                .HasForeignKey(l=> l.UserId);
            modelBuilder.Entity<Learned>()
                .HasOne(l => l.Word)
                .WithMany(w => w.Learned)
                .HasForeignKey(l => l.WordId);
             
        }




    }
}
