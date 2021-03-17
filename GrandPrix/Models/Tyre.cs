namespace GrandPrix.Models.Tyres
{
    public abstract class Tyre
    {
        protected Tyre(double hardness)
        {
            this.Hardness = hardness;
            this.Degradation = 100;
        }

        public abstract string Name { get; }
        public double Hardness { get; set; }
        public virtual double Degradation { get; set; }
        public virtual double Grip { get; set; }
    }
}
