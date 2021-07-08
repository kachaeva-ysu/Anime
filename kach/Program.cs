using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            SeaDweller dweller1 = new SeaDweller("Dolphins",9000,390);
            dweller1.PrintState();
            dweller1.BirthOfDweller();
            dweller1.PrintState();

            SeaDweller dweller2 = new SeaDweller(null,-8,-8);
            dweller2.PrintState();
            //dweller2.dwName = "Katran Sharks";
            //dweller2.dwCount =50000;
            //dweller2.dwWeight = 15;
            //dweller2.PrintState();

            if(dweller1>dweller2)
                Console.WriteLine("{0} are heavier than {1}\r\n", dweller1.DwName, dweller2.DwName);
            else
                Console.WriteLine("{0} are NOT heavier than {1}\r\n", dweller1.DwName, dweller2.DwName);


            if (dweller1 == dweller2)
                Console.WriteLine("They are the same!\r\n");
            else
                Console.WriteLine("They are different!\r\n");

            Console.ReadLine();
        }
    }
}
