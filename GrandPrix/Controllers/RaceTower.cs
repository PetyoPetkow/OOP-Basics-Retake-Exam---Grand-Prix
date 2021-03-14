namespace GrandPrix.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using GrandPrix.factories;
    using GrandPrix.Models;

    public class RaceTower
    {
        private List<Driver> driver;
        private DriverFactory driverFactory;
        private StringBuilder stringBuilder;
        private int lapsNumber;
        private int trackLength;


        public RaceTower()
        {
            this.driver = new List<Driver>();
            this.driverFactory = new DriverFactory();
            this.stringBuilder = new StringBuilder();
            this.lapsNumber = 0;
            this.trackLength = 0;

        }

        public void SetTrackInfo(int lapsNumber, int trackLength)
        {
            this.lapsNumber = lapsNumber;
            this.trackLength = trackLength;
        }
        public void RegisterDriver(List<string> commandArgs)
        {
            Driver driver = driverFactory.Create(commandArgs);
            this.driver.Add(driver);
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
            return null;
;
        }

        public void ChangeWeather(List<string> commandArgs)
        {
            //TODO: Add some logic here …
        }

    }
}
