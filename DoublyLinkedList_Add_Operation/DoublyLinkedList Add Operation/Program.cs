using System;

namespace Add_Operation
{
    class Program
    {
        static void Main(string[] args)
        {
            // ************Test Add First**************
            Console.WriteLine("************Test Add First**************"); 
            TestAddFirst();
            Console.WriteLine("****************************************");
            Console.WriteLine(); 
            Console.WriteLine("************Test Add Last**************");
            TestAddLast();
            Console.WriteLine("****************************************");


        }

        static void TestAddFirst()
        {
            LinkedListNode<string> node;
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();

            /* 
             * Ignore the logic in the for loop.
             * A lot of it has been written to display the contents of the 
             * Doubly Linked List in a presentable format
             * The Logic below adds 5 element to an empty 
             * Doubly Linked List one after another
             * 
             * The most important function in this project is AddFirst()
             * in the DoublyLinkedList class
             */
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Add node with Data Field as 'Value -{ i}'");
                node = new LinkedListNode<string>($"Value -{i}");
                list.AddFirst(node);
                string listString = "null";
                LinkedListNode<string> ptr = list.Head;
                for (int j = 0; j < list.Count; j++)
                {
                    listString = $"{listString} <-- {ptr.Value} --> ";
                    ptr = ptr.Next;
                }
                listString = listString.Replace("-->  <--", "<-->");
                Console.WriteLine($"{listString}null");
                Console.WriteLine($"Data field of Head --> '{list.Head.Value}' & Data field of Tail --> '{list.Tail.Value}'");
                Console.WriteLine();
            }
        }

        static void TestAddLast()
        {
            LinkedListNode<string> node;
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();

            /* 
             * Ignore the logic in the for loop.
             * A lot of it has been written to display the contents of the 
             * Doubly Linked List in a presentable format
             * The Logic below adds 5 element to an empty 
             * Doubly Linked List one after another from the end
             * 
             * The most important function in this project is AddToEnd()
             * in the DoublyLinkedList class
             */
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Add node with Data Field as 'Value -{ i}'");
                node = new LinkedListNode<string>($"Value -{i}");
                list.AddLast(node);
                string listString = "null";
                LinkedListNode<string> ptr = list.Head;
                for (int j = 0; j < list.Count; j++)
                {
                    listString = $"{listString} <-- {ptr.Value} --> ";
                    ptr = ptr.Next;
                }
                listString = listString.Replace("-->  <--", "<-->");
                Console.WriteLine($"{listString}null");
                Console.WriteLine($"Data field of Head --> '{list.Head.Value}' & Data field of Tail --> '{list.Tail.Value}'");
                Console.WriteLine();
            }
        }
    }

    class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Previous { get; set; }

    }


    class DoublyLinkedList<T>
    {
        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; }
        public int Count { get; set; }
        public void AddFirst(LinkedListNode<T> node)
        {
            // Step -1: Save the head node in a temporary variable
            LinkedListNode<T> temp = Head;

            // Step - 2: Point the head of the Linked List to the new Node
            Head = node;

            // Step - 3:Point the next field of the Head node to the temporary variable.
            Head.Next = temp;

            if (Count == 0)
            {
                // if the list was empty then Head and Tail should
                // both point to the new node.
                Tail = Head;
            }
            else
            {
                // Step - 4:Point the next field of the Head node to the temporary variable.
                temp.Previous = Head;
            }

            Count++;
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (Count == 0)
            {
                // If the list is empty, the first node will become the head
                Head = node;
            }
            else
            {
                // Step -1: Point the Next Field of Tail Node to the new Node
                Tail.Next = node;

                // Step - 2: Point the Previous field of the new node to the Tail Node
                node.Previous = Tail;
            }

            //Step - 3: Point the Tail of the Linked List to the new Node
            Tail = node;

            // Incremement the count
            Count++;
        }
    }
}
