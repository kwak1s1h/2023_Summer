namespace Thread1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread thread = new Thread(new ThreadStart(Run));
            //thread.Start();

            Thread thread2 = new Thread(new ParameterizedThreadStart(Parameterized_Run2));
            thread2.Start(5);
        }

        private static void Parameterized_Run2(object? obj)
        {
            for(int i = 0; i < (int)obj; i++)
            {
                Console.WriteLine("Parameterized 쓰레드에서 호출 : {0}", i);
            }
        }

        private static void Run()
        {
            Console.WriteLine("스레드에서 호출");
        }
    }
}