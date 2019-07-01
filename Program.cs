using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkRANDOM1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Guess my number from 1 to 100.You have only 5 attempts");
            Random rnd = new Random();
            int number = rnd.Next(1, 101);
            Boolean win = false;

            for (int attempt = 1; attempt < 6; attempt++)
            {
                string stringUserNumber = Console.ReadLine();
                int userNumber = Convert.ToInt32(stringUserNumber);
                
                if (userNumber == number)
                {
                    win = true;
                    Console.WriteLine("Attempt №" + attempt+ "Congrats!!!You guessed my number");
                    break;
                }

                else if (userNumber < number)
                {
                    Console.WriteLine("My number is bigger"+ "\nAttempt №" + attempt);
                }
                else if (userNumber > number)
                {
                    Console.WriteLine("My number is lower"+ "\nAttempt №" + attempt);
                }
            }
            Console.WriteLine(win ? "you are win" : "You are looser");
            Console.ReadLine();
        }
    }
}
