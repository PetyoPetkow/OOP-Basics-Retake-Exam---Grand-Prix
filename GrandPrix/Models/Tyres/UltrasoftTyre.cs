namespace GrandPrix.Models.Tyres
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UltrasoftTyre : Tyre
    {
        private string name="UltraSoft";

        public UltrasoftTyre(double hardness, double grip)
            : base(hardness)
        {
            this.Grip = grip;
        }

        public new string Name 
        {
            get
            {
                return this.name;
            } 
        }
        public double Grip { get; set; }
    }
}
