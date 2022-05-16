namespace projectA.data_structure
{
    internal class cQueue<T>
    {
        private int count;

        private Node<T>? head;

        private Node<T>? tail;

        public int Count { get { return count; } }

        public cQueue()
        {
            count = 0;
        }

        public void Enqueue(T value)
        {
            Node<T> node = new Node<T>(value);
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }
            count++;
        }

        public T peek()
        {
            return head.Data;
        }

        public T Dequeue()
        {
            T data = head.Data;
            Node<T> node = head.Next;
            head.Next = null;
            head = node;
            if (head != null)
            {
                head.Previous = null;
            }
            count--;
            return data;
        }

        public Boolean isEmpty()
        {
            return head == null;
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
