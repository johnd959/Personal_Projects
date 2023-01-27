using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem1_Final_ProjectCS
{
    internal class GetInt
    {
        public static int getInt(string message, string errMessage = "", int min = int.MinValue, int max = int.MaxValue)
        {
            bool valid = false;
            int iteration = 0;
            string number;
            int result;
            do
            {
                if (iteration > 0 && valid == false)
                {
                    Console.Write(errMessage);
                }
                else
                {
                    Console.Write(message);
                }
                number = Console.ReadLine().TrimEnd();
                valid = int.TryParse(number, out result);
                iteration++;
                
            }
            while (!valid && !(string.IsNullOrEmpty(number) && !(result >= min && result <= max)));
            return result;
        }
    }
}
