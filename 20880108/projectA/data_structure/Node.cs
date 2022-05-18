namespace projectA.data_structure
{
    internal class Node<T>
    {
        private T data;
        private Node<T>? next;

        public Node()
        {
            next = null;
        }
        public Node(T data)
        {
            this.data = data;
            next = null;
        }

        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        public Boolean hasNext()
        {
            return next != null;
        }
    }
}
