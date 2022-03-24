using System;
using System.Collections.Generic;
using System.Text;

namespace Clases
{
    public class Node<T>
    {
        public Node<T> Father = null;
        public Node<T> RightSon = null;
        public Node<T> LeftSon = null;

        public T Key;
        public int Priority;
        public DateTime DatePriority;

        //Creación del constructor
        public Node() 
        {
            
        }
        public Node(T key, DateTime Date, int priority)
        {
            Key = key;
            DatePriority = Date;
            Priority = priority;
        }
    }
}
