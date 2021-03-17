using System;

namespace GrandPrix.Models.Tyres
{
    public class HardTyre : Tyre
    {
        private const string BLOWN_TYRE_ERROR = "Blown Tyre";

        private double degradation;

        public HardTyre(double hardness)
            :base(hardness)
        {
        }

        public override double Degradation
        {
            get
            {
                return this.degradation;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(BLOWN_TYRE_ERROR);
                }
                else
                {
                    this.degradation = value;
                }
            }
        }
        public override string Name => "Hard";
    }
}
