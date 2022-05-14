using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectA.data_structure
{
    internal class CustomStack<T>
    {
        private int count;
        private Node<T> head;

        public CustomStack() { }

        public void Push(T value)
        {
            Node<T> node = new Node<T>(value, null);
        }
    }
}
