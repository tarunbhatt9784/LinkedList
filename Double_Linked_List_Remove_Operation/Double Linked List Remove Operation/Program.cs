using System;

namespace Double_Linked_List_Remove_Operation
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("************Test Remove from First**************");
            TestRemoveFirst();
            Console.WriteLine("****************************************");
            Console.WriteLine();
            Console.WriteLine("************Test Remove from Last**************");
            TestRemoveLast();
            Console.WriteLine("****************************************");
        }

        static void TestRemoveFirst()
        {
            // The Method call will create a dummy list.
            // Add operation could also be used. See https://medium.com/@tarunbhatt9784/doubly-linked-list-add-operations-f40542d08d5
            // GitHub Code for Add Operation https://github.com/tarunbhatt9784/LinkedList/tree/master/DoublyLinkedList_Add_Operation
            LinkedList<string> list = PrepareDummyList();
            PrintList(list);

            /* 
             * Ignore the logic in the for loop.
             * A lot of it has been written to display the contents of the 
             * Doubly Linked List in a presentable format
             * The Logic below Remove all elements from the 
             * Doubly Linked List one after another. The elements 
             * are removed from the front of the Doubly Linked List
             * 
             * The most important function to understand the logic is RemoveFirst()
             * in the LinkedList class
             */
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Remove node with Data Field as 'Value -{ i}'");
                list.RemoveFirst();
                PrintList(list);
            }
        }

        static void TestRemoveLast()
        {
            // The Method call will create a dummy list.
            // Add operation could also be used. See https://medium.com/@tarunbhatt9784/doubly-linked-list-add-operations-f40542d08d5
            // GitHub Code for Add Operation https://github.com/tarunbhatt9784/LinkedList/tree/master/DoublyLinkedList_Add_Operation
            LinkedList<string> list = PrepareDummyList();
            PrintList(list);

            /* 
            * Ignore the logic in the for loop.
             * A lot of it has been written to display the contents of the 
             * Doubly Linked List in a presentable format
             * The Logic below Remove all elements from the 
             * Doubly Linked List one after another. The elements 
             * are removed from the tail (end) of the Doubly Linked List
             * 
             * The most important function to understand the logic is RemoveLast()
             * in the LinkedList class
             */
            for (int i = 4; i >= 0; i--)
            {
                Console.WriteLine($"Remove node with Data Field as 'Value -{ i}'");
                list.RemoveLast();
                PrintList(list);
            }
        }
        static LinkedList<string> PrepareDummyList()
        {
            LinkedList<string> list = new LinkedList<string>();
            // list -> null
            
            LinkedListNode<string> node1 = new LinkedListNode<string>("Value-0");
            list.Head = node1;
            list.Count++;

            // list -> Value-0
            LinkedListNode<string> node2 = new LinkedListNode<string>("Value-1");
            node1.Next = node2;
            node2.Previous = node1;
            list.Count++;

            // list -> Value-0 <--> Value-1
            LinkedListNode<string> node3 = new LinkedListNode<string>("Value-2");
            node2.Next = node3;
            node3.Previous = node2;
            list.Count++;

            // list -> Value-0 <--> Value-1 <--> Value-2
            LinkedListNode<string> node4 = new LinkedListNode<string>("Value-3");
            node3.Next = node4;
            node4.Previous = node3;
            list.Count++;

            // list -> Value-0 <--> Value-1 <--> Value-2 < --> Value-3
            LinkedListNode<string> node5 = new LinkedListNode<string>("Value-4");
            list.Tail = node4.Next = node5;
            node5.Previous = node4;
            list.Count++;

            // list -> Value-0 <--> Value-1 <--> Value-2 < --> Value-3 <--> Value-4
            return list;
        }

        static void PrintList(LinkedList<string> list)
        {
            string listString = "null";
            LinkedListNode<string> ptr = list.Head;
            for (int j = 0; j < list.Count; j++)
            {
                listString = $"{listString} <-- {ptr.Value} --> ";
                ptr = ptr.Next;
            }
            listString = listString.Replace("-->  <--", "<-->");
            Console.WriteLine($"{listString}null");
            if (list.Count > 0) Console.WriteLine($"Data field of Head --> '{list.Head.Value}' & Data field of Tail --> '{list.Tail.Value}'");
            else Console.WriteLine($"Data field of Head --> '{list.Head}' & Data field of Tail --> '{list.Tail}'");
            Console.WriteLine();
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


    class LinkedList<T>
    {
        public LinkedListNode<T> Head { get;  set; }
        public LinkedListNode<T> Tail { get;  set; }
        public int Count { get; set; }
        public void RemoveFirst()
        {
            if (Count > 0)
            {
                // Step -1: Point the head of the Linked List to the next node of the Head
                Head = Head.Next;

                if (Count > 1)
                {
                    // Step – 2a: Assign the Next node of the To-Be removed node to Null 
                    Head.Previous.Next = null;

                    // Step -2b: Assign the previous node of the Head to Null
                    Head.Previous = null;
                }
                else Tail = null;
                Count--;
            }
        }

        public void RemoveLast()
        {
            if (Count > 0)
            {

                // Step -1a: Point the tail of the Linked List to previous node of the Tail
                Tail = Tail.Previous;

                if (Count > 1)
                {
                    // Step - 1b: Assign Previous of node to be removed to null
                    Tail.Next.Previous = null;

                    // Step - 2: Assign next node of Tail as null
                    Tail.Next = null;
                }
                else Head = null;

                Count--;
            }
                
        }
    }
}
