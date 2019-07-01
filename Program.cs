using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int number = rnd.Next(1000000);
            int counter = (number == 0 )? 1 : 0;
            int dight = 0;
            int sum = 0;
            int odd = 0;
            Console.WriteLine("Random number" + number);
            do
            {
                dight = number % 10;
                if (dight % 3 == 0)
                {
                    sum += dight;
                }
                if (dight % 2 != 0)
                {
                    odd++;
                }
                counter++;
            }
            while ((number /= 10) > 0);
            
                Console.WriteLine(counter);
            
            Console.ReadKey();

            





        } 
    }
}
