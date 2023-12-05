using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace GoofyThreads
{
    class Program
    {
        private static List<int> numbers;

        static void Main()
        {
            Console.WriteLine("");
            Console.WriteLine("");

            numbers = new List<int> {1,2,3,4};

            DateTime dt = DateTime.Now;
            
            Thread thread1 = new Thread(MultiplyBy5);
            Thread thread2 = new Thread(MultiplyBy5);
            Thread thread3 = new Thread(MultiplyBy5);

            thread1.Start(1);
            thread2.Start(2);
            thread3.Start(3);

            MultiplyBy5(0);

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.WriteLine("Time spent on multithread for operation: " + (DateTime.Now - dt).ToString());
            Console.WriteLine("List: {" + numbers[0] + ","
                                        + numbers[1] + ","
                                        + numbers[2] + ","+
                                          numbers[3] + "}"); 
            
            Console.WriteLine("");

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            numbers = new List<int> {1,2,3,4};

            dt = DateTime.Now;

            for(int i = 0; i < numbers.Count; i++)
            {
                MultiplyBy5(i);
            }

            Console.WriteLine("Time spent on single thread for operation (using method): " + (DateTime.Now - dt).ToString());
            Console.WriteLine("List: {" + numbers[0] + ","
                                        + numbers[1] + ","
                                        + numbers[2] + ","+
                                          numbers[3] + "}");

            Console.WriteLine("");

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            numbers = new List<int> {1,2,3,4};

            dt = DateTime.Now;

            MultiplyBy5(0);
            MultiplyBy5(1);
            MultiplyBy5(2);
            MultiplyBy5(3);

            Console.WriteLine("Time spent on single thread manual operation (using method): " + (DateTime.Now - dt).ToString());
            Console.WriteLine("List: {" + numbers[0] + ","
                                        + numbers[1] + ","
                                        + numbers[2] + ","+
                                          numbers[3] + "}"); 

            Console.WriteLine("");

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            numbers = new List<int> {1,2,3,4};

            dt = DateTime.Now;

            for(int i = 0; i < numbers.Count; i++)
            {
                numbers[i] *= 5;
            }

            Console.WriteLine("Time spent on single thread for operation (without method): " + (DateTime.Now - dt).ToString());
            Console.WriteLine("List: {" + numbers[0] + ","
                                        + numbers[1] + ","
                                        + numbers[2] + ","+
                                          numbers[3] + "}");

            Console.WriteLine("");
            
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            numbers = new List<int> {1,2,3,4};

            dt = DateTime.Now;

            numbers[0] *= 5;
            numbers[1] *= 5;
            numbers[2] *= 5;
            numbers[3] *= 5;

            Console.WriteLine("Time spent on single thread manual operation (without method): " + (DateTime.Now - dt).ToString());
            Console.WriteLine("List: {" + numbers[0] + ","
                                        + numbers[1] + ","
                                        + numbers[2] + ","+
                                          numbers[3] + "}");       
        }

        private static void MultiplyBy5(object index)
        {
            numbers[(int)index] *= 5;  
        }
    }
}
