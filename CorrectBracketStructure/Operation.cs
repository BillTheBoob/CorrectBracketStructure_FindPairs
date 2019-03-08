using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectBracketStructure
{
    class Operation
    {
        public bool CheckupFunction(string s)
        {
            int count = 0;
            int temp = 0;
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

                if (temp == 0 && count == -1)
                {
                    return false;
                }
                temp = count;
            }
                return count != 0 ? false : true;
            }
        }
}

