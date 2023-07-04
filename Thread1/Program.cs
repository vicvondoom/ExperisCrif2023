namespace Thread1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Preparo il generatore dei numeri casuali
            Random rnd = new Random(DateTime.Now.Millisecond);

            //int casuale = rnd.Next(300, 800);

            Job job1 = new Job("Job 1", rnd);
            Job job2 = new Job("Job 2", rnd);

            // Aggancio gli eventi ai jobs
            job1.OnJob += EventoOnJob;
            job1.EndJob += EventoEndJob;
            job2.OnJob += EventoOnJob;
            job2.EndJob += EventoEndJob;
            // Lancio i job in dei thread
            // Al costruttore passo la funzione
            Thread th1 = new Thread(job1.DoWork);
            Thread th2 = new Thread(job2.DoWork);

            
            // non li lancio più in sincrono...!
            //job1.DoWork();
            //job2.DoWork();
            DateTime inizio = DateTime.Now;
            Console.WriteLine($"Start: " + inizio.ToString("HH:mm:ss.fff"));
            th1.Start();
            th2.Start();

            //Dico al Main di aspettare fino a che i miei thread finiscono
            th1.Join();
            th2.Join();

            // Grazie alle chiamate Join sopra, il Main aspetta prima di continuare col suo codice
            DateTime fine = DateTime.Now;
            Console.WriteLine($"Fine: " + fine.ToString("HH:mm:ss.fff"));

            // Il codice del Main prosegue......
            Console.WriteLine("Fine del main!");
        }

        static void EventoOnJob(string messaggio)
        {
            Console.WriteLine(messaggio);
        }

        static void EventoEndJob(string messaggio)
        {
            Console.WriteLine("Finito: " + messaggio);
        }
    }
}