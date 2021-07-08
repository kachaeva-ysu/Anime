using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Mollusks: SeaDweller
    {
        private string _klas; //(Gastropod-брюхоногие, Bivalve-двустворчатые, Cephalopod-головоногие)
        private bool _pearl;

        public string MKlas
        {
            get { return _klas; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Некорректное имя!");
                    _klas = "Gastropod";
                }
                else if (value.Length > 20)
                {
                    Console.WriteLine("Ошибка: слишком длинное название!");
                    _klas = "Gastropod";
                }
                else
                    _klas = value;
            }
        }

        public bool MPearl
        {
            get { return _pearl;}
            set { _pearl = value;}
        }

        public Mollusks():this("Mollusk",0,0, "Gastropod", false) { }
        public Mollusks(string nm, int cnt, double wght, string kl, bool prl)
            : base(nm, cnt, wght)
        {
            MKlas = kl;
            MPearl = prl;
        }


        public override void PrintState()
        { 
            Console.Write(this.ToString());
            if (MPearl) Console.WriteLine("It has pearl!\r\n");
            else Console.WriteLine("It doesn't have pearl!\r\n");
        }

        public override string ToString()
        {
            return string.Format("{0} is {1}, its population is {2}, it weighs {3} kilograms. ", DwName, MKlas, DwCount, DwWeight);
        }
        

        public override void BirthOfDweller()
        {
            base.BirthOfDweller();
            Console.WriteLine("New {0} mollusk!\r\n", MKlas);
        }

        public override void WhoAmI()
        {
            Console.WriteLine("I am mollusk!\r\n");
        }
    }
}
