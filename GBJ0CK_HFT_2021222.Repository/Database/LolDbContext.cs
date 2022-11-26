using GBJ0CK_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GBJ0CK_HFT_2021222.Repository
{
    public class LolDbContext : DbContext
    {

        public DbSet<LolPlayer> LolPlayers { get; set; }
        public DbSet<LolTeam> LolTeams { get; set; }
        public DbSet<LolManager> LolManagers { get; set; }

        public LolDbContext()
        {
            this.Database.EnsureCreated();
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                
                builder.UseLazyLoadingProxies();
                builder.UseInMemoryDatabase("Lol");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<LolTeam>(entity =>
            {
                entity.HasOne(lolteam => lolteam.LolManager)
                    .WithMany(lolmanager => lolmanager.LolTeams)
                    .HasForeignKey(lolteam => lolteam.LolManager_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<LolPlayer>(entity =>
            {
                entity.HasOne(lolplayer => lolplayer.LolTeam)
                    .WithMany(lolteam => lolteam.LolPlayers)
                    .HasForeignKey(lolplayer => lolplayer.LolTeam_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            LolManager LolManager1 = new LolManager() { Id = 1, ManagerName = "Bengi", Age = 28 };
            LolManager LolManager2 = new LolManager() { Id = 2, ManagerName = "Ocelote", Age = 32 };
            LolManager LolManager3 = new LolManager() { Id = 3, ManagerName = "AoD", Age = 34 };
            LolManager LolManager4 = new LolManager() { Id = 4, ManagerName = "Ssong", Age = 33 };
            LolManager LolManager5 = new LolManager() { Id = 5, ManagerName = "Maokai", Age = 29 };

            LolTeam LolTeam1 = new LolTeam() { Id = 1, TeamName = "T1", Wins = 40, WasChampion=4, LolManager_id = 1 };
            LolTeam LolTeam2 = new LolTeam() { Id = 2, TeamName = "G2", Wins = 20, WasChampion = 1, LolManager_id = 2 };
            LolTeam LolTeam3 = new LolTeam() { Id = 3, TeamName = "Astralis", Wins = 12, WasChampion = 0, LolManager_id = 3 };
            LolTeam LolTeam4 = new LolTeam() { Id = 4, TeamName = "DRX", Wins = 26, WasChampion = 2, LolManager_id = 4 };
            LolTeam LolTeam5 = new LolTeam() { Id = 5, TeamName = "EDG", Wins = 21, WasChampion = 3, LolManager_id = 5 };
            

            LolPlayer LolPlayer1 = new LolPlayer() { Id = 1, Name = "Zeus", Age = 18, Role= "Top Laner", LolTeam_id = 1 };
            LolPlayer LolPlayer2 = new LolPlayer() { Id = 2, Name = "Oner", Age = 19, Role = "Jungler", LolTeam_id = 1 };
            LolPlayer LolPlayer3 = new LolPlayer() { Id = 3, Name = "Faker", Age = 26, Role = "Mid Laner", LolTeam_id = 1 };
            LolPlayer LolPlayer4 = new LolPlayer() { Id = 4, Name = "Gumayusi", Age = 20, Role = "Bot Laner", LolTeam_id = 1 };
            LolPlayer LolPlayer5 = new LolPlayer() { Id = 5, Name = "Keria", Age = 20, Role = "Support", LolTeam_id = 1 };
            LolPlayer LolPlayer6 = new LolPlayer() { Id = 6, Name = "Broken Blade", Age = 22, Role = "Top Laner", LolTeam_id = 2 };
            LolPlayer LolPlayer7 = new LolPlayer() { Id = 7, Name = "Jankos", Age = 27, Role = "Jungler", LolTeam_id = 2 };
            LolPlayer LolPlayer8 = new LolPlayer() { Id = 8, Name = "caPs", Age = 22, Role = "Mid Laner", LolTeam_id = 2 };
            LolPlayer LolPlayer9 = new LolPlayer() { Id = 9, Name = "Flakked", Age = 21, Role = "Bot Laner", LolTeam_id = 2 };
            LolPlayer LolPlayer10 = new LolPlayer() { Id = 10, Name = "Targamas", Age = 22, Role = "Support", LolTeam_id = 2 };
            LolPlayer LolPlayer11 = new LolPlayer() { Id = 11, Name = "Vizicsacsi", Age = 29, Role = "Top Laner", LolTeam_id = 3 };
            LolPlayer LolPlayer12 = new LolPlayer() { Id = 12, Name = "Xerxe", Age = 22, Role = "Jungler", LolTeam_id = 3 };
            LolPlayer LolPlayer13 = new LolPlayer() { Id = 13, Name = "Dajor", Age = 19, Role = "Mid Laner", LolTeam_id = 3 };
            LolPlayer LolPlayer14 = new LolPlayer() { Id = 14, Name = "Kobbe", Age = 26, Role = "Bot Laner", LolTeam_id = 3 };
            LolPlayer LolPlayer15 = new LolPlayer() { Id = 15, Name = "JaeongHoon", Age = 22, Role = "Support", LolTeam_id = 3 };
            LolPlayer LolPlayer16 = new LolPlayer() { Id = 16, Name = "Kingen", Age = 22, Role = "Top Laner", LolTeam_id = 4 };
            LolPlayer LolPlayer17 = new LolPlayer() { Id = 17, Name = "Pyosik", Age = 22, Role = "Jungler", LolTeam_id = 4 };
            LolPlayer LolPlayer18 = new LolPlayer() { Id = 18, Name = "Zeka", Age = 19, Role = "Mid Laner", LolTeam_id = 4 };
            LolPlayer LolPlayer19 = new LolPlayer() { Id = 19, Name = "Deft", Age = 26, Role = "Bot Laner", LolTeam_id = 4 };
            LolPlayer LolPlayer20 = new LolPlayer() { Id = 20, Name = "BeryL", Age = 25, Role = "Support", LolTeam_id = 4 };
            LolPlayer LolPlayer21 = new LolPlayer() { Id = 21, Name = "Flandre", Age = 24, Role = "Top Laner", LolTeam_id = 5 };
            LolPlayer LolPlayer22 = new LolPlayer() { Id = 22, Name = "Jiejie", Age = 21, Role = "Jungler", LolTeam_id = 5 };
            LolPlayer LolPlayer23 = new LolPlayer() { Id = 23, Name = "Scout", Age = 24, Role = "Mid Laner", LolTeam_id = 5 };
            LolPlayer LolPlayer24 = new LolPlayer() { Id = 24, Name = "Viper", Age = 22, Role = "Bot Laner", LolTeam_id = 5 };
            LolPlayer LolPlayer25 = new LolPlayer() { Id = 25, Name = "Meiko", Age = 24, Role = "Support", LolTeam_id = 5 };
            

            modelBuilder.Entity<LolManager>().HasData(LolManager1, LolManager2, LolManager3, LolManager5);       
            modelBuilder.Entity<LolTeam>().HasData(LolTeam1, LolTeam2, LolTeam3, LolTeam4, LolTeam5);
            modelBuilder.Entity<LolPlayer>().HasData(LolPlayer1, LolPlayer2, LolPlayer3, LolPlayer4, LolPlayer5, LolPlayer6, LolPlayer7, LolPlayer8, LolPlayer9, LolPlayer10, LolPlayer11, LolPlayer12, LolPlayer13, LolPlayer14, LolPlayer15, LolPlayer16, LolPlayer17, LolPlayer18, LolPlayer19, LolPlayer20, LolPlayer21, LolPlayer22, LolPlayer23, LolPlayer24, LolPlayer25);

        }
    }
}
