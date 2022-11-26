using ConsoleTools;
using GBJ0CK_HFT_2021222.Logic;
using GBJ0CK_HFT_2021222.Models;
using GBJ0CK_HFT_2021222.Repository;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GBJ0CK_HFT_2021222.Client
{
    class Program
    {
        public static RestService rserv = new RestService("http://localhost:48540");
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);


            var menu = new ConsoleMenu()
               .Add("CRUD methods", () => CrudMenu())
               .Add("non-CRUD methods", () => NonCrudMenu())
               .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }

        private static void CrudMenu()
        {

            var menu = new ConsoleMenu()
                .Add("Create element", CreatePreMenu)
                .Add("Get one element", ReadPreMenu)
                .Add("Get all element", ReadAllPreMenu)
                .Add("Update element", UpdatePreMenu)
                .Add("Delete element", DeletePreMenu)
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }
        private static void NonCrudMenu()
        {
            var menu = new ConsoleMenu()
               .Add("Get LolPlayers at the Tokyo LolManager", GetLolplayersAtAgeFourty)
               .Add("Get LolPlayers where their's LolTeam price is over 200.000.000$", GetLolPlayerWhereWinIsOverTen)
               .Add("Get LolPlayers where their's LolTeam model name is Boeing 787-8", GetLolplayersWhereTeamNameIsRoll)
               .Add("Get LolManagers where is a LolPlayer with Canadian nationality", GetLolManagertName)
               .Add("Get LolManagers where is a LolPlayer with the last name Cohen", GetLolManagertAtTwenty)
               .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }

        private static void PreMenu(Action lolplayer, Action lolTeam, Action lolmanager)
        {
            var menu = new ConsoleMenu()
                .Add("LolPlayer", lolplayer)
                .Add("LolTeam", lolTeam)
                .Add("LolManager", lolmanager)
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }
        //-------------------------------------------------------------------------------------------------------------CRUD------------------------------------------------

        //---------------------Create-------------------------
        private static void CreatePreMenu()
        {
            PreMenu(CreateLolplayer, CreateLolTeam, CreateLolManager);
        }

        private static void CreateLolManager()
        {
            Console.WriteLine("ManagerName: ");
            string managername = Console.ReadLine();
            Console.WriteLine("Age:");
            int age = int.Parse(Console.ReadLine());
            rserv.Post<LolManager>(new LolManager() { ManagerName = managername, Age = age }, "LolManager");
        }

        private static void CreateLolTeam()
        {
            Console.WriteLine("TeamName: ");
            string teamname = Console.ReadLine();
            Console.WriteLine("Wins:");
            int win = int.Parse(Console.ReadLine());
            Console.WriteLine("LolManager id: ");
            int lolmanid = int.Parse(Console.ReadLine());
            rserv.Post<LolTeam>(new LolTeam() { TeamName = teamname, Wins = win, LolManager_id = lolmanid }, "LolTeam");
        }

        private static void CreateLolplayer()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Role name:");
            string rolen = Console.ReadLine();
            Console.WriteLine("LolTeam id: ");
            int LolTeamid = int.Parse(Console.ReadLine());
            rserv.Post<LolPlayer>(new LolPlayer() { Name = name, Role = rolen, LolTeam_id = LolTeamid }, "LolPlayer");
        }

        //---------------------END-Create-------------------





        //---------------------Read------------------------
        private static void ReadPreMenu()
        {
            PreMenu(ReadLolplayer, ReadLolTeam, ReadLolManager);
        }

        private static void ReadLolManager()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getLolManager = rserv.Get<LolManager>(id, "LolManager");
            Console.WriteLine($"Id: {getLolManager.Id}, ManagerName: {getLolManager.ManagerName}, Age: {getLolManager.Age}");
            Console.ReadLine();

        }

        private static void ReadLolTeam()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getLolTeam = rserv.Get<LolTeam>(id, "LolTeam");
            Console.WriteLine($"Id: {getLolTeam.Id}, TeamName: {getLolTeam.TeamName}, Wins: {getLolTeam.Wins}, LolManagerId: {getLolTeam.LolManager_id}");
            Console.ReadLine();
        }

        private static void ReadLolplayer()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getLolPlayer = rserv.Get<LolPlayer>(id, "LolPlayer");
            Console.WriteLine($"Id: {getLolPlayer.Id}, Name: {getLolPlayer.Name}, Role: {getLolPlayer.Role}, LolTeamId: {getLolPlayer.LolTeam_id}");
            Console.ReadLine();
        }

        //---------------------END-Read-------------------





        //----------------------ReadAll----------------------
        private static void ReadAllPreMenu()
        {
            PreMenu(PrintAllLolPlayers, PrintAllLolTeams, PrintAllLolManagers);
        }

        private static void PrintAllLolPlayers()
        {
            var LolPlayers = rserv.Get<LolPlayer>("LolPlayer");
            Console.WriteLine("-------------LolPlayers-------------");
            LolplayerToConsole(LolPlayers);
            Console.ReadLine();
        }
        private static void PrintAllLolTeams()
        {
            var LolTeams = rserv.Get<LolTeam>("LolTeam");
            Console.WriteLine("-------------LolTeams-------------");
            LolTeamToConsole(LolTeams);
            Console.ReadLine();
        }
        private static void PrintAllLolManagers()
        {
            var LolManagers = rserv.Get<LolManager>("LolManager");
            Console.WriteLine("-------------LolManagers-------------");
            LolManagerToConsole(LolManagers);
            Console.ReadLine();
        }
        //---------------END-ReadAll-------------------





        //-----------------Update-------------------
        private static void UpdatePreMenu()
        {
            PreMenu(UpdateLolPlayer, UpdateLolTeam, UpdateLolManager);
        }

        private static void UpdateLolManager()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("ManagerName: ");
            string Managername = Console.ReadLine();
            Console.WriteLine("Age:");
            int age = int.Parse(Console.ReadLine());
            LolManager input = new LolManager() { Id = id, ManagerName = Managername, Age = age };
            rserv.Put(input, "LolManager");
        }

        private static void UpdateLolTeam()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("TeamName: ");
            string teamname = Console.ReadLine();
            Console.WriteLine("Wins:");
            int win = int.Parse(Console.ReadLine());
            Console.WriteLine("LolManager id: ");
            int airpid = int.Parse(Console.ReadLine());
            LolTeam input = new LolTeam() { Id = id, TeamName = teamname, Wins = win, LolManager_id = airpid };
            rserv.Put(input, "LolTeam");
        }

        private static void UpdateLolPlayer()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("LolTeam id: ");
            int LolTeamid = int.Parse(Console.ReadLine());
            LolPlayer input = new LolPlayer() { Id = id, Name = name, Age = age, LolTeam_id = LolTeamid };
            rserv.Put(input, "LolPlayer");
        }

        //-----------------END-Update-------------





        //-----------------Delete--------------
        private static void DeletePreMenu()
        {
            PreMenu(DeleteLolPlayer, DeleteLolTeam, DeleteLolManager);
        }

        private static void DeleteLolManager()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rserv.Delete(id, "LolManager");
        }

        private static void DeleteLolTeam()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rserv.Delete(id, "LolTeam");
        }

        private static void DeleteLolPlayer()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rserv.Delete(id, "LolPlayer");
        }

        //-------------------END-Delete----------













        ////-------------------------------------------------------------------------------------------------------------non-CRUD------------------------------------------------

        private static void GetLolplayersAtAgeFourty()
        {
            var output = rserv.Get<LolPlayer>("stat/GetLolplayersAtAgeFourty");
            LolplayerToConsole(output);
            Console.ReadLine();
        }
        private static void GetLolPlayerWhereWinIsOverTen()
        {
            var output = rserv.Get<LolPlayer>("stat/GetLolPlayerWhereWinIsOverTen");
            LolplayerToConsole(output);
            Console.ReadLine();
        }

        private static void GetLolplayersWhereTeamNameIsRoll()
        {
            var output = rserv.Get<LolPlayer>("stat/GetLolplayersWhereTeamNameIsRoll");
            LolplayerToConsole(output);
            Console.ReadLine();
        }
        private static void GetLolManagertName()
        {
            var output = rserv.Get<LolManager>("stat/GetLolManagertName");
            LolManagerToConsole(output);
            Console.ReadLine();
        }
        private static void GetLolManagertAtTwenty()
        {
            var output = rserv.Get<LolManager>("stat/GetLolManagertAtTwenty");
            LolManagerToConsole(output);
            Console.ReadLine();
        }















        ////-------------------------------------------------------------------------------------------------------------ToConsole------------------------------------------------
        private static void LolplayerToConsole(IEnumerable<LolPlayer> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, Age: {item.Age}, Name: {item.Name}, LolTeamId: {item.LolTeam_id}");
            }
        }
        private static void LolTeamToConsole(IEnumerable<LolTeam> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, TeamName: {item.TeamName}, Wins: {item.Wins}, LolManagerId: {item.LolManager_id}");
            }
        }
        private static void LolManagerToConsole(IEnumerable<LolManager> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, ManagerName: {item.ManagerName}, Age: {item.Age}");
            }
        }

    }
}
