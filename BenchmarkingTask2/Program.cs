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
        public static Operation operation = new Operation();
        
        public Int64[] random_array1 = operation.random_array_with_divisors(1200, operation.AllProducts(8100));
        public Int64[] random_array2 = operation.random_array_with_divisors(200, operation.AllProducts(4294567296));

        [Benchmark]
        public void FirstMethod_big_array_small_number()
        {
            Operation operation = new Operation();
            var result = operation.FindPairsMethodOne(random_array1, 8100);
            Debug.WriteLine(result);
        }

        [Benchmark]
        public void FirstMethod_small_array_big_number()
        {
            Operation operation = new Operation();
            var result = operation.FindPairsMethodOne(random_array2, 4294567296);
            Debug.WriteLine(result);
        }

        [Benchmark]
        public void SecondMethod_big_array_small_number()
        {
            Operation operation = new Operation();
            var result = operation.FindPairsMethodTwo(random_array1, 8100);
            Debug.WriteLine(result);
        }

        [Benchmark]
        public void SecondMethod_small_array_big_number()
        {
            Operation operation = new Operation();
            var result = operation.FindPairsMethodTwo(random_array2, 4294567296);
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
