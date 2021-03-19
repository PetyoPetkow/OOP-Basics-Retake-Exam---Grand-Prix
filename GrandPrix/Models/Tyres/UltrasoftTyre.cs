using System;

namespace GrandPrix.Models.Tyres
{
    public class UltrasoftTyre : Tyre
    {
        private const string BLOWN_TYRE_ERROR = "Has blown a tyre";

        private const double ULTRASOFT_TYRE_MIN_DEGRADATION_VALUE = 30;

        private double degradation;

        public UltrasoftTyre(double hardness, double grip)
            : base(hardness)
        {
            this.Grip = grip;
        }

        public override double Degradation
        {
            get
            {
                return this.degradation;
            }
            set
            {
                if (value < ULTRASOFT_TYRE_MIN_DEGRADATION_VALUE)
                {
                    throw new ArgumentException(BLOWN_TYRE_ERROR);
                }
                else
                {
                    this.degradation = value;
                }
            }
        }
        public override double Grip { get; set; }

        public override string Name => "UltraSoft";
    }
}
