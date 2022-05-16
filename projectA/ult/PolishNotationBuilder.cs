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
        private const string operators = "!^/*-+";
        private const string brackets = "()";
        private const string numerics = "0123456789";
        public static Queue<string> postfixBuild(string original)
        {
            Stack<char> stack = new Stack<char>();
            Queue<string> result = new Queue<string>();
            original = "(" + original + ")";
            int originalLen = original.Length;
            int idx = 0;
            string tempStr = "";
            char currentChar;
            if (original[0].Equals('-') || original[0].Equals('+'))
            {
                result.Enqueue("0");
            }
            while (idx < originalLen)
            {
                currentChar = original[idx];
                if (isNumeric(currentChar))
                {
                    int latch = idx;
                    while (idx < originalLen)
                    {
                        currentChar = original[idx];
                        if ((isNumeric(currentChar) || currentChar.Equals('.')))
                        {
                            tempStr += currentChar;
                        }
                        else break;
                        idx++;
                    }
                    if (original[latch - 1].Equals('-') && original[latch - 2].Equals('('))
                    {
                        tempStr = "-" + tempStr;
                        stack.Pop();
                    }
                    result.Enqueue(tempStr);
                    tempStr = "";
                }
                else if (isOperator(currentChar))
                {
                    if (stack.Count != 0)
                    {
                        while (oprtRankCheck(currentChar) < oprtRankCheck(stack.Peek()))
                        {
                            result.Enqueue(stack.Pop().ToString());
                            if (stack.Count == 0) break;
                        }
                    }
                    stack.Push(currentChar);
                    idx++;
                }
                else if (isBracket(currentChar))
                {
                    if (currentChar.Equals(')'))
                    {
                        do
                        {
                            result.Enqueue(stack.Pop().ToString());
                        } while (!stack.Peek().ToString().Equals("("));
                        stack.Pop();
                    }
                    else stack.Push(currentChar);
                    idx++;
                }
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Stack: {0}", stackToString(stack));
                Console.WriteLine("Queue: {0}", queueToString(result));
            }
            while (stack.Count != 0)
            {
                result.Enqueue(stack.Pop().ToString());
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
        private static bool isBracket(char check)
        {
            return brackets.Contains(check);
        }

        private static int oprtRankCheck(char oprt)
        {
            switch (oprt)
            {
                case '!':
                    return 6;
                case '^':
                    return 5;
                case '/':
                    return 4;
                case '*':
                    return 3;
                case '-':
                    return 2;
                case '+':
                    return 1;
                default:
                    return 0;
            }
        }
        public static string stackToString(Stack<char> stack)
        {
            Stack<char> newStack = new Stack<char>(stack);
            newStack.Reverse();
            string result = "[";
            while (newStack.Count != 0)
            {
                result += newStack.Pop();
                if (newStack.Count != 0) result += ", ";
            }
            result += "]";
            return result;
        }

        public static string queueToString(Queue<string> queue)
        {
            Queue<string> newqueue = new Queue<string>(queue);
            newqueue.Reverse();
            string result = "[";
            while (newqueue.Count != 0)
            {
                result += newqueue.Dequeue();
                if (newqueue.Count != 0) result += ", ";
            }
            result += "]";
            return result;
        }
    }
}
