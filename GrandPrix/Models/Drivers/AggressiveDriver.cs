namespace GrandPrix.Models.Drivers
{
    public class AggressiveDriver : Driver
    {
        private const double AGRESIVE_DRIVER_FUEL_CONSUMPTION = 2.7;
        private const double AGRESSIVE_DRIVER_SPEED = 1.3;

        public AggressiveDriver(string name, Car car)
            :base(name, car, AGRESIVE_DRIVER_FUEL_CONSUMPTION)
        {
        }

        public override double Speed => base.Speed * AGRESSIVE_DRIVER_SPEED;
    }
}
