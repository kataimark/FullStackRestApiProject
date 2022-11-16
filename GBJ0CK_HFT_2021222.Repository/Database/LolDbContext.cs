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

            modelBuilder.Entity<LolTeam>().HasData(new LolTeam[]
            {
                new LolTeam("1#1#T1#40#4"),
                new LolTeam("2#2#G2#20#1"),
                new LolTeam("3#3#Astralis#12#0"),
                new LolTeam("4#4#DRX#26#2"),
                new LolTeam("5#5#EDG#21#0"),
            });

            modelBuilder.Entity<LolPlayer>().HasData(new LolPlayer[]
            {
                new LolPlayer("1#1#Zeus#18#Top Laner"),
                new LolPlayer("2#1#Oner#19#Jungler"),
                new LolPlayer("3#1#Faker#26#Mid Laner"),
                new LolPlayer("4#1#Gumayusi#20#Bot Laner"),
                new LolPlayer("5#1#Keria#20#Support"),
                new LolPlayer("6#2#Broken Blade#22#Top Laner"),
                new LolPlayer("7#2#Jankos#27#Jungler"),
                new LolPlayer("8#2#caPs#22#Mid Laner"),
                new LolPlayer("9#2#Flakked#21#Bot Laner"),
                new LolPlayer("10#2#Targamas#22#Support"),
                new LolPlayer("11#3#Vizicsacsi#29#Top Laner"),
                new LolPlayer("12#3#Xerxe#22#Jungler"),
                new LolPlayer("13#3#Dajor#19#Mid Laner"),
                new LolPlayer("14#3#Kobbe#26#Bot Laner"),
                new LolPlayer("15#3#JaeongHoon#22#Support"),
                new LolPlayer("16#4#Kingen#22#Top Laner"),
                new LolPlayer("17#4#Pyosik#22#Jungler"),
                new LolPlayer("18#4#Zeka#19#Mid Laner"),
                new LolPlayer("19#4#Deft#26#Bot Laner"),
                new LolPlayer("20#4#BeryL#25#Support"),
                new LolPlayer("21#5#Flandre#24#Top Laner"),
                new LolPlayer("22#5#Jiejie#21#Jungler"),
                new LolPlayer("23#5#Scout#24#Mid Laner"),
                new LolPlayer("24#5#Viper#22#Bot Laner"),
                new LolPlayer("25#5#Meiko#24#Support"),

            });

            modelBuilder.Entity<LolManager>().HasData(new LolManager[]
            {
                new LolManager("1#Bengi#28"),
                new LolManager("2#Ocelote#32"),
                new LolManager("3#AoD#34"),
                new LolManager("4#Ssong#33"),
                new LolManager("5#Maokai#29"),
            });
        }


        



    }
}
