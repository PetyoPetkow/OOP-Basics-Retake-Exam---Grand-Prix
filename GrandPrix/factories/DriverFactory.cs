namespace GrandPrix.factories
{
    using System.Collections.Generic;

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
            Tyre tyre = null;
            List<string> tyreArgs = new List<string>();

            double grip;
            string type = commandArgs[0];
            string name = commandArgs[1];
            int hp = int.Parse(commandArgs[2]);
            double fuelAmount = double.Parse(commandArgs[3]);
            string tyreType = commandArgs[4];
            double tyreHardness = double.Parse(commandArgs[5]);

            

            
            tyreArgs.Add(tyreType);
            tyreArgs.Add(tyreHardness.ToString());

            if (commandArgs.Count > 6)
            {
                grip = double.Parse(commandArgs[6]);
                tyreArgs.Add(grip.ToString());
            }

            tyre = tyreFactory.Create(tyreArgs);
            tyreArgs.Clear();

            switch (type)
            {
                
                case "Aggressive":

                    
                    
                    car = new Car(hp, fuelAmount, tyre);
                    driver = new AggressiveDriver(name, car);

                    break;
                case "Endurance":

                    //tyre = tyreFactory.Create(tyreArgs);
                    //tyres.Add(tyre);
                    car = new Car(hp, fuelAmount, tyre);
                    driver = new EnduranceDriver(name, car);

                    break;
            }
            return driver;
        }
    }
}
