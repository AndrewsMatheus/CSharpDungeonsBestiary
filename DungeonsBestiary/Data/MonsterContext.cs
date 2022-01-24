using DungeonsBestiary.Classes;
using DungeonsBestiary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsBestiary.Repository
{
    public class MonsterContext : DbContext { 
    
        public DbSet<Monster> Monsters { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<LanguageMonster> LanguageMonsters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder.UseSqlServer("password=123456;Persist Security Info=False;User ID=sa;Initial Catalog=testDB;Data Source=DESKTOP-KB69580");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder
                .Entity<Monster>()
                .HasMany(m => m.Languages)
                .WithMany(l => l.Monsters)
                .UsingEntity<LanguageMonster>(

                    j => j.HasOne(lm => lm.Language).WithMany(l => l.LanguageMonsters).HasForeignKey(lm => lm.LanguageId),
                    j => j.HasOne(lm => lm.Monster).WithMany(l => l.LanguageMonsters).HasForeignKey(lm => lm.MonsterId),
                    j => { j.HasKey(lm => new { lm.MonsterId, lm.LanguageId }); 

                    });

        }
    }
}
