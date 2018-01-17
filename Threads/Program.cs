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

        private DataStore store = new DataStore();

        public void ConcurrencyTest()
        {
            var thread1 = new Thread(IncrementTheValue);
            var thread2 = new Thread(IncrementTheValue);

            thread1.Start();
            thread2.Start();

            thread1.Join(); // Wait for the thread to finish executing
            thread2.Join();

            Console.WriteLine($"Final value: {store.Value}");
        }

        private void IncrementTheValue()
        {
            store.Value++;
        }
    }
}
