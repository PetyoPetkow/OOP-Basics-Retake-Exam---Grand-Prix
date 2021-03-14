namespace GrandPrix.factories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using GrandPrix.Models;
    using GrandPrix.Models.Drivers;
    public class DriverFactory
    {
        public Driver Create(List<string> commandArgs)
        {
            Driver driver = null;
            Car car = null;
            

            string type = commandArgs[0];
            string name = commandArgs[1];
            int hp = int.Parse(commandArgs[2]);
            double fuelAmount = double.Parse(commandArgs[3]);
            string tyreType = commandArgs[4];
            double tyreHardness = double.Parse(commandArgs[5]);
            double grip = double.Parse(commandArgs[6]);

            List<string> tyreArgs = new List<string>();
            tyreArgs.AddRange(tyreType, tyreHardness, grip);

            switch (type)
            {
                case "Aggressive":
                    if (tyreType=="Hard")
                    {
                        TyreFactory();
                        car = new Car(hp, fuelAmount, )
                    driver = new AggressiveDriver(name, totalTime, car);
                    }
                    
                    break;
            }
        }
    }
}
