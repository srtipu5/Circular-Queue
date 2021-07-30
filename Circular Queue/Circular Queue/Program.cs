using System;

namespace Circular_Queue
{
    class Program
    {
        public class CircularQueue<T>
        {
            public int Count { get; private set; }
            readonly int size = 10;
            int front;
            int rear;
            T[] arr;
            public CircularQueue()
            {
                arr = new T[size];
                Count = 0;
                front = rear = -1;
            }
            public void Enqueue(T value)
            {
                if(rear==-1 && front == -1)
                {
                    rear = 0;
                    front = 0;
                    arr[rear] = value;
                    Count++;
                    return;
                }
                else if(Count == size)
                {
                    Console.WriteLine("Queue Overflow.");
                    return;
                }
                else
                {
                    rear = (++rear) % size;
                    arr[rear] = value;
                    Count++;
                    return;
                }
            }
            public T Peek()
            {
                if (rear == -1 && front == -1)
                {
                    Console.WriteLine("Queue is empty.");
                    return default(T);
                }
                T temp = arr[front];
                return temp;
            }
            public T Dequeue()
            {
                if (rear == -1 && front == -1)
                {
                    Console.WriteLine("Queue is empty.");
                    return default(T);
                }
                else if(front == rear)
                {
                    T temp1 = arr[front];
                    front = rear = -1;
                    Count = 0;
                    return temp1;
                }
                else
                {
                    T temp = arr[front];
                    front = (++front)%size;
                    Count--;
                    return temp;
                }
            }
            public void Clear()
            {
                front = rear = -1;
                Count = 0;
            }
            public void Print()
            {
                if (front == -1 && rear == -1)
                {
                    Console.WriteLine("Queue is empty.");
                    return;
                }
                int i = front;
                while(i != rear)
                {
                    Console.WriteLine(arr[i]);
                    i = (++i % size);
                }
                Console.WriteLine(arr[rear]);
            }
            public bool IsEmpty()
            {
                if(Count == 0)
                {
                    return true;
                }
                return false;
            }
            public bool Contains(T value)
            {
                if(Count > 0)
                {
                    if (arr[rear].Equals(value))
                    {
                        return true;
                    }
                    else
                    {
                        int i = front;
                        while (i != rear)
                        {
                            if (arr[i].Equals(value))
                            {
                                return true;
                            }
                            i = (++i % size);
                        }
                    }
                }

                return false;
            }
        }
        static void Main(string[] args)
        {
            CircularQueue<int> circularQueue = new CircularQueue<int>();
            circularQueue.Enqueue(1);
            circularQueue.Enqueue(2);
            circularQueue.Enqueue(3);
            circularQueue.Enqueue(4);
            circularQueue.Enqueue(5);
            circularQueue.Dequeue();
            circularQueue.Dequeue();
            circularQueue.Dequeue();
            circularQueue.Enqueue(5);
            circularQueue.Enqueue(5);
            circularQueue.Enqueue(1);
            circularQueue.Enqueue(2);
            circularQueue.Print();
            Console.WriteLine($"Count item: {circularQueue.Count}");
            Console.WriteLine(circularQueue.Contains(1));
            Console.ReadKey();
        }
    }
}
