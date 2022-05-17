namespace projectA.data_structure
{
    internal class cStack<T>
    {
        private int count;

        private Node<T>? top;
        public int Count { get { return count; } }

        public cStack()
        {
            top = null;
            count = 0;
        }

        public void Push(T value)
        {
            Node<T> node = new Node<T>(value);
            if (top == null)
            {
                node.Next = null;
            }
            else
            {
                node.Next = top;
            }
            top = node;
            count++;
        }

        public T Peek()
        {
            return top.Data;
        }

        public T Pop()
        {
            if (top == null)
            {
                return default(T);
            }
            T data = top.Data;
            top = top.Next;
            count--;
            return data;
        }

        public Boolean isEmpty()
        {
            return count == 0;
        }

        public cStack<T> Reverse()
        {
            cStack<T> reversed = new cStack<T>();
            if (top != null)
            {
                Node<T> node = top;
                do
                {
                    reversed.Push(node.Data);
                    node = node.Next;
                } while (node.hasNext());
            }
            return reversed;
        }
    }
}
