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
            cQueue<string> result = PolishNotationBuilder.postfixBuild(data[0]);
            Console.WriteLine(result.toString());
        }
    }
}