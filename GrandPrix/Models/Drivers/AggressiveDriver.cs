namespace GrandPrix.Models.Drivers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AggressiveDriver : Driver
    {
        public AggressiveDriver(string name, Car car)
            :base(name, car)
        {
            this.FuelConsumptionPerKm = 2.7;
            this.Speed *= 1.3;
        }

        public new double FuelConsumptionPerKm { get; }
    }
}
