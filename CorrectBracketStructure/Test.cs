using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CorrectBracketStructure
{
    [TestFixture]

    class Test
    {
        Operation operation = new Operation(); 

        [Test]
        [Description("Verifies that checkup function works correct.")]
        [TestCase("()", true)]
        [TestCase("(())", true)]
        [TestCase("(()(()))", true)]
        [TestCase("((((()))))", true)]
        [TestCase("(((((((((((())))))))))))", true)]
        [TestCase("(((()()()(())(())((((()))))())))", true)]
        [TestCase("(((((()()(())((()()()()))()()())))))", true)]
        [TestCase("(", false)]
        [TestCase(")", false)]
        [TestCase(")(", false)]
        [TestCase(")()(", false)]
        [TestCase("()))((()", false)]
        [TestCase("())))(((()", false)]
        [TestCase("()))((()))((()))((()", false)]
        [TestCase("))()())((((())))(((((", false)]
        [TestCase(")()(()()(()))())()())(()()()()())(()", false)]
        [TestCase(")(()))(()())()))()())()))))))(((())())()()())", false)]
        [TestCase("(((((((((((((((((((((((((((((((((((((((((((((", false)]
        [TestCase("((()))((((()()()()()((((((((((((((()))))((()())))))))))))((((((()()()()()", false)]
        [TestCase("(()()()())))(()()((()())))(((((((((((())))(()(()()))))(()()))))(())))))))))))))))()())()()", false)]
        public void ValidityOfTheStringTest(string s, bool expected)
        {
            bool result = operation.CheckupFunction(s);
            Assert.AreEqual(expected, result);
        }

    }
}
