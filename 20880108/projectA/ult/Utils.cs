using projectA.data_structure;

namespace projectA.ult
{
    internal class Utils
    {
        private const string operators = "!^/*-+";
        private const string brackets = "()";
        private const string numerics = "0123456789";

        public static bool isOperator(char check)
        {
            return operators.Contains(check);
        }

        public static bool isNumeric(char check)
        {
            return numerics.Contains(check);
        }
        public static bool isBracket(char check)
        {
            return brackets.Contains(check);
        }

        public static string stackToString(cStack<char> stack)
        {
            cStack<char> newStack = stack.Reverse();
            string result = "[";
            while (newStack.Count != 0)
            {
                result += newStack.Pop();
                if (newStack.Count != 0) result += ", ";
            }
            result += "]";
            return result;
        }

        public static string stackToString(cStack<double> stack)
        {
            cStack<double> newStack = stack.Reverse();
            string result = "[";
            while (newStack.Count != 0)
            {
                result += newStack.Pop();
                if (newStack.Count != 0) result += ", ";
            }
            result += "]";
            return result;
        }

        public static string queueToString(cQueue<string> queue)
        {
            cQueue<string> newqueue = queue.Copy();
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
