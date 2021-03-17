namespace GrandPrix.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using GrandPrix.factories;
    using GrandPrix.Models;

    public class RaceTower
    {
        private StringBuilder stringBuilder;

        private List<Driver> drivers;
        private DriverFactory driverFactory;
        private Dictionary<Driver, string> dnfDriver;
        private Dictionary<Driver, string> notInTheRace;

        public bool isNotFinished = true;
        private int lapsNumber;
        private int trackLength;
        private int currentLap;
        private string weather;


        public RaceTower()
        {
            this.stringBuilder = new StringBuilder();

            this.drivers = new List<Driver>();
            this.driverFactory = new DriverFactory();
            this.dnfDriver = new Dictionary<Driver, string>();
            this.notInTheRace = new Dictionary<Driver, string>();

            this.isNotFinished = true;
            this.lapsNumber = 0;
            this.trackLength = 0;
            this.currentLap = 0;
            this.weather = "Sunny";
        }

        public void SetTrackInfo(int lapsNumber, int trackLength)
        {
            this.lapsNumber = lapsNumber;
            this.trackLength = trackLength;
        }
        public void RegisterDriver(List<string> commandArgs)
        {
            if (currentLap > 0)
            {
                Console.WriteLine("The race has already begun!");
            }
            else
            {
                Driver driver = driverFactory.Create(commandArgs);
                drivers.Add(driver);
            }
        }

        public void DriverBoxes(List<string> commandArgs)
        {
            string action = commandArgs[0];
            string driverName = commandArgs[1];

            switch (action)
            {
                case "Refuel":
                    double fuelAmountToBeAdded = double.Parse(commandArgs[2]);
                    foreach (Driver driver in drivers)
                    {
                        if (driver.Name == driverName)
                        {
                            driver.Car.Refill(fuelAmountToBeAdded);
                            driver.TotalTime += 20.00;
                        }
                    }
                    break;

                case "ChangeTyres":
                    string tyreType = commandArgs[2];
                    double tyreHardness = double.Parse(commandArgs[3]);

                    foreach (Driver driver in drivers)
                    {
                        if (driverName == driver.Name)
                        {
                            driver.TotalTime += 20.00;
                            driver.Car.Tyre.Degradation = 100;
                            driver.Car.Tyre.Hardness = tyreHardness;

                            if (tyreType == "Ultrasoft")
                            {
                                double grip = double.Parse(commandArgs[5]);
                                driver.Car.Tyre.Grip = grip;
                            }
                        }
                    }
                    break;
            }
        }

        public string CompleteLaps(List<string> commandArgs)
        {
            string result;
            int numberOfLaps = int.Parse(commandArgs[0]);

            if (numberOfLaps > lapsNumber)
            {
                result = $"There is no time! On lap {currentLap}.";
            }
            else
            {
                for (int i = 0; i < numberOfLaps; i++)
                {
                    foreach (var driver in drivers)
                    {

                        try
                        {
                            driver.TotalTime += 60 / (trackLength / driver.Speed);
                            driver.Car.FuelAmount -= trackLength * driver.FuelConsumptionPerKm;
                            driver.Car.Tyre.Degradation -= driver.Car.Tyre.Hardness + driver.Car.Tyre.Grip;
                        }
                        catch (ArgumentException ae)
                        {
                            try
                            {
                                dnfDriver.Add(driver, ae.Message);
                                //Console.WriteLine($"{driver.Name} {ae.Message}");
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                }
                currentLap += numberOfLaps;

                result = $"{currentLap}/{lapsNumber}"; // TO BE CHANGED (FOR OVERTAKING)

                if (currentLap == lapsNumber)
                {
                    for (int i = 0; i < drivers.Count; i++)
                    {
                        if (dnfDriver.Keys.FirstOrDefault().Name == drivers[i].Name)
                        {
                            drivers.Remove(drivers[i]);
                        }
                    }

                    var winner = drivers.OrderBy(x => x.TotalTime).First();
                    result = $"{winner.Name} wins the race for {winner.TotalTime:F3}";
                    isNotFinished = false;
                }
            }

            return result;
        }

        public string GetLeaderboard()
        {
            stringBuilder.Clear();

            List<Driver> orderedDrivers = drivers.OrderBy(x => x.TotalTime).ToList();
            int position = 0;
            string result = null;

            foreach (Driver driver in orderedDrivers)
            {
                string failureReason = string.Empty;

                foreach (Driver item in dnfDriver.Keys)
                {
                    if (item.Name == driver.Name)
                    {
                        failureReason = dnfDriver.Values.FirstOrDefault();
                    }
                }

                if (failureReason == string.Empty)
                {
                    position++;
                    stringBuilder.AppendLine($"{position} - {driver.Name} {driver.TotalTime:F3}.");
                }
                else
                {
                    notInTheRace.Add(driver, failureReason);

                }
            }
            foreach (Driver driver in notInTheRace.Keys)
            {
                position++;
                stringBuilder.AppendLine($"{position} - {driver.Name} {notInTheRace.Values.FirstOrDefault()}.");
            }
            result = stringBuilder.ToString();
            return result;
        }

        public void ChangeWeather(List<string> commandArgs)
        {
            this.weather = commandArgs[0];
        }

        public static bool CarHasFuel(double fuel)
        {
            bool result = false;
            if (fuel > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
