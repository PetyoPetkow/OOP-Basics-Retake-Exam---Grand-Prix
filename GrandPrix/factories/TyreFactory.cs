namespace GrandPrix.factories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using GrandPrix.Models.Tyres;

    public class TyreFactory
    {
        public Tyre Create(List<string> commandArgs)
        {
            Tyre tyre = null;

            string name = commandArgs[0];
            double hardness = double.Parse(commandArgs[1]);
            double grip = double.Parse(commandArgs[2]);

            switch (name)
            {
                case "Hard": tyre = new HardTyre(hardness); break;
                case "Ultrasoft": tyre = new UltrasoftTyre(hardness, grip); break;
            }
            return tyre;
        }
    }
}
