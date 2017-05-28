using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            clsObjectCollectionAdapter objectAdapter = new clsObjectCollectionAdapter();
            objectAdapter.Add("Pankaj");

            clsClassCollectionAdapter classAdapter = new clsClassCollectionAdapter();
            classAdapter.Add("Manish");

            Bread bread = new Bread();
            Console.WriteLine(bread.PrepareOrder());
            Console.WriteLine(bread.CalculateCost());
            Console.ReadKey();

            //Bread with Chicken
            OrderChicken orderBreadWithChicken = new OrderChicken(new Bread());
            Console.WriteLine(orderBreadWithChicken.PrepareOrder());
            Console.WriteLine(orderBreadWithChicken.CalculateCost());
            Console.ReadKey();


            //Bread with Chicken and ColdDrink
            OrderDrink orderBreadWithChickenAndDrink = new OrderDrink(new OrderChicken(new Bread()));
            Console.WriteLine(orderBreadWithChickenAndDrink.PrepareOrder());
            Console.WriteLine(orderBreadWithChickenAndDrink.CalculateCost());
            Console.ReadKey();

            I1 i1 = new Test();
            i1.Add();
            I2 i2 = new Test();
            i2.Add();

            //Function1();
            //Function2();

            //Create background thread, this thread will exit if the main thread exit.
            Thread thread3 = new Thread(Function3);
            thread3.IsBackground = true;
            thread3.Start();

            //create differe forground thread, these threads continue even if the main application exit.
            Thread thread1 = new Thread(Function1);
            Thread thread2 = new Thread(Function2);
            thread1.Start();
            thread2.Start();


            //Method();

            Console.WriteLine("Main Thread");
            //Console.ReadLine();
        }
        public static async void Method()
        {
            await Task.Run(new Action(LongTask));
            Console.WriteLine("New Thread");
        }
        public static void LongTask()
        {
            Thread.Sleep(10000);
        }

        public static void Function1()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Function 1 Thread :" + i);
                Thread.Sleep(1000);
            }
        }
        public static void Function2()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Function 2 Thread :" + i);
                Thread.Sleep(1000);
            }
        }

        public static void Function3()
        {
            Console.WriteLine("Function 3 Thread sarted");
            Console.ReadLine();
            Console.WriteLine("Function 3 ends");
        }
    }
}
