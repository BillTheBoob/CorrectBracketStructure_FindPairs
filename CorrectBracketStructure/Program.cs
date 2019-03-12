using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusFlareTasks
{
    class Program
    {

        static void Main(string[] args)
        {
            Int64 N = 4294567296;
            for (int i = 1; i <= Math.Sqrt(N); i++)
            {
                if (N % i == 0)
                {
                    Console.WriteLine(i + ":" + N/i);
                }
            }
        }

    }
}
