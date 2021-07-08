using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Mammals: SeaDweller
    {
        protected bool _canItLiveOnLand;

        public bool MCanItLiveOnLand
        {
            get { return _canItLiveOnLand; }
            set { _canItLiveOnLand = value; }
        }

        public Mammals():this("Mammal",0,0,false) { }
        public Mammals(string nm, int cnt, double wgth, bool cll)
            : base(nm, cnt, wgth)
        {
            MCanItLiveOnLand = cll;
        }

        public override void PrintState()
        {
            Console.Write(this.ToString());
            if (MCanItLiveOnLand) Console.WriteLine("It can live on land!\r\n");
            else Console.WriteLine("It can't live on land!\r\n");
        }

        public override string ToString()
        {
            return string.Format("{0}, its population is {1}, it weighs {2} kilograms. ", DwName, DwCount, DwWeight) ;
        }

        public override void BirthOfDweller()
        {
            base.BirthOfDweller();
            Console.WriteLine("New mammal!\r\n");
        }

        public override void WhoAmI()
        {
            Console.WriteLine("I am mammal!\r\n");
        }
        
    }
}
