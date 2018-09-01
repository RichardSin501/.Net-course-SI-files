using System;
using System.Collections;

namespace SI._02.SequentialCollections
{
    internal class Program
    {
        private static void RunQueueHandsOn()
        {
            var queue = new Queue();
            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");
            queue.Enqueue("Fourth");

            while (queue.Count > 0)
            {
                Console.WriteLine($"This string was dequeued: {queue.Dequeue()}");
            }
        }

        private static void RunStackHandsOn()
        {
            var stack = new Stack();
            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");
            stack.Push("Fourth");

            while (stack.Count > 0)
            {
                Console.WriteLine($"This string's just got popped: {stack.Pop()}");
            }
        }

        private static void Main()
        {
            RunQueueHandsOn();
            RunStackHandsOn();
        }
    }
}