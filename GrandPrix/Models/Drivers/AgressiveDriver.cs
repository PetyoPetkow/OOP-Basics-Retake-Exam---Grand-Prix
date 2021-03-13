namespace GrandPrix.Models.Drivers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AgressiveDriver : Driver
    {
        public AgressiveDriver(string name, double totalTime, Car car)
            :base(name, totalTime, car)
        {
            this.FuelConsumptionPerKm = 2.7;
            this.Speed *= 1.3;
        }

        public new double FuelConsumptionPerKm { get; }
    }
}
