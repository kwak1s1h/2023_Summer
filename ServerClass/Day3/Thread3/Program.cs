namespace Thread3
{
    class Program
    {
        static object obj = new object();

        static void Main(string[] args)
        {
            int num = 0;
            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    lock (obj)
                    {
                        num++;
                    }
                }
            });
            thread1.Start();
            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    lock(obj)
                    {
                        num++;
                    }
                }
            });
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine(num);
        }
    }
}