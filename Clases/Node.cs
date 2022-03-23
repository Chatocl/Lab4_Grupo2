using System;
using System.Collections.Generic;
using System.Text;

namespace Clases
{
    public class Node<T>
    {
        public Node<T> Father;
        public Node<T> RightSon;
        public Node<T> LeftSon;

        public string Key;
        public int Priority;
        public DateTime DatePriority;

        //Creación del constructor
        public Node(string key, DateTime Date, int priority)
        {
            Key = key;
            DatePriority = Date;
            Priority = priority;
        }
    }
}
