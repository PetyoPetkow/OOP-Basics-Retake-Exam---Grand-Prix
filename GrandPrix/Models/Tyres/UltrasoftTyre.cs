namespace GrandPrix.Models.Tyres
{
    public class UltrasoftTyre : Tyre
    {
        public UltrasoftTyre(double hardness, double grip)
            : base(hardness)
        {
            this.Grip = grip;
        }

        public override double Grip { get; set; }
        public override string Name => "UltraSoft";
    }
}
