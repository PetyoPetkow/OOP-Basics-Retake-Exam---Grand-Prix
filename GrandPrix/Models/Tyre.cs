namespace GrandPrix.Models.Tyres
{
    public abstract class Tyre
    {
        protected Tyre(double hardness)
        {
            this.Hardness = hardness;
        }

        public abstract string Name { get; }
        public double Hardness { get; set; }
        public double Degradation { get; set; } = 100;
        public virtual double Grip { get; set; }

    }
}
