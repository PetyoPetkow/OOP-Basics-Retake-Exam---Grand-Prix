namespace GrandPrix.factories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using GrandPrix.Models;
    using GrandPrix.Models.Drivers;
    using GrandPrix.Models.Tyres;

    public class DriverFactory
    {
        private TyreFactory tyreFactory;

        public DriverFactory()
        {
            this.tyreFactory = new TyreFactory();
        }

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
            tyreArgs.Clear();

            tyreArgs.Add(tyreType);
            tyreArgs.Add(tyreHardness.ToString());
            tyreArgs.Add(grip.ToString());

            switch (type)
            {
                
                case "Aggressive":

                    Tyre tyre = tyreFactory.Create(tyreArgs);

                    car = new Car(hp, fuelAmount, tyre);
                    driver = new AggressiveDriver(name, car);

                    break;
                case "Endurance":

                    tyre = tyreFactory.Create(tyreArgs);

                    car = new Car(hp, fuelAmount, tyre);
                    driver = new AggressiveDriver(name, car);

                    break;
            }
            return driver;
        }
    }
}
