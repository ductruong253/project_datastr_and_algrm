using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectA.data_structure
{
    internal class Node<T>
    {
        private T data;
        private Node<T> next;

        public Node(){}
        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }

        public T Data;
        public Node<T> Next;

        public Boolean hasNext()
        {
            return next != null;
        }
    }
}
