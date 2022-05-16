using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectA.data_structure;

namespace projectA.ult
{
    internal class PolishNotationBuilder
    {
        private const string operators = "()!^/*-+";
        private const string numerics = "0123456789";
        public static Queue<string> postfixBuild(string original)
        {
            Stack<string> stack = new Stack<string>();
            Queue<string> result = new Queue<string>();

            int originalLen = original.Length;
            int idx = 0;
            string tempStr = "";
            string currentOprt = "";
            if (original[0].Equals('-') || original[0].Equals('+'))
            {
                result.Enqueue("0");
            }
            while (idx < originalLen)
            {
                if (isNumeric(original[idx]))
                {
                    while (idx < originalLen)
                    {
                        if ((isNumeric(original[idx]) || original[idx].Equals(".")))
                        {
                            tempStr += original[idx];
                        }
                        else break;
                        idx++;
                    }
                    result.Enqueue(tempStr);
                    tempStr = "";
                }
                else if (isOperator(original[idx]))
                {
                    currentOprt = original[idx].ToString();
                    if (currentOprt.Equals(")"))
                    {
                        do
                        {
                            result.Enqueue(stack.Pop());
                        }while (!stack.Peek().ToString().Equals("("));
                        stack.Pop();
                    }
                    else
                    {
                        if (currentOprt.Equals("("))
                        {
                            if (original[idx + 1].ToString().Equals("-")) result.Enqueue("0");
                        }
                        else if (stack.Count!=0)
                        {
                            while (oprtRankCheck(currentOprt) < oprtRankCheck(stack.Peek()))
                            {
                                result.Enqueue(stack.Pop());
                                if (stack.Count==0) break;
                            }
                        }
                        stack.Push(currentOprt);
                    }
                    idx++;
                }
                Console.WriteLine("Stack: {0}", stackToString(stack));
                Console.WriteLine("Queue: {0}", result.ToString());
            }
            while (stack.Count!=0)
            {
                result.Enqueue(stack.Pop());
            }
            return result;
        }

        private static bool isOperator(char check)
        {
            return operators.Contains(check);
        }

        private static bool isNumeric(char check)
        {
            return numerics.Contains(check);
        }

        private static int oprtRankCheck(string oprt)
        {
            switch (oprt)
            {
                case "!":
                    return 6;
                case "^":
                    return 5;
                case "/":
                    return 4;
                case "*":
                    return 3;
                case "-":
                    return 2;
                case "+":
                    return 1;
                default:
                    return 0;
            }
        }
        private static string stackToString(Stack<string> stack)
        {
            stack.CopyTo
            string result = "]";
            while (stack.Count != 0)
            {
                result = stack.Pop() + result;
                if (stack.Count != 0) result = ", " + result;
            }
            result += "[";
            return result;
        }
    }
}
