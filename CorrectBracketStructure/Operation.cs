using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectBracketStructure
{
    class Operation
    {
        public bool CheckCorrectBracketStructure(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    count++;
                }
                else
                {
                    count--;
                }

                if (count < 0)
                {
                    return false;
                }
            }
                return count != 0 ? false : true;
        }


        public Dictionary<int, int> AllProducts(int N)
        {
            Dictionary<int, int> product = new Dictionary<int, int> { };
            for (int i = 1; i <= Math.Sqrt(N); i++)
            {
                if (N % i == 0)
                {
                    product.Add(i, N/i);
                }
            }
            return product;
        }


        public int[] MergeSort(int[] array, int start, int end)
        {
            if(end - start < 2)
            {
                return new int[] { array[start] };
            }

            int middle = start + ((end - start) / 2);
            int[] left = MergeSort(array, start, middle);
            int[] right = MergeSort(array, middle, end);

            int[] result = new int[left.Length + right.Length];

            int idxL = 0;
            int idxR = 0;
            int i = 0;

            for(; idxL < left.Length && idxR < right.Length; i++)
            {
                if(left[idxL] < right[idxR])
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

            while(idxL < left.Length)
            {
                result[i++] = left[idxL++];
            }
            while (idxR < right.Length)
            {
                result[i++] = right[idxR++];
            }

            return result;
        }


        public int UpperBound(int[] array, int Number)
        {
            int i = array.Length - 1;
            while(array[i] > Number)
            {
                i--;
            }
            return i;
        }


        public int BinarySearch(int[] array, int upper_bound, int key)
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


        public Dictionary<int, int> FindPairsMethodOne(int[] array, int Number)
        {
            array = MergeSort(array, 0, array.Length);
            var upper_bound = UpperBound(array, Number);
            var all_pairs = AllProducts(Number);

            var result = new Dictionary<int, int> { };
            foreach (var entry in all_pairs)
            {
                var key = entry.Key;
                var value = entry.Value;
                if(BinarySearch(array, upper_bound, key) != 0 && BinarySearch(array, upper_bound, value) != 0 )
                {
                    result.Add(key, value);
                }
            }
            return result;
        }

        
        public bool DictionaryCompare(Dictionary<int, int> d1, Dictionary<int, int> d2)
        {
            if(d1.Count != d2.Count)
            {
                return false;
            }

            foreach (var kv1 in d1)
            {
                if (d2.ContainsKey(kv1.Key) == false) return false;
            }
            return true;
        }


        public Dictionary<int, int> FindPairsMethodTwo(int[] array, int Number)
        {
            array = array.Distinct().ToArray();
            var result = new Dictionary<int, int> { };
            for(int i = 0; i < array.Length; i++)
            {
                for(int j = i; j < array.Length; j++)
                {
                    if(array[i] * array[j] == Number)
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

