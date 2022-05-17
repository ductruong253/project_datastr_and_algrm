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
            head = tail = null;
        }

        public void Enqueue(T value)
        {
            Node<T> node = new Node<T>(value);
            if (tail == null)
            {
                head = tail = node;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }
            count++;
        }

        public T Peek()
        {
            return head.Data;
        }

        public T Dequeue()
        {
            if (head == null) return default(T);
            T data = head.Data;
            head = head.Next;
            if (head == null) tail = null;
            count--;
            return data;
        }

        public Boolean isEmpty()
        {
            return head == null;
        }

        public cQueue<T> Copy()
        {
            cQueue<T> copy = new cQueue<T>();
            if (head != null)
            {
                Node<T> node = head;
                do
                {
                    copy.Enqueue(node.Data);
                    node = node.Next;
                } while (node.hasNext());
            }
            return copy;
        }
    }
}
