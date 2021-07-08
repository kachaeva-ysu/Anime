using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            SeaDweller[] dwellers=new SeaDweller[4];
            using (var sr = new StreamReader("input.txt"))
            {
                for (int i = 0; i < 4; i++)
                {
                    var element = sr.ReadLine().Split(' ');
                    if (element[0] == "Fish")
                    {
                        dwellers[i] = new Fish(element[1], int.Parse(element[2]), double.Parse(element[3]), element[4], int.Parse(element[5]));
                    }
                    else if (element[0] == "Mollusks")
                    {
                        dwellers[i] = new Mollusks(element[1], int.Parse(element[2]), double.Parse(element[3]), element[4], bool.Parse(element[5]));
                    }
                    else if (element[0] == "Mammals")
                    {
                        dwellers[i] = new Mammals(element[1], int.Parse(element[2]), double.Parse(element[3]), bool.Parse(element[4]));
                    }
                    else if (element[0] == "Dolphins")
                    {
                        dwellers[i] = new Dolphins(element[1], int.Parse(element[2]), double.Parse(element[3]), bool.Parse(element[4]), element[5]);
                    }
                    else
                        Console.WriteLine("Некорректные данные!");
                }

            }
            for(int i=0; i<dwellers.Length; i++)
            {
                dwellers[i].PrintState();
                dwellers[i].BirthOfDweller();
                dwellers[i].PrintState();
                dwellers[i].WhoAmI();
                Console.WriteLine();
                Console.WriteLine();
            }
            
            Console.ReadLine();

        }
    }
}
