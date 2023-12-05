using System;
using System.Threading;
using System.Collections.Generic;

namespace GiantListThreading
{
    class Program
    {
        private static List<int> numbers;
        private static int divider;
        
        static void Main()
        {
            numbers = new List<int>();

            Console.Write("Please give a max number for the list: ");
            int maxNumber = int.Parse(Console.ReadLine());
            
            for(int i = 1; i <= maxNumber; i++)
            {
                numbers.Add(i);
            }

            List<int> savedList = new List<int>();
            foreach(int i in numbers)
            {
                savedList.Add(i);
            }

            Console.WriteLine("");
            Console.WriteLine("");

            DateTime dt = DateTime.Now;
            
            Thread thread1 = new Thread(MultipleCalculations);
            Thread thread2 = new Thread(MultipleCalculations);
            Thread thread3 = new Thread(MultipleCalculations);

            divider = numbers.Count/4;

            thread1.Start(divider);
            thread2.Start(divider*2);
            thread3.Start(divider*3);

            for(int i = divider*3; i < numbers.Count; i++)
                numbers[i] *= 5;

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.WriteLine("Time spent on multithread for operation: " + (DateTime.Now - dt).ToString());

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            foreach(int i in savedList)
            {
                numbers.Add(i);
            }

            dt = DateTime.Now;

            for(int i = 0; i < numbers.Count; i++)
            {
                numbers[i] *= 5;
                numbers[i] -= 5;
                numbers[i] *= 5;
            }

            Console.WriteLine("Time spent on single thread for operation: " + (DateTime.Now - dt).ToString());
        
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        }

        private static void MultipleCalculations(object givenSector)
        {
            int sector = (int)givenSector;

            for(int i = sector - divider; i < sector; i++)
            {
                numbers[i] *= 5;
                numbers[i] -= 5;
                numbers[i] *= 5;
            }
        }
    }
}
