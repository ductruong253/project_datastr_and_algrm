using projectA.data_structure;

namespace projectA.ult
{
    internal class PolishNotationBuilder
    {
        public static cQueue<string> postfixBuild(string original)
        {
            cStack<char> stack = new cStack<char>();
            cQueue<string> result = new cQueue<string>();
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
                if (Utils.isNumeric(currentChar))
                {
                    int latch = idx;
                    while (idx < originalLen)
                    {
                        currentChar = original[idx];
                        if ((Utils.isNumeric(currentChar) || currentChar.Equals('.')))
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
                else if (Utils.isOperator(currentChar))
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
                else if (Utils.isBracket(currentChar))
                {
                    if (currentChar.Equals(')'))
                    {
                        do
                        {
                            if (!stack.Peek().Equals('(')) result.Enqueue(stack.Pop().ToString());
                        } while (!stack.Peek().ToString().Equals("("));
                        stack.Pop();
                    }
                    else stack.Push(currentChar);
                    idx++;
                }
            }
            while (stack.Count != 0)
            {
                result.Enqueue(stack.Pop().ToString());
            }
            return result;
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

    }
}
