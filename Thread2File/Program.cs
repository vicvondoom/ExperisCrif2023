namespace Thread2File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Oggetto usato per bloccare richieste in contemporanea
            object locker = new object();

            Job job1 = new Job("Job 1", locker);
            Job job2 = new Job("Job 2", locker);

            Thread th1 = new Thread(job1.DoWork);
            Thread th2 = new Thread(job2.DoWork);

            th1.Start();
            th2.Start();

            th1.Join();
            th2.Join();
            Console.WriteLine("Finito!");

        }
    }
}