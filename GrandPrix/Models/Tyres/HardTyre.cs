namespace GrandPrix.Models.Tyres
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HardTyre : Tyre
    {
        private string name = "Hard";

        public HardTyre(double hardness)
            :base(hardness)
        {
            
        }

        public new string Name
        {
            get
            {
                return this.name;
            }
        }
    }
}
