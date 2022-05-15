namespace projectA.data_structure
{
    internal class Node<T>
    {
        private T data;
        private Node<T>? next;
        private Node<T>? previous;

        public Node(){}
        public Node(T data)
        {
            this.data = data;
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
        public Node<T> Previous
        {
            get { return previous; }
            set { previous = value; }
        }

        public Boolean hasNext()
        {
            return next != null;
        }

        public Boolean hasPrev()
        {
            return previous != null;
        }
    }
}
