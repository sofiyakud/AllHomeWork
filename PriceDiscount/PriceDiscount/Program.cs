using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceDiscount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter price :");
            string priceString = Console.ReadLine();
            int price = Convert.ToInt32(priceString);

            double discount;
            double sumOfDiscount;
            double toPay;


            if (price >= 0 && price <= 299)
            {
                discount = 0;
                Console.WriteLine("Your dont have a discount:((");

            }
            else if (price >= 300 && price <= 399)
            {
                discount = 3;
                sumOfDiscount = price / 100 * discount;
                toPay = price - sumOfDiscount;

                Console.WriteLine($"Your discount:-3% ,Sum of discount : {sumOfDiscount} $ , To pay : {toPay} $");

            }

            else if (price >= 400 && price <= 499)
            {
                discount = 5;
                sumOfDiscount = price / 100 * discount;
                toPay = price - sumOfDiscount;

                Console.WriteLine($"Your discount:-5% ,Sum of discount : {sumOfDiscount} $ , To pay : {toPay} $");

            }
            else if (price >= 500)
            {
                discount = 7;
                sumOfDiscount = price / 100 * discount;
                toPay = price - sumOfDiscount;

                Console.WriteLine($"Your discount:-7% ,Sum of discount : {sumOfDiscount} $ , To pay : {toPay} $");

            }
            Console.ReadKey();
        }
    }
}
