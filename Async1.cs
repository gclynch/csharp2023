// demo of async and await C# 5 (TAP task-based asychronous pattern)
// async: an asynchronous method which runs synchronously until first await at which point it suspends
// and returns to its caller to be continued, awaited task will complete later

// 1 thread, not parallel, but asynchronous, concurrent "tasks"

// a task returned represents ongoing work, use with both I/O and CPU bound code

using System;
using System.Threading.Tasks;

namespace AsynchronousProgrammingDemo
{
    class Coffee {}
    class Egg {}
    class Toast {}
    class Breakfast
    {
        
        private static Coffee PourCoffee()                      // synchronous
        {
            Console.WriteLine("pouring coffee");
            return new Coffee();
        }

        // async method that ultimatemly returns an Egg
        private static async Task<Egg> FryEgg()
        {
            Console.WriteLine("heating pan...");
            await Task.Delay(3000);
            Console.WriteLine("cracking egg");
            Console.WriteLine("cooking egg...");
            await Task.Delay(5000);
            Console.WriteLine("egg is ready");
            return new Egg();
        }

        private static void ApplyButter(Toast toast) => Console.WriteLine("Putting butter on toast");

        private static async Task<Toast> MakeToast(int slices)
        {
            for (int i=0; i < slices; i++)
            {
                Console.WriteLine("putting slice of bread in toaster");
            }
            Console.WriteLine("starting toasting...");
            await Task.Delay(3000);
            Console.WriteLine("removing toast form toaster");
            return new Toast();
        }

 

        static async Task Main()
        {
            // 1 cook 1 thread so not parallel

            Coffee coffee = PourCoffee();                       // synchronous task
            Console.WriteLine("coffee is ready");

            Task<Egg> eggTask = FryEgg();                       // asynchonous task, doesn't block
            Task<Toast> toastTask = MakeToast(2);               // 2 slices 

            Egg egg = await eggTask;
            Toast toast = await toastTask;
            ApplyButter(toast);
            Console.WriteLine("breakfast is ready");
        }
    }
}

