using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Dolphins:Mammals
    {
        private string _color;

        public string DColor
        {
            get { return _color; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Некорректное имя!");
                    _color = "black";

                }
                else if (value.Length > 20)
                {
                    Console.WriteLine("Ошибка: слишком длинное имя!");
                    _color = "black";
                }
                else
                    _color = value;
            }
        }

        public Dolphins():this("Dolphin",0,0,false,"black") { }
        public Dolphins(string nm, int cnt, double wgth, bool cll,string clr)
            : base(nm, cnt, wgth,cll)
        {
            DColor = clr;
        }

        public override void PrintState()
        {
            Console.Write(this.ToString());
            if (MCanItLiveOnLand) Console.WriteLine("It can live on land!\r\n");
            else Console.WriteLine("It can't live on land!\r\n");
        }

        public override string ToString()
        {
            return string.Format("{0}, its population is {1}, it weighs {2} kilograms, its {3}. ", DwName, DwCount, DwWeight, DColor);
        }

        public override void BirthOfDweller()
        {
            DwCount++;
            Console.WriteLine("New dolphin!\r\n");
        }

        public override void WhoAmI()
        {
            Console.WriteLine("I am dolphin!\r\n");
        }


    }
}
