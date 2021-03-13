namespace GrandPrix.Models.Tyres
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Tyre
    {

        protected Tyre(double hardness)
        {
            this.Hardness = hardness;
            this.Degradation = 100;
        }

        public string Name { get; set; }
        public double Hardness { get; set; }
        public double Degradation { get; set; }
    }
}
