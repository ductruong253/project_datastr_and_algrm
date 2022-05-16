namespace projectA.data_structure
{
    internal class cStack<T>
    {
        private int count;

        private Node<T>? head;

        private Node<T>? tail;

        public int Count { get { return count; } }

        public cStack()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Push(T value)
        {
            Node<T> node = new Node<T>(value);
            if (tail == null)
            {
                head = tail = node;
            }
            else
            {
                node.Previous = tail;
                tail.Next = node;
                tail = node;
            }
            count++;
        }

        public T Peek()
        {
            return tail.Data;
        }

        public T pop()
        {
            T data = tail.Data;
            if (tail.Previous == null)
            {
                tail = head;
            }
            else
            {
                tail = tail.Previous;
                if (tail != null)
                {
                    tail.Next = null;
                }
            }
            count--;
            return data;
        }

        public Boolean isEmpty()
        {
            return count == 0;
        }

        public string toString()
        {
            string result = "[";
            if (head != null)
            {
                Node<T> node = head;
                while (node != null)
                {
                    result += node.Data.ToString();
                    if (node.hasNext()) result += ", ";
                    node = node.Next;
                }
            }
            result += "]";
            return result;
        }

    }
}
