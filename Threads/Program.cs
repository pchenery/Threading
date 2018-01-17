using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.ConcurrencyTest();
            Console.ReadLine();
        }
        private class DataStore { public int Value { get; set; } }

        private DataStore store1 = new DataStore();
        private DataStore store2 = new DataStore();

        public void ConcurrencyTest()
        {
            var thread1 = new Thread(IncrementTheValue);
            var thread2 = new Thread(IncrementTheValue);

            thread1.Start();
            Thread.Sleep(5);
            Console.WriteLine("Locking store2");
            lock (store2)
            {
                Console.WriteLine("Locked store2");
                Console.WriteLine("Locking store1");
                lock (store1)
                {
                    Console.WriteLine("Locked store1");
                }
                Console.WriteLine("Released store2");
            }
            Console.WriteLine("Released store2");
            //thread2.Start();

            //thread1.Join(); // Wait for the thread to finish executing
            //thread2.Join();

            Console.WriteLine($"Final value: {store1.Value}");
        }

        private void IncrementTheValue()
        {
            Console.WriteLine("Locking store1");
            lock (store1)
            {
                Console.WriteLine("Locked store1");
                Thread.Sleep(10);
                Console.WriteLine("Locking store2");
                lock (store2)
                {
                    Console.WriteLine("Locked store2");
                }
                Console.WriteLine("Released store2");
            }
            Console.WriteLine("Released store1");
            store1.Value++;
            store2.Value++;
        }
    }
}
