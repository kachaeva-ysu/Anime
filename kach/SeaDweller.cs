using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class SeaDweller
    {
        //Поля: название вида, численность в Черном море и вес особи
        private string _name;
        private int _count;
        private int _weight;

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

        public int DwWeight
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
        public void PrintState()
           => Console.WriteLine(this.ToString());

        public override string ToString()
        {
            return string.Format("Number of {0} is {1}, it weighs {2} kilograms\r\n", _name, _count, _weight); 
        }
        public void BirthOfDweller()
        {
            _count++;
        }

        //Конструкторы
        public SeaDweller() : this("Fish,0,0") { }
        public SeaDweller(string nm) : this(nm, 0, 0) { }
        public SeaDweller(string nm,int cnt, int wght)
        {
            DwName = nm;
            DwCount = cnt;
            DwWeight = wght;
        }

        //Операции
        public static bool operator>(SeaDweller a, SeaDweller b)
        {
            if (a.DwWeight > b.DwWeight)
                return true;
            return false;
        }
        public static bool operator <(SeaDweller a, SeaDweller b)
        {
            if (a.DwWeight < b.DwWeight)
                return false;
            return true;
        }

        public static bool operator == (SeaDweller a, SeaDweller b)
        {
            if (a.DwName != b.DwName) return false;
            if (a.DwCount != b.DwCount) return false;
            if (a.DwWeight != b.DwWeight) return false;
            return true;
        }
        public static bool operator !=(SeaDweller a, SeaDweller b)
        {
            if (a.DwName != b.DwName) return true;
            if (a.DwCount != b.DwCount) return true;
            if (a.DwWeight != b.DwWeight) return true;
            return false;
        }



    }
}
