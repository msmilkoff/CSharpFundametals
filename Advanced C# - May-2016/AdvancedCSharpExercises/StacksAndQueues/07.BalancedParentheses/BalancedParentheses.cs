namespace _07.BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class BalancedParentheses
    {
        public static void Main(string[] args)
        {
            string expression = Console.ReadLine().Trim();

            expression = Regex.Replace(expression, @"/s+", "");

            string result = CheckBalancedParentheses(expression)
                ? "YES"
                : "NO";
            Console.WriteLine(result);
        }

        private static bool CheckBalancedParentheses(string expression)
        {
            // if the number of parentheses is odd they cannot be balanced
            bool isBalanced = expression.Length % 2 == 0;

            var bracketPairs = new Dictionary<char, char>()
            {
                {'(', ')'},
                {'[', ']'},
                {'{', '}'}
            };

            var parentheses = new Stack<char>();
            foreach (char bracket in expression)
            {
                if (bracketPairs.ContainsKey(bracket))
                {
                    parentheses.Push(bracket);
                }
                else if (bracketPairs.ContainsValue(bracket))
                {
                    if (!parentheses.Any())
                    {
                        return false;
                    }

                    var currentChar = parentheses.Pop();
                    if (bracket != bracketPairs[currentChar])
                    {
                        isBalanced = false;
                    }
                }
            }

            return isBalanced;
        }
    }
}