using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LotusFlareTasks
{
    [TestFixture]

    class TestTask1
    {
        Operation operation = new Operation();

        [Test]
        [Description("Verifies that CheckCorrectBracketStructure function works correct.")]
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
        [TestCase("([{}])", true)]
        [TestCase("([)", false)]
        [TestCase("(({{[[{{))", false)]
        [TestCase("((]]", false)]
        [TestCase("[()[]{}([{}])]{())}", false)]
        [TestCase("{()))]}{[((()}", false)]
        [TestCase("{[()](())({[]}){()}{{([])}}{(())}[()][{}][()]}", true)]
        public void CorrectStructureBracesTest(string s, bool expected)
        {
            bool result = operation.CheckCorrectBracketStructure(s);
            Assert.AreEqual(expected, result);
        }
    }


    class TestTask2
    {
        public static Operation operation = new Operation();

        private static readonly IEnumerable<TestCaseData> _testPairs = GetPairsCases();

        private static IEnumerable<TestCaseData> GetPairsCases()
        {
            yield return new TestCaseData(
                operation.random_array_with_divisors(1200, operation.AllProducts(8100)),
                operation.AllProducts(8100),
                8100);
            yield return new TestCaseData(
                operation.random_array_with_divisors(200, operation.AllProducts(4294567296)),
                operation.AllProducts(4294567296),
                4294567296);
        }
        
        [Test, TestCaseSource(nameof(_testPairs))]
        [Description("Verifies that FindPairsMethodOne works correct")]
        public void TestPairsMethod1(Int64[] random_array, Dictionary<Int64, Int64> expected_pairs, Int64 Number)
        {
            var result = operation.FindPairsMethodOne(random_array, Number);
            Assert.IsTrue(operation.DictionaryCompare(expected_pairs, result));
        }

        [Test, TestCaseSource(nameof(_testPairs))]
        [Description("Verifies that FindPairsMethodTwo work correct")]
        public void TestPairsMethod2(Int64[] random_array, Dictionary<Int64, Int64> expected_pairs, Int64 Number)
        {
            var result = operation.FindPairsMethodTwo(random_array, Number);
            Assert.IsTrue(operation.DictionaryCompare(expected_pairs, result));
        }
    }
}

     



