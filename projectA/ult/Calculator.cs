using projectA.data_structure;

namespace projectA.ult
{
    internal class Calculator
    {
        public static double execute(string expression)
        {
            if (expression == null || expression.Length == 0)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            cQueue<string> notationQueue = PolishNotationBuilder.postfixBuild(expression);
            cStack<double> result = new cStack<double>();
            string item;
            while (notationQueue.Count > 0)
            {
                item = notationQueue.Dequeue();
                if (Utils.isOperator(item[0]) && item.Length == 1)
                {
                    if (item.Equals("!"))
                    {
                        result.Push(doFactorial(Convert.ToInt32(result.Pop())));
                    }
                    else
                    {
                        double second = result.Pop();
                        double first = result.Pop();
                        result.Push(calculate(item[0], first, second));
                    }
                }
                else
                {
                    result.Push(double.Parse(item));
                }
            }
            return result.Pop();
        }


        public static double calculate(char oprt, double first_operand, double second_operand)
        {
            switch (oprt)
            {
                case '+':
                    return first_operand + second_operand;
                case '-':
                    return first_operand - second_operand;
                case '*':
                    return first_operand * second_operand;
                case '/':
                    return first_operand / second_operand;
                case '^':
                    return Math.Pow(first_operand, second_operand);
                default:
                    return 0.0;
            }
        }

        public static int doFactorial(int operand)
        {
            if (operand == 0 || operand == 1) return operand;
            else return operand * doFactorial(operand - 1);
        }
    }
}
