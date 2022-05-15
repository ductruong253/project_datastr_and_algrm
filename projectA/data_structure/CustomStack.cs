namespace projectA.data_structure
{
    internal class CustomStack<T>
    {
        private int count;
        
        private Node<T>? tail;

        public int Count { get { return count; } }

        public CustomStack()
        {
            count = 0;
        }

        public void push(T value)
        {
            Node<T> node = new Node<T>(value);
            node.Previous = tail;
            tail = node;
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
            tail.Next = null;
            count--;
            return data;
        }
        
    }
}
