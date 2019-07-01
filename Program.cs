using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM12months
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] months = new int[12];
            for(int i = 0; i < 12; i++)
            {
                months[i] = (i == 1) ? 28 : (((i % 2 == 0 && i <= 6 || (i % 2 != 0 && i >= 6)) ? 31 : 30);
                //if (i == 1) 
                //{
                //    months[i] = 28;
                //}
                //if ((i % 2 == 0 && i <= 6 || (i % 2 != 0 && i >= 6))
                //{
                //    months[1] = 31;
                //}
                //else
                //{
                //    months[i] = 30;
                //}
            }/*onsole.Write(months[i] + "; ");*/
        }
        //Console.ReadKey()
        
    }
}
;
