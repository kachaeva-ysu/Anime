using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Fish: SeaDweller
    {
        private string _clas; //(Placodermi(панцирные), Acanthodii(акантоды), Chondrichthyes(хрящевые), Osteichthyes(костные))
        private int _catching; // Вылов

        public string FClas
        {
            get { return _clas; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Некорректное имя!");
                    _clas = "Fish";
                }
                else if (value.Length > 20)
                {
                    Console.WriteLine("Ошибка: слишком длинное название!");
                    _clas = "Placodermi";
                }
                else
                    _clas = value;
            }
        }

        public int FCatch
        {
            get { return _catching; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Ошибка: отрицательный вылов!");
                    _catching = 0;
                }
                else
                    _catching = value;
            }
        }


        public Fish(): this("Fish", 0,0, "Placodermi",0) { }
        public Fish(string nm, int cnt, double wgth, string cls, int ctch)
            :base(nm,cnt,wgth)
        {
            FClas = cls;
            FCatch = ctch;
        }

        public override void PrintState()
           => Console.WriteLine(this.ToString());

        public override string ToString()
        {
            return string.Format("{0} is {1}, its population is {2}, it weighs {3} kilograms, its catching is {4}\r\n", DwName, FClas, DwCount, DwWeight, FCatch);
        }

        public override void BirthOfDweller()
        {
            DwCount+=100;
            Console.WriteLine("New {0} fishes!\r\n", FClas);
        }

        public override void WhoAmI()
        {
            Console.WriteLine("I am fish!\r\n");
        }

    }
}
