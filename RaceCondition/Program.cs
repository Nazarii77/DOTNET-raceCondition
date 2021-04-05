using System;
using System.Threading;

namespace RaceCondition
{
    class Program
    {
        private static int sum;

        private static int sumResolved;
        static void Main(string[] args)
        {
            //create thread t1 using anonymous method
            Thread t1 = new Thread(() => {
                for (int i = 0; i < 10000000; i++)
                {
                    //increment sum value
                    sum++;
                }
            });

            //create thread t2 using anonymous method
            Thread t2 = new Thread(() => {
                for (int i = 0; i < 10000000; i++)
                {
                    //increment sum value
                    sum++;
                }
            });


            //start thread t1 and t2
            t1.Start();
            t2.Start();

            //wait for thread t1 and t2 to finish their execution
            t1.Join();
            t2.Join();

            //write final sum on screen
            Console.WriteLine("sum: " + sum);
            //Race Condition is a scenario where the outcome of the program is affected because of timing.
            //A race condition occurs when two or more threads can access shared data and they try to change it at the same time.

            Console.WriteLine("Press enter to terminate!");
            Console.ReadLine();





            //Resolving by Atomic update

            //create thread t3 using anonymous method
            Thread t3 = new Thread(() => {
                for (int i = 0; i < 10000000; i++)
                {
                    //use threading Interlocked class for atomic update
                    Interlocked.Increment(ref sumResolved);
                }
            });

            //create thread t4 using anonymous method
            Thread t4 = new Thread(() => {
                for (int i = 0; i < 10000000; i++)
                {
                    //use threading Interlocked class for atomic update
                    Interlocked.Increment(ref sumResolved);
                }
            });


            //start thread t1 and t2
            t3.Start();
            t4.Start();

            //wait for thread t1 and t2 to finish their execution
            t3.Join();
            t4.Join();

            //write final sum on screen
            Console.WriteLine("sum: " + sumResolved);

            Console.WriteLine("Press enter to terminate!");
            Console.ReadLine();
        }
    }
}
