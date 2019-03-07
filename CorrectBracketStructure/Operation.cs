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
            if (s[0] == ')' || s[s.Length - 1] == '(') { return false; }
            int count = 0;
            for(int i = 0; i< s.Length; i++)
            {
                if (s[i] == '(')
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }
            return count != 0 ? false : true; 
        }
    }
}
