using System;
using projectA.data_structure;
using projectA.ult;

namespace projectA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data = IOHelper.readDataFromFile("data/data.txt");
            Queue<string> result = PolishNotationBuilder.postfixBuild(data[0]);
            Console.WriteLine(PolishNotationBuilder.queueToString(result));

            /*cStack<string> stack = new cStack<string>();
            Console.WriteLine(stack.toString());
            stack.push("5");
            Console.WriteLine(stack.toString());
            Console.WriteLine(stack.peek());
            stack.push("6");
            Console.WriteLine(stack.toString());
            Console.WriteLine(stack.peek());
            stack.pop();
            Console.WriteLine(stack.toString());
            Console.WriteLine(stack.peek());
            stack.pop();
            Console.WriteLine(stack.toString());
            stack.push("1");
            Console.WriteLine(stack.toString());*/
        }
    }
}