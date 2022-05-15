using System;
using projectA.data_structure;

namespace projectA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> stack = new CustomStack<string>();
            stack.push("sad");
            Console.WriteLine(stack.peek());
        }
    }
}