namespace GrandPrix.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Driver
    {
        private double speed;
        protected Driver(string name, double totalTime, Car car)
        {
            this.Name = name;
            this.TotalTime = totalTime;
            this.Car = car;
            this.Speed = (Car.Hp + Car.Tyre.Degradation) / Car.FuelAmount;
        }

        public string Name { get; set; }
        public double TotalTime { get; set; }
        public Car Car { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public double Speed 
        {
            get
            {
                return speed;
            }
            set
            {
                speed = (Car.Hp + Car.Tyre.Degradation) / Car.FuelAmount;
            }
        }
    }
}
