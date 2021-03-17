namespace GrandPrix.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Engine
    {
        public static void Run()
        {
            var raceTower = new RaceTower();

            raceTower.SetTrackInfo(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
           
            while (raceTower.isNotFinished)
            {
                string result = string.Empty;
                string input = Console.ReadLine();
                List<string> commandArgs = input.Split().ToList();

                string command = commandArgs[0];
                commandArgs = commandArgs.Skip(1).ToList();

                switch (command)
                {
                    case "RegisterDriver": raceTower.RegisterDriver(commandArgs); break;
                    case "Leaderboard": result = raceTower.GetLeaderboard(); break;
                    case "CompleteLaps": result = raceTower.CompleteLaps(commandArgs); break;
                    case "Box": raceTower.DriverBoxes(commandArgs); break;
                    case "ChangeWeather": raceTower.ChangeWeather(commandArgs); break;
                    case "DNF": break;
                    case "Overtaking": break;
                }
                if (result!=string.Empty)
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}
