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
            count = 0;
        }

        public void push(T value)
        {
            Node<T> node = new Node<T>(value);
            node.Previous = tail;
            tail = node;
            if (head == null) head = node;
            count++;
        }

        public T peek()
        {
            return tail.Data;
        }

        public T pop()
        {
            T data = tail.Data;
            tail = tail.Previous;
            if (tail != null)
            {
                tail.Next = null;
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
                Node<T> node = tail;
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
