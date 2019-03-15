using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusFlareTasks
{
    public class Operation
    {
        public bool CheckCorrectBracketStructure(string s)
        {
            var temp = new Stack<char>();
            var dict = new Dictionary<char, char> { { '(', ')' }, { '[', ']' }, { '{', '}' } };

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                {
                    temp.Push(s[i]);
                }
                else
                {
                    if (temp.Count != 0 && dict[temp.Peek()] == s[i])
                    {
                        temp.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return temp.Count != 0 ? false : true;
        }


        public Dictionary<Int64, Int64> AllProducts(Int64 N)
        {
            Dictionary<Int64, Int64> product = new Dictionary<Int64, Int64> { };
            for (int i = 1; i <= Math.Sqrt(N); i++)
            {
                if (N % i == 0)
                {
                    product.Add(i, N / i);
                }
            }
            return product;
        }


        public Int64[] MergeSort(Int64[] array, int start, int end)
        {
            if (end - start < 2)
            {
                return new Int64[] { array[start] };
            }

            int middle = start + ((end - start) / 2);
            Int64[] left = MergeSort(array, start, middle);
            Int64[] right = MergeSort(array, middle, end);

            Int64[] result = new Int64[left.Length + right.Length];

            int idxL = 0;
            int idxR = 0;
            int i = 0;

            for (; idxL < left.Length && idxR < right.Length; i++)
            {
                if (left[idxL] < right[idxR])
                {
                    result[i] = left[idxL];
                    idxL++;
                }
                else
                {
                    result[i] = right[idxR];
                    idxR++;
                }
            }

            while (idxL < left.Length)
            {
                result[i++] = left[idxL++];
            }
            while (idxR < right.Length)
            {
                result[i++] = right[idxR++];
            }

            return result;
        }


        public int UpperBound(Int64[] array, Int64 Number)
        {
            int i = array.Length - 1;
            while (array[i] > Number)
            {
                i--;
            }
            return i;
        }


        public int BinarySearch(Int64[] array, int upper_bound, Int64 key)
        {
            int min = 0;
            int max = upper_bound;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == array[mid])
                {
                    return ++mid;
                }
                else if (key < array[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return 0;
        }


        /*
            Метод принимает на вход массив и заданное число. 
            После чего находятся все делители заданного числа. 
            Массив сортируется, после чего идет бинарный поиск делителей в массиве.
        */
        public Dictionary<Int64, Int64> FindPairsMethodOne(Int64[] array, Int64 Number)
        {
            array = MergeSort(array, 0, array.Length);
            var upper_bound = UpperBound(array, Number);
            var all_pairs = AllProducts(Number);

            var result = new Dictionary<Int64, Int64> { };
            foreach (var entry in all_pairs)
            {
                var key = entry.Key;
                var value = entry.Value;
                if (BinarySearch(array, upper_bound, key) != 0 && BinarySearch(array, upper_bound, value) != 0)
                {
                    result.Add(key, value);
                }
            }
            return result;
        }


        public bool DictionaryCompare(Dictionary<Int64, Int64> d1, Dictionary<Int64, Int64> d2)
        {
            if (d1.Count != d2.Count)
            {
                return false;
            }

            foreach (var kv1 in d1)
            {
                if (d2.ContainsKey(kv1.Key) == false) return false;
            }
            return true;
        }


        public bool IsDuplicate(int tmp, int[] array)
        {
            foreach (var item in array)
            {
                if (item == tmp)
                {
                    return true;
                }
            }
            return false;
        }


        public Int64[] random_array_with_divisors(int size, Dictionary<Int64, Int64> divisors)
        {
            Random rnd = new Random();

            Int64[] temp = new Int64[size];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = rnd.Next();
            }

            int[] divisors_indexes = new int[divisors.Count << 1];

            for (int i = 0; i < divisors_indexes.Length; i++)
            {
                var tmp = rnd.Next(0, temp.Length);
                while (IsDuplicate(tmp, divisors_indexes))
                {
                    tmp = rnd.Next(0, temp.Length);
                }
                divisors_indexes[i] = tmp;
            }

            int k = 0;
            foreach (var pair in divisors)
            {
                temp[divisors_indexes[k]] = pair.Key;
                temp[divisors_indexes[k + 1]] = pair.Value;
                k += 2;
            }



            temp = temp.Distinct().ToArray();
            return temp;
        }


        /*
             Метод принимает на вход массив и заданное число. 
             После чего с помощью двух циклов происходит переумножение всех чисел и 
             проверяется, является ли результат заданым числом. 
        */
        public Dictionary<Int64, Int64> FindPairsMethodTwo(Int64[] array, Int64 Number)
        {
            var result = new Dictionary<Int64, Int64> { };
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[i] * array[j] == Number)
                    {
                        if (array[i] < array[j])
                        {
                            result.Add(array[i], array[j]);
                        }
                        else
                        {
                            result.Add(array[j], array[i]);
                        }
                    }
                }
            }
            return result;
        }
    }
}


