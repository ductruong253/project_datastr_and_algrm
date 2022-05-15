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
        public static cQueue<string> postfixBuild(string original)
        {
            cStack<string> stack = new cStack<string>();
            cQueue<string> result = new cQueue<string>();

            int originalLen = original.Length;
            int idx = 0;
            string tempStr = "";
            string currentOprt = "";
            if (original[0].Equals('-') || original[0].Equals('+'))
            {
                result.enQueue("0");
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
                    result.enQueue(tempStr);
                    tempStr = "";
                }
                else if (isOperator(original[idx]))
                {
                    currentOprt = original[idx].ToString();
                    if (currentOprt.Equals(")"))
                    {
                        do
                        {
                            result.enQueue(stack.pop());
                        }while (!stack.peek().ToString().Equals("("));
                        stack.pop();
                    }
                    else
                    {
                        if (currentOprt.Equals("("))
                        {
                            if (original[idx + 1].ToString().Equals("-")) result.enQueue("0");
                        }
                        else if (!stack.isEmpty())
                        {
                            if (oprtRankCheck(currentOprt) < oprtRankCheck(stack.peek()))
                            {
                                result.enQueue(stack.pop());
                            }
                        }
                        stack.push(currentOprt);
                    }
                    idx++;
                }
                Console.WriteLine(stack.toString());
                Console.WriteLine(result.toString());
            }
            while (!stack.isEmpty())
            {
                result.enQueue(stack.pop());
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
    }
}
