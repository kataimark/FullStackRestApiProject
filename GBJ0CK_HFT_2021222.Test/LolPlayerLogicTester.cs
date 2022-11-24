using GBJ0CK_HFT_2021222.Logic;
using GBJ0CK_HFT_2021222.Models;
using GBJ0CK_HFT_2021222.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GBJ0CK_HFT_2021222.Test
{
    public class FakeLolPlayerRepository : IRepository<LolPlayer>
    {
        public void Create(LolPlayer item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public LolPlayer Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<LolPlayer> ReadAll()
        {
            return new List<LolPlayer>()
            {
              new LolPlayer("1#Feus#18#Top Laner"),
               new LolPlayer("2#Iner#19#Jungler"),
               new LolPlayer("3#Haker#26#Mid Laner"),
               new LolPlayer("4#Dumayusi#20#Bot Laner"),
               new LolPlayer("5#Reria#20#Support"),
               new LolPlayer("6#Lroken Blade#22#Top Laner"),
               new LolPlayer("7#Sankos#27#Jungler"),
               new LolPlayer("8#laPs#22#Mid Laner"),
               new LolPlayer("9#Tlakked#21#Bot Laner"),
               new LolPlayer("10#Qargamas#22#Support"),
            }.AsQueryable();
        }

        public void Update(LolPlayer item)
        {
            throw new NotImplementedException();
        }
    }



    [TestFixture]
    public class LolPlayerLogicTester
    {

        LolPlayerLogic logic;
        [SetUp]
        public void Init()
        {

            logic = new LolPlayerLogic(new FakeLolPlayerRepository());


        }
        [Test]
        public void AVGAgeTop()
        {
            double? avg = logic.GetAverageAge("Top Laner");
            Assert.That(avg, Is.EqualTo(20));
        }

        [Test]
        public void AVGAgeJungel()
        {
            double? avg2 = logic.GetAverageAge("Jungler");
            Assert.That(avg2, Is.EqualTo(23));
        }

        [Test]
        public void AVGAgeMid()
        {
            double? avg3 = logic.GetAverageAge("Mid Laner");
            Assert.That(avg3, Is.EqualTo(24));
        }

        [Test]
        public void AVGAgeBot()
        {
            double? avg4 = logic.GetAverageAge("Bot Laner");
            Assert.That(avg4, Is.EqualTo(20.5));
        }

        [Test]
        public void AVGAgeSupport()
        {
            double? avg5 = logic.GetAverageAge("Support");
            Assert.That(avg5, Is.EqualTo(21));
        }

        [Test]
        public void AVGNameLengthSupport()
        {
            double? avg5 = logic.GetWinsByChampion("Support");
            Assert.That(avg5, Is.EqualTo(6.5));
        }
        [Test]
        public void AVGNameLengthBot()
        {
            double? avg5 = logic.GetWinsByChampion("Bot Laner");
            Assert.That(avg5, Is.EqualTo(7.5));
        }
        [Test]
        public void AVGNameLengthMid()
        {
            double? avg5 = logic.GetWinsByChampion("Mid Laner");
            Assert.That(avg5, Is.EqualTo(4.5));
        }
        [Test]
        public void AVGNameLengthJungler()
        {
            double? avg5 = logic.GetWinsByChampion("Jungler");
            Assert.That(avg5, Is.EqualTo(5));
        }
        [Test]
        public void AVGNameLengthTop()
        {
            double? avg5 = logic.GetWinsByChampion("Top Laner");
            Assert.That(avg5, Is.EqualTo(8));
        }
    }
}
