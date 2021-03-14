namespace GrandPrix.Controllers
{
    using GrandPrix.factories;
    using GrandPrix.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RaceTower
    {
        public void SetTrackInfo(int lapsNumber, int trackLength)
        {
            //TODO: Add some logic here …
        }
        public void RegisterDriver(List<string> commandArgs)
        {
            DriverFactory.Create(commandArgs);
        }

        public void DriverBoxes(List<string> commandArgs)
        {
            //TODO: Add some logic here …
        }

        public string CompleteLaps(List<string> commandArgs)
        {
            //TODO: Add some logic here …
            return null;
        }

        public string GetLeaderboard()
        {
            //TODO: Add some logic here …
            return null;
        }

        public void ChangeWeather(List<string> commandArgs)
        {
            //TODO: Add some logic here …
        }

    }
}
