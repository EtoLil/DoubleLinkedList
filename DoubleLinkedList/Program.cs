using System;
using System.Collections;
using System.Collections.Generic;


namespace DoubleLinkedList
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; internal set; }
        public Node<T> Previous { get; internal set; }

        public Node(T data)
        {
            this.Data = data;
        }

    }

    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }


        #region Method Contains (return "true" if the list contains an item)

        public bool Contains(T item)
        {
            Node<T> data = head;

            while (data != null)
            {
                if (data.Data.Equals(item))
                {
                    return true;
                }
                data = data.Next;
            }
            return false;
        }


        #endregion
        #region Method GetEnumerator (method get a numerator for the collection and return an instance of the class IEnumerator<T>)

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        #endregion
        #region Method Clear (clear the list)

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        #endregion
        #region  Method CopyTo (method copies the contents of the list into an array)

        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> current = head;

            while (current != null)
            {
                array[arrayIndex] = current.Data;

                current = current.Next;
                arrayIndex++;

            }
        }

        #endregion
        #region Method isEmpty (return "true" if list size equals 0)

        public bool isEmpty()
        {
            if (Count == 0)
            {
                return true;
            }

            return false;
        }

        #endregion
        #region Method AddAfter(add item to the list after define index)

        public bool AddAfter(T item,int index)
        {
            if (Count<index)
            {
                return false;
            }

            Node<T> node = new Node<T>(item);
            Node<T> current = head;
            int i = 0; 


            while (current!=null&&i!=index)
            {
                i++;
                current = current.Next;
            }

            if (current.Next==null)
            {
                node.Previous = current;
                current.Next = node;
                tail = node;
            }
            else
            {
                node.Previous = current;
                node.Next = current.Next;
                current.Next.Previous = node;
                current.Next = node;
                
            }
            Count++;
            return true;

        }

        #endregion
        #region Method AddFirst (add new item to the top of the list)

        public void AddFirst(T item)
        {
            Node<T> node = new Node<T>(item);
            Node<T> temp = head;
            node.Next = temp;
            head = node;

            if (Count == 0)
            {
                tail = head;
            }
            else
            {
                temp.Previous = node;
            }
            Count++;
        }

        #endregion
        #region Method AddLast (add new item to the end of the list)

        public void AddLast(T item)
        {
            Node<T> node = new Node<T>(item);

            if (Count == 0)
            {
                head = node;
            }
            else
            {
                tail.Next=node;
                node.Previous = tail;
            }
            tail = node;
            Count++;
        }

        #endregion
        #region Method Remove (remove item and return true if item contains the list)
        public bool Remove(T item)
        {
            Node<T> current = head;


            while (current!=null)
            {
                if (current.Data.Equals(item))
                {
                    break;
                }
                current = current.Next;
            }

            if (current!=null)
            {
                if (current.Next != null) //if node not last
                {
                    current.Next.Previous = current.Previous;
                }
                else // if node last, change tail
                {
                    tail = current.Previous;
                }
                if (current.Previous != null) // if node not first
                {
                    current.Previous.Next = current.Next;
                }
                else // if node first, change head
                {
                    head = current.Next;
                }
                Count--;
                return true;
            }

            return false;
        }


        #endregion
        #region Method RemoveFirst (remove first item from the list)

        public void RemoveFirst()
        {
            if (Count!=0) {
                if (head.Next == null)
                {
                    head = null;
                    tail = null;
                    Count = 0;
                }
                else
                {
                    head = head.Next;
                    head.Previous = null;
                    Count--;
                }
            }
        }

        #endregion
        #region Method RemoveLast (remove last item from the list)

        public void RemoveLast()
        {
            if (Count!=0)
            {
                if (head.Next == null)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    tail = tail.Previous;
                    tail.Next=null;
                    
                    
                }
                Count--;
            }


        }

        #endregion

    }


    class Program
    {

        public static void Display(string nameMethod, LinkedList<int> linkedList)
        {
            Console.WriteLine(nameMethod);
            if (!linkedList.isEmpty())
            {
                foreach (int item in linkedList)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("List is empty!");
                Console.WriteLine();
                Console.WriteLine();
            }

        }
        public static void Display(string nameMethod, int[] mas)
        {
            Console.WriteLine(nameMethod);
            foreach (int item in mas)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }



        static void Main(string[] args)
        {
            LinkedList<int> linkedList=new LinkedList<int>();

            #region Add item

            linkedList.AddFirst(2);
            linkedList.AddFirst(4);
            linkedList.AddLast(7);
            linkedList.AddFirst(6);
            linkedList.AddLast(1);

            Display("Add", linkedList);

            #endregion

            #region AddAfter

            linkedList.AddAfter(47, 3);
            Display("Add item after index 3",linkedList);


            #endregion

            #region RemoveFirst

            linkedList.RemoveFirst();
            Display("RemoveFirs", linkedList);

            #endregion

            #region RemoveLast

            linkedList.RemoveLast();
            Display("RemoveLast",linkedList);

            #endregion

            #region Remove

            linkedList.Remove(7);
            Display("Remove item 7", linkedList);

            #endregion

            #region Clear

            linkedList.Clear();
            Display("Clear", linkedList);

            #endregion

            Console.ReadKey();
        }
    }
}
