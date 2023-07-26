namespace Thread2
{ 
    class Program
    {
        static void Main(string[] args)
        {
            //Thread thread = new Thread(new ThreadStart(Func));
            //thread.Start();
            //thread.Join();
            //Console.WriteLine("Main End");

            Thread thread1 = new Thread(new ThreadStart(Func1));
            thread1.Start();
            
            Console.WriteLine("Main Thread {0}", Thread.CurrentThread.GetHashCode());
            Console.WriteLine("Main End");
        }

        private static void Func1()
        {
            Console.WriteLine("Func1 Thread {0}", Thread.CurrentThread.GetHashCode());
            Thread thread2 = new Thread(new ThreadStart(Func2));
            thread2.Start();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Console.WriteLine(i * 10);
                    Thread.Sleep(200);

                    if (i == 3)
                    {
                        Console.WriteLine("Func1 End");
                        Thread.CurrentThread.Interrupt();
                    }
                }
                catch
                {
                    break;
                }
            }
        }

        private static void Func2()
        {
            Console.WriteLine("Func2 Thread {0}", Thread.CurrentThread.GetHashCode());
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(200);
            }
            Console.WriteLine("Func2 End");
        }

        private static void Func()
        {
            //int i = 0;
            //while (true)
            for(int i = 0; i < 30; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(300);
            }
        }
    }
}