using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using LotusFlareTasks;

namespace BenchmarkingTask2
{
    [MemoryDiagnoser]
    public class Task2
    {
        public Random rnd = new Random();
        /*
        public int[] test_array_1 = new int[]
        {
            45, 50, 54, 60, 9365, 4977, 339, 4198, 6757, 402, 3464,  2052, 2008, 35, 48, 85, 88, 16, 66, 9200, 6283, 1228, 75, 81, 2547,
            100, 108, 135, 4050, 15, 150, 162, 6, 180, 225, 860, 270, 4, 300, 324, 405, 450, 540,675, 6533, 810,
            9798, 5093, 698, 8955, 5643, 5225, 6, 2902, 9810, 5890, 8359, 9458, 5695, 4354, 71, 75, 13, 19, 5455, 817, 9751, 3063, 8999,
            900, 1350, 1, 1620, 2025, 90, 83, 8100, 2700, 387, 828, 7860, 950, 6200, 9427, 7479, 574, 6013, 2, 3,
            2480, 20, 25, 2162, 3143, 27, 30, 36, 3, 81, 37, 2, 7, 9, 33, 8, 29, 87, 36, 26,  92, 38, 52,
            6176, 5661, 41, 32, 53, 82,  9027, 3146, 2504, 9165, 2747, 7011,  7893, 2011, 1538,
            6535, 6690,  85, 88, 16, 66, 19, 25, 6, 1999, 893, 5072, 5789,1009, 7885, 7931, 8615, 9761, 1733, 5718, 7935, 8324, 5130, 5854, 1688,
            9587, 5021, 451, 5066, 3509,  5, 3344 , 9, 10, 12, 2749, 4 ,98 ,95 ,64 ,50 ,18, 8454, 1534, 2709, 7704, 7995, 2871
        };

        public int test_value_1 = 8100;


        public static int[] test_array_2 = new int[]
        {
            8567601, 45, 50, 54, 5711734 ,588, 60, 8376, 49098, 136808, 9365, 3263848, 4977, 1631924, 339, 4198, 2447886 , 1396, 6757, 402, 3464,  2052, 2008, 35, 48,196, 85, 88, 16, 66, 9200, 6283, 1228, 75, 81, 2547,
            100, 108, 135, 4050, 815962, 15, 150,1002,102606 ,162, 6, 34202,180,1223943,225, 860, 270, 4, 300, 324, 405,4008, 450, 540,675, 174849,6533, 810,32732,
            9798, 5093, 698,9791544,9352,392,2443,4188, 1047,8955, 5643, 501,5225, 6, 2902,147 ,9810, 5890, 8359,699396, 9458, 668,5695,7329,4354,56, 65464,71, 75, 13, 466264,28, 19, 410424,5455, 817, 9751, 3063, 8999,
            900, 1350, 1, 22846936, 1620,9772, 2025,334,29316, 7014,90, 84,83, 8100,167 ,2700, 387,8183, 828, 7860, 950, 6200, 9427,24549, 7479, 574, 6013, 2004,2, 3,196392,4676,
            2480, 20, 25, 34270404,28056, 16366,2162, 3143, 698,27,2094,3507,168, 42, 2338,30, 36, 3, 81, 37, 2, 7, 68540808 , 9, 33, 8,17101, 29, 87, 12,36, 349698,26,  92, 51303,38,98, 52, 2855867,
            6176, 5661, 8, 14, 41, 17135202, 1,2792,4886, 58632,32, 7,1169,53, 233132,82,  9027,14658, 3146, 2504, 9165, 2747, 294,7011, 1176, 7893, 2011, 98196,1538,349,
            6535, 6690, 11423468, 85, 19544,88, 16, 21,58283, 66, 19, 25,68404, 6, 1999, 893, 5072, 5789,1009, 7885, 7931, 8615, 9761, 1733, 5718, 7935, 8324, 5130, 5854, 1688,
            9587, 5021, 451, 5066, 3509, 24, 205212,4895772, 14028,1336, 5, 116566,1398792,3344 , 9, 10, 12, 2749, 4 ,98 ,95 ,64 ,50 ,49,18, 8454, 407981,1534, 2709, 7704, 7995, 2871
        };

        public int test_value_2 = 68540808;
        */


        public Int64[] random_array_with_divisors(int size, Dictionary<Int64, Int64> divisors)
        {
            Int64[] temp = new Int64[size];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = rnd.Next();
            }

            foreach (var pair in divisors)
            {
                temp[rnd.Next(0, temp.Length)] = pair.Key;
            }
            foreach (var pair in divisors)
            {
                temp[rnd.Next(0, temp.Length)] = pair.Value;
            }
            return temp;
        }


        [Benchmark]
        public void FindDivisors_1()
        {
            Operation operation = new Operation();
            var result = operation.FindPairsMethodOne(random_array_with_divisors(1200, operation.AllProducts(8100)), 8100);
            Debug.WriteLine(result);
        }

        [Benchmark]
        public void FindDivisors_2()
        {
            Operation operation = new Operation();
            var result = operation.FindPairsMethodOne(random_array_with_divisors(200, operation.AllProducts(4294567296)), 4294567296);
            Debug.WriteLine(result);
        }

        [Benchmark]
        public void BruteForce1()
        {
            Operation operation = new Operation();
            var result = operation.FindPairsMethodTwo(random_array_with_divisors(1200, operation.AllProducts(8100)), 8100);
            Debug.WriteLine(result);
        }

        [Benchmark]
        public void BruteForce2()
        {
            Operation operation = new Operation();
            var result = operation.FindPairsMethodTwo(random_array_with_divisors(200, operation.AllProducts(4294567296)), 4294567296);
            Debug.WriteLine(result);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Task2>();
        }
    }
}
