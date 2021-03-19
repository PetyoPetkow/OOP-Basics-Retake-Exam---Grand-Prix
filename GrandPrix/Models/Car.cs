namespace GrandPrix.Models
{
    using System;

    using GrandPrix.Models.Tyres;

    public class Car
    {
        private const double MAX_FUEL_AMOUNT = 160;

        private const string NO_FUEL_ERROR = "Out of fuel";

        private double fuelAmount;

        public Car(int hp, double fuelAmount, Tyre tyre)
        {
            this.Hp =hp;
            this.FuelAmount = fuelAmount;
            this.Tyre = tyre;
        }

        public int Hp { get; set; }

        public double FuelAmount 
        {
            get
            {
                return this.fuelAmount;
            }
            set
            {
                if (value>MAX_FUEL_AMOUNT)
                {
                    this.fuelAmount = MAX_FUEL_AMOUNT;
                }
                else if (value<0)
                {
                    throw new ArgumentException(NO_FUEL_ERROR);
                }
                else
                {
                    this.fuelAmount = value;
                }
            }
        }
        public Tyre Tyre { get; set; }

        public void Refill(double fuelRefillAmount)
        {
            this.FuelAmount += fuelRefillAmount;
        }
    }
}
