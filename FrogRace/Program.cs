using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace FrogRace
{
    class Program
    {
        private static Queue<int> finishOrder;
        private static object threadLock;

        static void Main()
        {
            finishOrder = new Queue<int>();
            
            HashSet<Thread> threadSet = new HashSet<Thread>();

            Thread thread1 = new Thread(FrogJump);
            threadSet.Add(thread1);
            Thread thread2 = new Thread(FrogJump);
            threadSet.Add(thread2);
            Thread thread3 = new Thread(FrogJump);
            threadSet.Add(thread3);

            thread1.Name = "T_One";
            thread2.Name = "T_Two";
            thread3.Name = "T_Three";

            threadLock = new object();

            thread1.Start(1);
            thread2.Start(2);
            thread3.Start(3);

            foreach(Thread thread in threadSet)
            {
                thread.Join();
            }

            Console.WriteLine("");
            Console.WriteLine("The race has ended!");
            Console.WriteLine("First Place is Frog #" + finishOrder.Dequeue());
            Console.WriteLine("Second Place is Frog #" + finishOrder.Dequeue());
            Console.WriteLine("Third Place is Frog #" + finishOrder.Dequeue());
            
        }

        private static void FrogJump(object frogNumber)
        {
            Random random = new Random((int)frogNumber);

            for(int x = 0; x < 10; x++)
            {
                Thread.Sleep(random.Next(0,1));
                Console.WriteLine("Frog " + frogNumber + " has completed jump #" + x + "!");
            }
            Console.WriteLine("Frog " + frogNumber + " has finished jumping!");

            lock(threadLock)
            {
                finishOrder.Enqueue((int)frogNumber);
            }
        }
    }
}
