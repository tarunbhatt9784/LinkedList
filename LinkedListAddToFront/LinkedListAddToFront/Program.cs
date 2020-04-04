using System;

namespace LinkedListAddToFront
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListNode<string> node;
            LinkedList<string> list = new LinkedList<string>(); 
            for (int i = 0; i < 5; i++){
                node = new LinkedListNode<string>($"Value-{i}");
                list.AddToFront(node);
                string listString = "";
                LinkedListNode<string> ptr = list.Head;
                for (int j = 0; j<list.Count; j++)
                {
                    listString = $"{listString}{ptr.Value} --> ";
                    ptr = ptr.Next;
                }
                Console.WriteLine($"{listString}null");
            }
        }
    }

    class LinkedListNode<T>
    {
        public LinkedListNode(T value){
            Value = value;
        }
        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }
    }

    class LinkedList<T>
    {
        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; }
        public int Count { get; set; }
        public void AddToFront(LinkedListNode<T> node)
        {
            LinkedListNode<T> temp = Head;
            Head = node;
            Head.Next = temp;
            Count++;
            if (Count == 1) Tail = Head;
        }
    }
}
