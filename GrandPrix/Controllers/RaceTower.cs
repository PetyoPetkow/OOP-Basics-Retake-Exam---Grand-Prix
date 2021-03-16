namespace GrandPrix.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using GrandPrix.factories;
    using GrandPrix.Models;
    using GrandPrix.Models.Tyres;

    public class RaceTower
    {
        private List<Driver> drivers;
        private DriverFactory driverFactory;

        private int lapsNumber;
        private int trackLength;
        private int currentLap;
        private string failureReason;
        private string weather;
        private double grip;

        public RaceTower()
        {
            this.drivers = new List<Driver>();
            this.driverFactory = new DriverFactory();

            this.lapsNumber = 0;
            this.trackLength = 0;
            this.currentLap = 0;
            this.failureReason = null;
            this.weather = "Sunny";
            
        }

        public void SetTrackInfo(int lapsNumber, int trackLength)
        {
            this.lapsNumber = lapsNumber;
            this.trackLength = trackLength;
        }
        public void RegisterDriver(List<string> commandArgs)
        {
            Driver driver = driverFactory.Create(commandArgs);
            drivers.Add(driver);
            
            Console.WriteLine($"{driver.Name} {driver.Speed} {driver.FuelConsumptionPerKm} {driver.Car.Tyre.Grip}");
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

                            if (tyreType=="Ultrasoft")
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

            if (numberOfLaps>lapsNumber)
            {
                result = $"There is no time! On lap {currentLap}.";
            }
            else
            {
                for (int i = 0; i < numberOfLaps; i++)
                {
                    foreach (var driver in drivers)
                    {
                        if (driver.Car.FuelAmount >= trackLength * driver.FuelConsumptionPerKm) 
                        {
                            driver.TotalTime += 60 / (trackLength / driver.Speed);
                            driver.Car.FuelAmount -= trackLength * driver.FuelConsumptionPerKm;
                            driver.Car.Tyre.Degradation -= driver.Car.Tyre.Hardness + driver.Car.Tyre.Grip;
                        }
                    }     
                }
                currentLap += numberOfLaps;
                
                result = $"{currentLap}/{lapsNumber}"; // TO BE CHANGED

                if (currentLap==lapsNumber)
                {
                    result = "The race finished!";
                }
            }

            //if (currentLap==lapsNumber)
            //{
            //    result = $"{winner} wins the race for {winner.Name} seconds.";
            //}
            return result;
        }

        public string GetLeaderboard()
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<Driver> orderedDrivers = drivers.OrderBy(x => x.TotalTime).ToList();
            int position = 0;
            string result = null;
            foreach (Driver driver in orderedDrivers)
            {
                position++;
                stringBuilder.AppendLine($"{position} - {driver.Name} {driver.TotalTime} / {failureReason}."); //TO BE CHANGED!
            }
            result = stringBuilder.ToString();
            return result;
;
        }

        public void ChangeWeather(List<string> commandArgs)
        {
            this.weather = commandArgs[0];
        }

        public static bool CarHasFuel(double fuel)
        {
            bool result = false;
            if (fuel>0)
            {
                result = true;
            }
            return result;
        }

    }
}
