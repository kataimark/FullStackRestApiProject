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

        //CRUD------------------------------------------------------------------------------------------------------------

        [TestCase("TestName", "TestRole", true)]
        [TestCase("TestName123", "TestRole123", false)]
        [TestCase("", "", false)]
        

        [TestCase("TestTeamName", 0, true)]
        [TestCase("TestTeamName", -10, false)]
        [TestCase("", 100000, false)]
        public void CreateLolTeamTest(string teamname, int wins, bool result)
        {
            if (result)
            {
                Assert.That(() => { teamlogic.Create(new LolTeam() { TeamName = teamname, Wins = wins }); }, Throws.Nothing);
            }
            else
            {
                Assert.That(() => { teamlogic.Create(new LolTeam() { TeamName = teamname, Wins = wins }); }, Throws.Exception);

            }
        }


        [TestCase("TestManagerName", 20, true)]
        [TestCase("", 0, false)]
        [TestCase("TestManagerName123", 1200, false)]
        public void CreateLolManagerTest(string managername, int age, bool result)
        {
            if (result)
            {
                Assert.That(() => { managerlogic.Create(new LolManager() { ManagerName = managername, Age = age }); }, Throws.Nothing);
            }
            else
            {
                Assert.That(() => { managerlogic.Create(new LolManager() { ManagerName = managername, Age = age }); }, Throws.Exception);

            }
        }


        [TestCase(20)]
        [TestCase(50)]
        [TestCase(100)]
        public void GetOneLolPlayer_ThrowsException_WhenIdIsToBig(int idx)
        {
            Assert.That(() => this.playerlogic.Read(idx), Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void GetOneLolPlayer_ReturnsCorrectInstance()
        {
            Assert.That(playerlogic.Read(1).Name, Is.EqualTo("Freid"));
        }
        [Test]
        public void GetAllPass_ReturnsExactNumberOfInstances()
        {
            Assert.That(this.playerlogic.ReadAll().Count, Is.EqualTo(12));
        }



        //non-CRUD------------------------------------------------------------------------------------------------------------
        [Test]
        public void GetPassAtTokyo_ReturnsCorrectInstance()
        {
            Assert.That(playerlogic.GetLolplayersAtAgeFourty().Count, Is.EqualTo(40));
        }

        [Test]
        public void GetPassLolTeamPrice_RetursCorrectInstance()
        {
            Assert.That(playerlogic.GetLolPlayerWhereWinIsOverTen().First().LolTeam.Wins, Is.GreaterThanOrEqualTo(10));
        }


        [Test]
        public void GetPassWhereModelName_ReturnsCorrectInstance()
        {
            Assert.That(playerlogic.GetLolplayersWhereTeamNameIsRoll().First().LolTeam.TeamName, Is.EqualTo("ROLL"));
        }

        [Test]
        public void GetLolManagerName()
        {
            Assert.That(managerlogic.GetLolManagertName().Count(), Is.EqualTo(1));
        }

        private IQueryable<LolPlayer> FakeLolPlayerObject()
        {
            LolManager LolManager1 = new LolManager() { Id = 1, ManagerName = "Freid", Age = 22 };
            LolManager LolManager2 = new LolManager() { Id = 2, ManagerName = "Norme", Age = 30 };
            LolManager LolManager3 = new LolManager() { Id = 3, ManagerName = "Drake", Age = 40 };

            LolManager1.LolTeams = new List<LolTeam>();
            LolManager2.LolTeams = new List<LolTeam>();
            LolManager3.LolTeams = new List<LolTeam>();

            // -------------------------------------------------------------------------------------------------------

            LolTeam LolTeam1 = new LolTeam() { Id = 1, TeamName = "JMOP", Wins = 40, WasChampion=2,LolManager_id = 1 };
            LolTeam LolTeam2 = new LolTeam() { Id = 2, TeamName = "KNFA", Wins = 60, WasChampion = 5 ,LolManager_id = 1 };
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

            // -------------------------------------------------------------------------------------------------------

            LolPlayer pass1 = new LolPlayer() { Id = 1, Name = "Huuu-Sy", Age = 19, Role="Top Laner", LolTeam_id = 1 };
            LolPlayer pass2 = new LolPlayer() { Id = 2, Name = "Lee Fei", Age = 20, Role = "Bot Laner", LolTeam_id = 1 };
            LolPlayer pass3 = new LolPlayer() { Id = 3, Name = "Jank", Age = 40, Role = "Mid Laner", LolTeam_id = 2 };
            LolPlayer pass4 = new LolPlayer() { Id = 4, Name = "Rekkl", Age = 32, Role = "Jungle",LolTeam_id = 2 };
            LolPlayer pass5 = new LolPlayer() { Id = 5, Name = "Beifg", Age = 42, Role = "Support" ,LolTeam_id = 3 };
            LolPlayer pass6 = new LolPlayer() { Id = 6, Name = "PPzyang", Age = 16, Role = "Top Laner", LolTeam_id = 3 };
            LolPlayer pass7 = new LolPlayer() { Id = 7, Name = "Fakr", Age = 25, Role = "Top Laner", LolTeam_id = 4 };
            LolPlayer pass8 = new LolPlayer() { Id = 8, Name = "LAst", Age =31, Role = "Bot Laner", LolTeam_id = 4 };
            LolPlayer pass9 = new LolPlayer() { Id = 9, Name = "Vizcsej", Age = 25, Role = "Mid Laner", LolTeam_id = 5 };
            LolPlayer pass10 = new LolPlayer() { Id = 10, Name = "Tesl", Age = 46, Role = "Bot Laner", LolTeam_id = 5 };
            LolPlayer pass11 = new LolPlayer() { Id = 11, Name = "Flqi", Age = 32, Role = "Mid Laner", LolTeam_id = 6 };
            LolPlayer pass12 = new LolPlayer() { Id = 12, Name = "CPys", Age = 25, Role = "Jungle", LolTeam_id = 6 };

            pass1.LolTeam = LolTeam1;
            pass2.LolTeam = LolTeam1;
            pass3.LolTeam = LolTeam2;
            pass4.LolTeam = LolTeam2;
            pass5.LolTeam = LolTeam3;
            pass6.LolTeam = LolTeam3;
            pass7.LolTeam = LolTeam4;
            pass8.LolTeam = LolTeam4;
            pass9.LolTeam = LolTeam5;
            pass10.LolTeam = LolTeam5;
            pass11.LolTeam = LolTeam6;
            pass12.LolTeam = LolTeam6;

            pass1.LolTeam_id = LolTeam1.Id; LolTeam1.LolPlayers.Add(pass1);
            pass2.LolTeam_id = LolTeam1.Id; LolTeam1.LolPlayers.Add(pass2);
            pass3.LolTeam_id = LolTeam2.Id; LolTeam2.LolPlayers.Add(pass3);
            pass4.LolTeam_id = LolTeam2.Id; LolTeam2.LolPlayers.Add(pass4);
            pass5.LolTeam_id = LolTeam3.Id; LolTeam3.LolPlayers.Add(pass5);
            pass6.LolTeam_id = LolTeam3.Id; LolTeam3.LolPlayers.Add(pass6);
            pass7.LolTeam_id = LolTeam4.Id; LolTeam4.LolPlayers.Add(pass7);
            pass8.LolTeam_id = LolTeam4.Id; LolTeam4.LolPlayers.Add(pass8);
            pass9.LolTeam_id = LolTeam5.Id; LolTeam5.LolPlayers.Add(pass9);
            pass10.LolTeam_id = LolTeam5.Id; LolTeam5.LolPlayers.Add(pass10);
            pass11.LolTeam_id = LolTeam6.Id; LolTeam6.LolPlayers.Add(pass11);
            pass12.LolTeam_id = LolTeam6.Id; LolTeam6.LolPlayers.Add(pass12);

            // -------------------------------------------------------------------------------------------------------

            List<LolPlayer> pass = new List<LolPlayer>();
            pass.Add(pass1);
            pass.Add(pass2);
            pass.Add(pass3);
            pass.Add(pass4);
            pass.Add(pass5);
            pass.Add(pass6);
            pass.Add(pass7);
            pass.Add(pass8);
            pass.Add(pass9);
            pass.Add(pass10);
            pass.Add(pass11);
            pass.Add(pass12);
            return pass.AsQueryable();
        }

        private IQueryable<LolTeam> FakeLolTeamObject()
        {
            LolManager LolManager1 = new LolManager() { Id = 1, ManagerName = "Freid", Age = 22 };
            LolManager LolManager2 = new LolManager() { Id = 2, ManagerName = "Norme", Age = 30 };
            LolManager LolManager3 = new LolManager() { Id = 3, ManagerName = "Drake", Age = 40 };

            LolManager1.LolTeams = new List<LolTeam>();
            LolManager2.LolTeams = new List<LolTeam>();
            LolManager3.LolTeams = new List<LolTeam>();

            // -------------------------------------------------------------------------------------------------------

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

            // -------------------------------------------------------------------------------------------------------

            LolPlayer pass1 = new LolPlayer() { Id = 1, Name = "Huuu-Sy", Age = 19, Role = "Top Laner", LolTeam_id = 1 };
            LolPlayer pass2 = new LolPlayer() { Id = 2, Name = "Lee Fei", Age = 20, Role = "Bot Laner", LolTeam_id = 1 };
            LolPlayer pass3 = new LolPlayer() { Id = 3, Name = "Jank", Age = 40, Role = "Mid Laner", LolTeam_id = 2 };
            LolPlayer pass4 = new LolPlayer() { Id = 4, Name = "Rekkl", Age = 32, Role = "Jungle", LolTeam_id = 2 };
            LolPlayer pass5 = new LolPlayer() { Id = 5, Name = "Beifg", Age = 42, Role = "Support", LolTeam_id = 3 };
            LolPlayer pass6 = new LolPlayer() { Id = 6, Name = "PPzyang", Age = 16, Role = "Top Laner", LolTeam_id = 3 };
            LolPlayer pass7 = new LolPlayer() { Id = 7, Name = "Fakr", Age = 25, Role = "Top Laner", LolTeam_id = 4 };
            LolPlayer pass8 = new LolPlayer() { Id = 8, Name = "LAst", Age = 31, Role = "Bot Laner", LolTeam_id = 4 };
            LolPlayer pass9 = new LolPlayer() { Id = 9, Name = "Vizcsej", Age = 25, Role = "Mid Laner", LolTeam_id = 5 };
            LolPlayer pass10 = new LolPlayer() { Id = 10, Name = "Tesl", Age = 46, Role = "Bot Laner", LolTeam_id = 5 };
            LolPlayer pass11 = new LolPlayer() { Id = 11, Name = "Flqi", Age = 32, Role = "Mid Laner", LolTeam_id = 6 };
            LolPlayer pass12 = new LolPlayer() { Id = 12, Name = "CPys", Age = 25, Role = "Jungle", LolTeam_id = 6 };

            pass1.LolTeam = LolTeam1;
            pass2.LolTeam = LolTeam1;
            pass3.LolTeam = LolTeam2;
            pass4.LolTeam = LolTeam2;
            pass5.LolTeam = LolTeam3;
            pass6.LolTeam = LolTeam3;
            pass7.LolTeam = LolTeam4;
            pass8.LolTeam = LolTeam4;
            pass9.LolTeam = LolTeam5;
            pass10.LolTeam = LolTeam5;
            pass11.LolTeam = LolTeam6;
            pass12.LolTeam = LolTeam6;

            pass1.LolTeam_id = LolTeam1.Id; LolTeam1.LolPlayers.Add(pass1);
            pass2.LolTeam_id = LolTeam1.Id; LolTeam1.LolPlayers.Add(pass2);
            pass3.LolTeam_id = LolTeam2.Id; LolTeam2.LolPlayers.Add(pass3);
            pass4.LolTeam_id = LolTeam2.Id; LolTeam2.LolPlayers.Add(pass4);
            pass5.LolTeam_id = LolTeam3.Id; LolTeam3.LolPlayers.Add(pass5);
            pass6.LolTeam_id = LolTeam3.Id; LolTeam3.LolPlayers.Add(pass6);
            pass7.LolTeam_id = LolTeam4.Id; LolTeam4.LolPlayers.Add(pass7);
            pass8.LolTeam_id = LolTeam4.Id; LolTeam4.LolPlayers.Add(pass8);
            pass9.LolTeam_id = LolTeam5.Id; LolTeam5.LolPlayers.Add(pass9);
            pass10.LolTeam_id = LolTeam5.Id; LolTeam5.LolPlayers.Add(pass10);
            pass11.LolTeam_id = LolTeam6.Id; LolTeam6.LolPlayers.Add(pass11);
            pass12.LolTeam_id = LolTeam6.Id; LolTeam6.LolPlayers.Add(pass12);

            // -------------------------------------------------------------------------------------------------------

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

            // -------------------------------------------------------------------------------------------------------

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

            // -------------------------------------------------------------------------------------------------------

            LolPlayer pass1 = new LolPlayer() { Id = 1, Name = "Huuu-Sy", Age = 19, Role = "Top Laner", LolTeam_id = 1 };
            LolPlayer pass2 = new LolPlayer() { Id = 2, Name = "Lee Fei", Age = 20, Role = "Bot Laner", LolTeam_id = 1 };
            LolPlayer pass3 = new LolPlayer() { Id = 3, Name = "Jank", Age = 40, Role = "Mid Laner", LolTeam_id = 2 };
            LolPlayer pass4 = new LolPlayer() { Id = 4, Name = "Rekkl", Age = 32, Role = "Jungle", LolTeam_id = 2 };
            LolPlayer pass5 = new LolPlayer() { Id = 5, Name = "Beifg", Age = 42, Role = "Support", LolTeam_id = 3 };
            LolPlayer pass6 = new LolPlayer() { Id = 6, Name = "PPzyang", Age = 16, Role = "Top Laner", LolTeam_id = 3 };
            LolPlayer pass7 = new LolPlayer() { Id = 7, Name = "Fakr", Age = 25, Role = "Top Laner", LolTeam_id = 4 };
            LolPlayer pass8 = new LolPlayer() { Id = 8, Name = "LAst", Age = 31, Role = "Bot Laner", LolTeam_id = 4 };
            LolPlayer pass9 = new LolPlayer() { Id = 9, Name = "Vizcsej", Age = 25, Role = "Mid Laner", LolTeam_id = 5 };
            LolPlayer pass10 = new LolPlayer() { Id = 10, Name = "Tesl", Age = 46, Role = "Bot Laner", LolTeam_id = 5 };
            LolPlayer pass11 = new LolPlayer() { Id = 11, Name = "Flqi", Age = 32, Role = "Mid Laner", LolTeam_id = 6 };
            LolPlayer pass12 = new LolPlayer() { Id = 12, Name = "CPys", Age = 25, Role = "Jungle", LolTeam_id = 6 };

            pass1.LolTeam = LolTeam1;
            pass2.LolTeam = LolTeam1;
            pass3.LolTeam = LolTeam2;
            pass4.LolTeam = LolTeam2;
            pass5.LolTeam = LolTeam3;
            pass6.LolTeam = LolTeam3;
            pass7.LolTeam = LolTeam4;
            pass8.LolTeam = LolTeam4;
            pass9.LolTeam = LolTeam5;
            pass10.LolTeam = LolTeam5;
            pass11.LolTeam = LolTeam6;
            pass12.LolTeam = LolTeam6;

            pass1.LolTeam_id = LolTeam1.Id; LolTeam1.LolPlayers.Add(pass1);
            pass2.LolTeam_id = LolTeam1.Id; LolTeam1.LolPlayers.Add(pass2);
            pass3.LolTeam_id = LolTeam2.Id; LolTeam2.LolPlayers.Add(pass3);
            pass4.LolTeam_id = LolTeam2.Id; LolTeam2.LolPlayers.Add(pass4);
            pass5.LolTeam_id = LolTeam3.Id; LolTeam3.LolPlayers.Add(pass5);
            pass6.LolTeam_id = LolTeam3.Id; LolTeam3.LolPlayers.Add(pass6);
            pass7.LolTeam_id = LolTeam4.Id; LolTeam4.LolPlayers.Add(pass7);
            pass8.LolTeam_id = LolTeam4.Id; LolTeam4.LolPlayers.Add(pass8);
            pass9.LolTeam_id = LolTeam5.Id; LolTeam5.LolPlayers.Add(pass9);
            pass10.LolTeam_id = LolTeam5.Id; LolTeam5.LolPlayers.Add(pass10);
            pass11.LolTeam_id = LolTeam6.Id; LolTeam6.LolPlayers.Add(pass11);
            pass12.LolTeam_id = LolTeam6.Id; LolTeam6.LolPlayers.Add(pass12);

            

            List<LolManager> LolManagers = new List<LolManager>();
            LolManagers.Add(LolManager1);
            LolManagers.Add(LolManager2);
            LolManagers.Add(LolManager3);
            return LolManagers.AsQueryable();

        }
    }
}
