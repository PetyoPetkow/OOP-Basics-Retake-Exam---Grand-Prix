namespace GrandPrix.Models.Drivers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EnduranceDriver : Driver
    {
        private double fuelConsumptionPerKm;

        public EnduranceDriver(string name, double totalTime, Car car)
            : base(name, totalTime, car)
        {
            this.FuelConsumptionPerKm = 1.5;
        }

        public new double FuelConsumptionPerKm { get; }
    }
}
