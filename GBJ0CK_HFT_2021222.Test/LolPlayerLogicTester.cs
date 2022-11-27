using GBJ0CK_HFT_2021222.Logic;
using GBJ0CK_HFT_2021222.Models;
using GBJ0CK_HFT_2021222.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GBJ0CK_HFT_2021222.Test
{
    [TestFixture]
    public class LolPlayerLogicTester
    {

        LolPlayerLogic playerlogic;
        LolTeamLogic teamlogic;
        LolManagerLogic managerlogic;

        [SetUp]
        public void Setup()
        {
            Mock<IRepository<LolPlayer>> mockPlayerRepo = new Mock<IRepository<LolPlayer>>();
            Mock<IRepository<LolTeam>> mockTeamRepo = new Mock<IRepository<LolTeam>>();
            Mock<IRepository<LolManager>> mockManagerRepo = new Mock<IRepository<LolManager>>();

            mockPlayerRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                new LolPlayer()
                {
                    Id = 1,
                    Name = "Feus",
                    Age = 18,
                    Role = "Top Laner",
                    LolTeam_id = 1,
                });

            mockPlayerRepo.Setup(x => x.ReadAll()).Returns(FakeLolPlayerObject);
            mockTeamRepo.Setup(x => x.ReadAll()).Returns(FakeLolTeamObject);
            mockManagerRepo.Setup(x => x.ReadAll()).Returns(FakeLolManagerObject);

            playerlogic = new LolPlayerLogic(mockPlayerRepo.Object, mockTeamRepo.Object, mockManagerRepo.Object);
            managerlogic = new LolManagerLogic(mockPlayerRepo.Object, mockTeamRepo.Object, mockManagerRepo.Object);
            teamlogic = new LolTeamLogic(mockTeamRepo.Object);

        }

        [Test]
        public void GetOneLolPlayer_ReturnsCorrectId()
        {
            Assert.That(playerlogic.Read(1).Id, Is.EqualTo(1));
        }

        [Test]
        public void GetOneLolPlayer_ReturnsCorrectName()
        {
            Assert.That(playerlogic.Read(1).Name, Is.EqualTo("Feus"));
        }
        [Test]
        public void GetOneLolPlayer_ReturnsCorrectAge()
        {
            Assert.That(playerlogic.Read(1).Age, Is.EqualTo(18));
        }

        [Test]
        public void GetOneLolPlayer_ReturnsCorrectRole()
        {
            Assert.That(playerlogic.Read(1).Role, Is.EqualTo("Top Laner"));
        }
        [Test]
        public void GetOneLolPlayer_ReturnsCorrectLolTeamId()
        {
            Assert.That(playerlogic.Read(1).LolTeam_id, Is.EqualTo(1));
        }
        [Test]
        public void GetAlllolplayer_ReturnsExactNumberOfInstances()
        {
            Assert.That(this.playerlogic.ReadAll().Count, Is.EqualTo(12));
        }

        [Test]
        public void GetlolplayerAtTokyo_ReturnsCorrectInstance()
        {
            Assert.That(playerlogic.GetLolplayersAtAgeFourty().Count, Is.EqualTo(4));
        }

        [Test]
        public void GetlolplayerLolTeamPrice_RetursCorrectInstance()
        {
            Assert.That(playerlogic.GetLolPlayerWhereWinIsOverTen().First().LolTeam.Wins, Is.GreaterThanOrEqualTo(10));
        }


        [Test]
        public void GetlolplayerWhereModelName_ReturnsCorrectInstance()
        {
            Assert.That(playerlogic.GetLolplayersWhereTeamNameIsRoll().First().LolTeam.TeamName, Is.EqualTo("ROLL"));
        }

        [Test]
        public void GetLolManagerName()
        {
            Assert.That(managerlogic.GetLolManagertName().Count(), Is.EqualTo(0));
        }

        private IQueryable<LolPlayer> FakeLolPlayerObject()
        {
            LolManager LolManager1 = new LolManager() { Id = 1, ManagerName = "Freid", Age = 22 };
            LolManager LolManager2 = new LolManager() { Id = 2, ManagerName = "Norme", Age = 30 };
            LolManager LolManager3 = new LolManager() { Id = 3, ManagerName = "Drake", Age = 40 };
            LolManager LolManager4 = new LolManager() { Id = 3, ManagerName = "Drake", Age = 40 };
            LolManager LolManager5 = new LolManager() { Id = 3, ManagerName = "Drake", Age = 40 };

            LolManager1.LolTeams = new List<LolTeam>();
            LolManager2.LolTeams = new List<LolTeam>();
            LolManager3.LolTeams = new List<LolTeam>();


            LolTeam LolTeam1 = new LolTeam() { Id = 1, TeamName = "JMOP", Wins = 40, WasChampion = 2, LolManager_id = 1 };
            LolTeam LolTeam2 = new LolTeam() { Id = 2, TeamName = "KNFA", Wins = 60, WasChampion = 5, LolManager_id = 1 };
            LolTeam LolTeam3 = new LolTeam() { Id = 3, TeamName = "WITH", Wins = 20, WasChampion = 1, LolManager_id = 2 };
            LolTeam LolTeam4 = new LolTeam() { Id = 4, TeamName = "SATA", Wins = 30, WasChampion = 3, LolManager_id = 2 };
            LolTeam LolTeam5 = new LolTeam() { Id = 5, TeamName = "DENT", Wins = 65, WasChampion = 4, LolManager_id = 3 };
            LolTeam LolTeam6 = new LolTeam() { Id = 6, TeamName = "ROLL", Wins = 21, WasChampion = 0, LolManager_id = 3 };
            LolTeam LolTeam7 = new LolTeam() { Id = 5, TeamName = "DENT", Wins = 65, WasChampion = 4, LolManager_id = 3 };
            LolTeam LolTeam8 = new LolTeam() { Id = 6, TeamName = "ROLL", Wins = 21, WasChampion = 0, LolManager_id = 3 };

            LolTeam1.LolManager = LolManager1;
            LolTeam2.LolManager = LolManager1;
            LolTeam3.LolManager = LolManager2;
            LolTeam4.LolManager = LolManager2;
            LolTeam5.LolManager = LolManager3;
            LolTeam6.LolManager = LolManager3;

            LolTeam1.LolManager_id = LolManager1.Id; LolManager1.LolTeams.Add(LolTeam1);
            LolTeam2.LolManager_id = LolManager1.Id; LolManager1.LolTeams.Add(LolTeam2);
            LolTeam3.LolManager_id = LolManager2.Id; LolManager2.LolTeams.Add(LolTeam3);
            LolTeam4.LolManager_id = LolManager2.Id; LolManager2.LolTeams.Add(LolTeam4);
            LolTeam5.LolManager_id = LolManager3.Id; LolManager3.LolTeams.Add(LolTeam5);
            LolTeam6.LolManager_id = LolManager3.Id; LolManager3.LolTeams.Add(LolTeam6);

            LolTeam1.LolPlayers = new List<LolPlayer>();
            LolTeam2.LolPlayers = new List<LolPlayer>();
            LolTeam3.LolPlayers = new List<LolPlayer>();
            LolTeam4.LolPlayers = new List<LolPlayer>();
            LolTeam5.LolPlayers = new List<LolPlayer>();
            LolTeam6.LolPlayers = new List<LolPlayer>();


            LolPlayer lolplayer1 = new LolPlayer() { Id = 1, Name = "Huuu-Sy", Age = 19, Role="Top Laner", LolTeam_id = 1 };
            LolPlayer lolplayer2 = new LolPlayer() { Id = 2, Name = "Lee Fei", Age = 20, Role = "Bot Laner", LolTeam_id = 1 };
            LolPlayer lolplayer3 = new LolPlayer() { Id = 3, Name = "Jank", Age = 40, Role = "Mid Laner", LolTeam_id = 2 };
            LolPlayer lolplayer4 = new LolPlayer() { Id = 4, Name = "Rekkl", Age = 32, Role = "Jungle",LolTeam_id = 2 };
            LolPlayer lolplayer5 = new LolPlayer() { Id = 5, Name = "Beifg", Age = 42, Role = "Support" ,LolTeam_id = 3 };
            LolPlayer lolplayer6 = new LolPlayer() { Id = 6, Name = "PPzyang", Age = 16, Role = "Top Laner", LolTeam_id = 3 };
            LolPlayer lolplayer7 = new LolPlayer() { Id = 7, Name = "Fakr", Age = 25, Role = "Top Laner", LolTeam_id = 4 };
            LolPlayer lolplayer8 = new LolPlayer() { Id = 8, Name = "LAst", Age =31, Role = "Bot Laner", LolTeam_id = 4 };
            LolPlayer lolplayer9 = new LolPlayer() { Id = 9, Name = "Vizcsej", Age = 25, Role = "Mid Laner", LolTeam_id = 5 };
            LolPlayer lolplayer10 = new LolPlayer() { Id = 10, Name = "Tesl", Age = 46, Role = "Bot Laner", LolTeam_id = 5 };
            LolPlayer lolplayer11 = new LolPlayer() { Id = 11, Name = "Flqi", Age = 32, Role = "Mid Laner", LolTeam_id = 6 };
            LolPlayer lolplayer12 = new LolPlayer() { Id = 12, Name = "CPys", Age = 25, Role = "Jungle", LolTeam_id = 6 };

            lolplayer1.LolTeam = LolTeam1;
            lolplayer2.LolTeam = LolTeam1;
            lolplayer3.LolTeam = LolTeam2;
            lolplayer4.LolTeam = LolTeam2;
            lolplayer5.LolTeam = LolTeam3;
            lolplayer6.LolTeam = LolTeam3;
            lolplayer7.LolTeam = LolTeam4;
            lolplayer8.LolTeam = LolTeam4;
            lolplayer9.LolTeam = LolTeam5;
            lolplayer10.LolTeam = LolTeam5;
            lolplayer11.LolTeam = LolTeam6;
            lolplayer12.LolTeam = LolTeam6;

            lolplayer1.LolTeam_id = LolTeam1.Id; LolTeam1.LolPlayers.Add(lolplayer1);
            lolplayer2.LolTeam_id = LolTeam1.Id; LolTeam1.LolPlayers.Add(lolplayer2);
            lolplayer3.LolTeam_id = LolTeam2.Id; LolTeam2.LolPlayers.Add(lolplayer3);
            lolplayer4.LolTeam_id = LolTeam2.Id; LolTeam2.LolPlayers.Add(lolplayer4);
            lolplayer5.LolTeam_id = LolTeam3.Id; LolTeam3.LolPlayers.Add(lolplayer5);
            lolplayer6.LolTeam_id = LolTeam3.Id; LolTeam3.LolPlayers.Add(lolplayer6);
            lolplayer7.LolTeam_id = LolTeam4.Id; LolTeam4.LolPlayers.Add(lolplayer7);
            lolplayer8.LolTeam_id = LolTeam4.Id; LolTeam4.LolPlayers.Add(lolplayer8);
            lolplayer9.LolTeam_id = LolTeam5.Id; LolTeam5.LolPlayers.Add(lolplayer9);
            lolplayer10.LolTeam_id = LolTeam5.Id; LolTeam5.LolPlayers.Add(lolplayer10);
            lolplayer11.LolTeam_id = LolTeam6.Id; LolTeam6.LolPlayers.Add(lolplayer11);
            lolplayer12.LolTeam_id = LolTeam6.Id; LolTeam6.LolPlayers.Add(lolplayer12);


            List<LolPlayer> lolplayer = new List<LolPlayer>();
            lolplayer.Add(lolplayer1);
            lolplayer.Add(lolplayer2);
            lolplayer.Add(lolplayer3);
            lolplayer.Add(lolplayer4);
            lolplayer.Add(lolplayer5);
            lolplayer.Add(lolplayer6);
            lolplayer.Add(lolplayer7);
            lolplayer.Add(lolplayer8);
            lolplayer.Add(lolplayer9);
            lolplayer.Add(lolplayer10);
            lolplayer.Add(lolplayer11);
            lolplayer.Add(lolplayer12);
            return lolplayer.AsQueryable();
        }

        private IQueryable<LolTeam> FakeLolTeamObject()
        {
            LolManager LolManager1 = new LolManager() { Id = 1, ManagerName = "Freid", Age = 22 };
            LolManager LolManager2 = new LolManager() { Id = 2, ManagerName = "Norme", Age = 30 };
            LolManager LolManager3 = new LolManager() { Id = 3, ManagerName = "Drake", Age = 40 };

            LolManager1.LolTeams = new List<LolTeam>();
            LolManager2.LolTeams = new List<LolTeam>();
            LolManager3.LolTeams = new List<LolTeam>();


            LolTeam LolTeam1 = new LolTeam() { Id = 1, TeamName = "JMOP", Wins = 40, WasChampion = 2, LolManager_id = 1 };
            LolTeam LolTeam2 = new LolTeam() { Id = 2, TeamName = "KNFA", Wins = 60, WasChampion = 5, LolManager_id = 1 };
            LolTeam LolTeam3 = new LolTeam() { Id = 3, TeamName = "WITH", Wins = 20, WasChampion = 1, LolManager_id = 2 };
            LolTeam LolTeam4 = new LolTeam() { Id = 4, TeamName = "SATA", Wins = 30, WasChampion = 3, LolManager_id = 2 };
            LolTeam LolTeam5 = new LolTeam() { Id = 5, TeamName = "DENT", Wins = 65, WasChampion = 4, LolManager_id = 3 };
            LolTeam LolTeam6 = new LolTeam() { Id = 6, TeamName = "ROLL", Wins = 21, WasChampion = 0, LolManager_id = 3 };

            LolTeam1.LolManager = LolManager1;
            LolTeam2.LolManager = LolManager1;
            LolTeam3.LolManager = LolManager2;
            LolTeam4.LolManager = LolManager2;
            LolTeam5.LolManager = LolManager3;
            LolTeam6.LolManager = LolManager3;

            LolTeam1.LolManager_id = LolManager1.Id; LolManager1.LolTeams.Add(LolTeam1);
            LolTeam2.LolManager_id = LolManager1.Id; LolManager1.LolTeams.Add(LolTeam2);
            LolTeam3.LolManager_id = LolManager2.Id; LolManager2.LolTeams.Add(LolTeam3);
            LolTeam4.LolManager_id = LolManager2.Id; LolManager2.LolTeams.Add(LolTeam4);
            LolTeam5.LolManager_id = LolManager3.Id; LolManager3.LolTeams.Add(LolTeam5);
            LolTeam6.LolManager_id = LolManager3.Id; LolManager3.LolTeams.Add(LolTeam6);

            LolTeam1.LolPlayers = new List<LolPlayer>();
            LolTeam2.LolPlayers = new List<LolPlayer>();
            LolTeam3.LolPlayers = new List<LolPlayer>();
            LolTeam4.LolPlayers = new List<LolPlayer>();
            LolTeam5.LolPlayers = new List<LolPlayer>();
            LolTeam6.LolPlayers = new List<LolPlayer>();


            LolPlayer lolplayer1 = new LolPlayer() { Id = 1, Name = "Huuu-Sy", Age = 19, Role = "Top Laner", LolTeam_id = 1 };
            LolPlayer lolplayer2 = new LolPlayer() { Id = 2, Name = "Lee Fei", Age = 20, Role = "Bot Laner", LolTeam_id = 1 };
            LolPlayer lolplayer3 = new LolPlayer() { Id = 3, Name = "Jank", Age = 40, Role = "Mid Laner", LolTeam_id = 2 };
            LolPlayer lolplayer4 = new LolPlayer() { Id = 4, Name = "Rekkl", Age = 32, Role = "Jungle", LolTeam_id = 2 };
            LolPlayer lolplayer5 = new LolPlayer() { Id = 5, Name = "Beifg", Age = 42, Role = "Support", LolTeam_id = 3 };
            LolPlayer lolplayer6 = new LolPlayer() { Id = 6, Name = "PPzyang", Age = 16, Role = "Top Laner", LolTeam_id = 3 };
            LolPlayer lolplayer7 = new LolPlayer() { Id = 7, Name = "Fakr", Age = 25, Role = "Top Laner", LolTeam_id = 4 };
            LolPlayer lolplayer8 = new LolPlayer() { Id = 8, Name = "LAst", Age = 31, Role = "Bot Laner", LolTeam_id = 4 };
            LolPlayer lolplayer9 = new LolPlayer() { Id = 9, Name = "Vizcsej", Age = 25, Role = "Mid Laner", LolTeam_id = 5 };
            LolPlayer lolplayer10 = new LolPlayer() { Id = 10, Name = "Tesl", Age = 46, Role = "Bot Laner", LolTeam_id = 5 };
            LolPlayer lolplayer11 = new LolPlayer() { Id = 11, Name = "Flqi", Age = 32, Role = "Mid Laner", LolTeam_id = 6 };
            LolPlayer lolplayer12 = new LolPlayer() { Id = 12, Name = "CPys", Age = 25, Role = "Jungle", LolTeam_id = 6 };

            lolplayer1.LolTeam = LolTeam1;
            lolplayer2.LolTeam = LolTeam1;
            lolplayer3.LolTeam = LolTeam2;
            lolplayer4.LolTeam = LolTeam2;
            lolplayer5.LolTeam = LolTeam3;
            lolplayer6.LolTeam = LolTeam3;
            lolplayer7.LolTeam = LolTeam4;
            lolplayer8.LolTeam = LolTeam4;
            lolplayer9.LolTeam = LolTeam5;
            lolplayer10.LolTeam = LolTeam5;
            lolplayer11.LolTeam = LolTeam6;
            lolplayer12.LolTeam = LolTeam6;

            lolplayer1.LolTeam_id = LolTeam1.Id; LolTeam1.LolPlayers.Add(lolplayer1);
            lolplayer2.LolTeam_id = LolTeam1.Id; LolTeam1.LolPlayers.Add(lolplayer2);
            lolplayer3.LolTeam_id = LolTeam2.Id; LolTeam2.LolPlayers.Add(lolplayer3);
            lolplayer4.LolTeam_id = LolTeam2.Id; LolTeam2.LolPlayers.Add(lolplayer4);
            lolplayer5.LolTeam_id = LolTeam3.Id; LolTeam3.LolPlayers.Add(lolplayer5);
            lolplayer6.LolTeam_id = LolTeam3.Id; LolTeam3.LolPlayers.Add(lolplayer6);
            lolplayer7.LolTeam_id = LolTeam4.Id; LolTeam4.LolPlayers.Add(lolplayer7);
            lolplayer8.LolTeam_id = LolTeam4.Id; LolTeam4.LolPlayers.Add(lolplayer8);
            lolplayer9.LolTeam_id = LolTeam5.Id; LolTeam5.LolPlayers.Add(lolplayer9);
            lolplayer10.LolTeam_id = LolTeam5.Id; LolTeam5.LolPlayers.Add(lolplayer10);
            lolplayer11.LolTeam_id = LolTeam6.Id; LolTeam6.LolPlayers.Add(lolplayer11);
            lolplayer12.LolTeam_id = LolTeam6.Id; LolTeam6.LolPlayers.Add(lolplayer12);

            List<LolTeam> LolTeams = new List<LolTeam>();
            LolTeams.Add(LolTeam1);
            LolTeams.Add(LolTeam2);
            LolTeams.Add(LolTeam3);
            LolTeams.Add(LolTeam4);
            LolTeams.Add(LolTeam5);
            LolTeams.Add(LolTeam6);
            return LolTeams.AsQueryable();

        }
        private IQueryable<LolManager> FakeLolManagerObject()
        {
            LolManager LolManager1 = new LolManager() { Id = 1, ManagerName = "Freid", Age = 22 };
            LolManager LolManager2 = new LolManager() { Id = 2, ManagerName = "Norme", Age = 30 };
            LolManager LolManager3 = new LolManager() { Id = 3, ManagerName = "Drake", Age = 40 };

            LolManager1.LolTeams = new List<LolTeam>();
            LolManager2.LolTeams = new List<LolTeam>();
            LolManager3.LolTeams = new List<LolTeam>();

            LolTeam LolTeam1 = new LolTeam() { Id = 1, TeamName = "JMOP", Wins = 40, WasChampion = 2, LolManager_id = 1 };
            LolTeam LolTeam2 = new LolTeam() { Id = 2, TeamName = "KNFA", Wins = 60, WasChampion = 5, LolManager_id = 1 };
            LolTeam LolTeam3 = new LolTeam() { Id = 3, TeamName = "WITH", Wins = 20, WasChampion = 1, LolManager_id = 2 };
            LolTeam LolTeam4 = new LolTeam() { Id = 4, TeamName = "SATA", Wins = 30, WasChampion = 3, LolManager_id = 2 };
            LolTeam LolTeam5 = new LolTeam() { Id = 5, TeamName = "DENT", Wins = 65, WasChampion = 4, LolManager_id = 3 };
            LolTeam LolTeam6 = new LolTeam() { Id = 6, TeamName = "ROLL", Wins = 21, WasChampion = 0, LolManager_id = 3 };

            LolTeam1.LolManager = LolManager1;
            LolTeam2.LolManager = LolManager1;
            LolTeam3.LolManager = LolManager2;
            LolTeam4.LolManager = LolManager2;
            LolTeam5.LolManager = LolManager3;
            LolTeam6.LolManager = LolManager3;

            LolTeam1.LolManager_id = LolManager1.Id; LolManager1.LolTeams.Add(LolTeam1);
            LolTeam2.LolManager_id = LolManager1.Id; LolManager1.LolTeams.Add(LolTeam2);
            LolTeam3.LolManager_id = LolManager2.Id; LolManager2.LolTeams.Add(LolTeam3);
            LolTeam4.LolManager_id = LolManager2.Id; LolManager2.LolTeams.Add(LolTeam4);
            LolTeam5.LolManager_id = LolManager3.Id; LolManager3.LolTeams.Add(LolTeam5);
            LolTeam6.LolManager_id = LolManager3.Id; LolManager3.LolTeams.Add(LolTeam6);

            LolTeam1.LolPlayers = new List<LolPlayer>();
            LolTeam2.LolPlayers = new List<LolPlayer>();
            LolTeam3.LolPlayers = new List<LolPlayer>();
            LolTeam4.LolPlayers = new List<LolPlayer>();
            LolTeam5.LolPlayers = new List<LolPlayer>();
            LolTeam6.LolPlayers = new List<LolPlayer>();


            LolPlayer lolplayer1 = new LolPlayer() { Id = 1, Name = "Huuu-Sy", Age = 19, Role = "Top Laner", LolTeam_id = 1 };
            LolPlayer lolplayer2 = new LolPlayer() { Id = 2, Name = "Lee Fei", Age = 20, Role = "Bot Laner", LolTeam_id = 1 };
            LolPlayer lolplayer3 = new LolPlayer() { Id = 3, Name = "Jank", Age = 40, Role = "Mid Laner", LolTeam_id = 2 };
            LolPlayer lolplayer4 = new LolPlayer() { Id = 4, Name = "Rekkl", Age = 32, Role = "Jungle", LolTeam_id = 2 };
            LolPlayer lolplayer5 = new LolPlayer() { Id = 5, Name = "Beifg", Age = 42, Role = "Support", LolTeam_id = 3 };
            LolPlayer lolplayer6 = new LolPlayer() { Id = 6, Name = "PPzyang", Age = 16, Role = "Top Laner", LolTeam_id = 3 };
            LolPlayer lolplayer7 = new LolPlayer() { Id = 7, Name = "Fakr", Age = 25, Role = "Top Laner", LolTeam_id = 4 };
            LolPlayer lolplayer8 = new LolPlayer() { Id = 8, Name = "LAst", Age = 31, Role = "Bot Laner", LolTeam_id = 4 };
            LolPlayer lolplayer9 = new LolPlayer() { Id = 9, Name = "Vizcsej", Age = 25, Role = "Mid Laner", LolTeam_id = 5 };
            LolPlayer lolplayer10 = new LolPlayer() { Id = 10, Name = "Tesl", Age = 46, Role = "Bot Laner", LolTeam_id = 5 };
            LolPlayer lolplayer11 = new LolPlayer() { Id = 11, Name = "Flqi", Age = 32, Role = "Mid Laner", LolTeam_id = 6 };
            LolPlayer lolplayer12 = new LolPlayer() { Id = 12, Name = "CPys", Age = 25, Role = "Jungle", LolTeam_id = 6 };

            lolplayer1.LolTeam = LolTeam1;
            lolplayer2.LolTeam = LolTeam1;
            lolplayer3.LolTeam = LolTeam2;
            lolplayer4.LolTeam = LolTeam2;
            lolplayer5.LolTeam = LolTeam3;
            lolplayer6.LolTeam = LolTeam3;
            lolplayer7.LolTeam = LolTeam4;
            lolplayer8.LolTeam = LolTeam4;
            lolplayer9.LolTeam = LolTeam5;
            lolplayer10.LolTeam = LolTeam5;
            lolplayer11.LolTeam = LolTeam6;
            lolplayer12.LolTeam = LolTeam6;

            lolplayer1.LolTeam_id = LolTeam1.Id; LolTeam1.LolPlayers.Add(lolplayer1);
            lolplayer2.LolTeam_id = LolTeam1.Id; LolTeam1.LolPlayers.Add(lolplayer2);
            lolplayer3.LolTeam_id = LolTeam2.Id; LolTeam2.LolPlayers.Add(lolplayer3);
            lolplayer4.LolTeam_id = LolTeam2.Id; LolTeam2.LolPlayers.Add(lolplayer4);
            lolplayer5.LolTeam_id = LolTeam3.Id; LolTeam3.LolPlayers.Add(lolplayer5);
            lolplayer6.LolTeam_id = LolTeam3.Id; LolTeam3.LolPlayers.Add(lolplayer6);
            lolplayer7.LolTeam_id = LolTeam4.Id; LolTeam4.LolPlayers.Add(lolplayer7);
            lolplayer8.LolTeam_id = LolTeam4.Id; LolTeam4.LolPlayers.Add(lolplayer8);
            lolplayer9.LolTeam_id = LolTeam5.Id; LolTeam5.LolPlayers.Add(lolplayer9);
            lolplayer10.LolTeam_id = LolTeam5.Id; LolTeam5.LolPlayers.Add(lolplayer10);
            lolplayer11.LolTeam_id = LolTeam6.Id; LolTeam6.LolPlayers.Add(lolplayer11);
            lolplayer12.LolTeam_id = LolTeam6.Id; LolTeam6.LolPlayers.Add(lolplayer12);

            

            List<LolManager> LolManagers = new List<LolManager>();
            LolManagers.Add(LolManager1);
            LolManagers.Add(LolManager2);
            LolManagers.Add(LolManager3);
            return LolManagers.AsQueryable();

        }
    }
}
