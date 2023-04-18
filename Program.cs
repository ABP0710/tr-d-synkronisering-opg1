namespace tråd_synkronisering_opg
{
    internal class Program
    {
        static int count = 0;
        static object _lock = new object();

        static void Main(string[] args)
        {
            Thread p = new Thread(Plus);
            p.Name = "Go up by 2!";
            p.Start();

            Thread m = new Thread(Minus);
            m.Name = "Go down by 1";
            m.Start();

            p.Join();
            m.Join();
        }

        static void Plus()
        {
            while (true)
            {
                Monitor.Enter(_lock);
                try
                {
                    count += 2;
                    Console.WriteLine(count);
                    Thread.Sleep(1000);
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }
        }

        static void Minus()
        {
            while (true)
            {
                Monitor.Enter(_lock);
                try
                {
                    count -= 1;
                    Console.WriteLine(count);
                    Thread.Sleep(1000);
                }
                finally
                { 
                    Monitor.Exit(_lock); 
                }
            }
        }
    }
}