namespace GrandPrix.factories
{
    using System.Collections.Generic;

    using GrandPrix.Models.Tyres;

    public class TyreFactory
    {
        public Tyre Create(List<string> commandArgs)
        {
            Tyre tyre = null;

            string name = commandArgs[0];
            double hardness = double.Parse(commandArgs[1]);
            double grip = 0;

            switch (name)
            {
                case "Hard": 
                    tyre = new HardTyre(hardness); 
                    break;
                case "Ultrasoft": 
                    grip = double.Parse(commandArgs[2]); 
                    tyre = new UltrasoftTyre(hardness, grip); 
                    break;
                    
            }
            
            return tyre;
        }
    }
}
