using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
     abstract class SeaDweller
    {
        //Поля: название вида, численность в Черном море и вес особи
        protected string _name;
        protected int _count;
        protected double _weight;

        //Свойства
        public string DwName
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Некорректное имя!");
                    _name = "Fish";
                }
                else if (value.Length > 20)
                {
                    Console.WriteLine("Ошибка: слишком длинное название!");
                    _name = "Fish";
                }
                else
                    _name = value;
            }
        }

        public int DwCount
        {
            get { return _count;}
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Ошибка: отрицательная численность!");
                    _count = 0;
                }
                else
                    _count = value;
            }
        }

        public double DwWeight
        {
            get { return _weight;}
            set
            {
                if (value>1400)
                {
                    Console.WriteLine("Самый тяжелый обитатель Черного моря- Белуха, ее вес составляет 1400 килограмм");
                    _weight = 1400;
                }
                else if(value<0)
                {
                    Console.WriteLine("Ошибка: отрицательный вес!");
                    _weight = 0;
                }
                else
                    _weight = value;
            }
        }

        //Методы
        public virtual void PrintState()
           => Console.WriteLine(this.ToString());

        public override string ToString()
        {
            return string.Format("Number of {0} is {1}, it weighs {2} kilograms\r\n", DwName, DwCount, DwWeight);
        }

        public virtual void BirthOfDweller()
        {
            DwCount++;
        }
        public abstract void WhoAmI();

        //Конструкторы
        public SeaDweller() : this("Fish,0,0") { }
        public SeaDweller(string nm) : this(nm, 0, 0) { }
        public SeaDweller(string nm, int cnt, double wght)
        {
            DwName = nm;
            DwCount = cnt;
            DwWeight = wght;
        }

       



    }
}
