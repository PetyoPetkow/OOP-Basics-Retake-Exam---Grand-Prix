namespace GrandPrix.Models.Drivers
{
    public class EnduranceDriver : Driver
    {
        private const double ENDURANCE_DRIVER_FUEL_CONSUMPTION = 1.5;

        public EnduranceDriver(string name, Car car)
            : base(name, car, ENDURANCE_DRIVER_FUEL_CONSUMPTION)
        {
        }
    }
}
