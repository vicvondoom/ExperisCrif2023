namespace AsyncAwait3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Come stoppo dei task?
            // Devo usare un cancellation token
            // Me lo procuro da qui:
            CancellationTokenSource cts = new CancellationTokenSource();
            var token = cts.Token;


            Task t1 = Task.Factory.StartNew(
                    ()          // funziona anonima
                    =>          // 'che diventa'
                    DoWork("Job 1"),
                    token
                );
            Task t2 = Task.Factory.StartNew(() => DoWork("Job 2"), token);

            Task.WhenAll(t1, t2); // Non metto 'await' (il Main non lo è!), voglio far proseguire il Main

            // Dico all'utente che se preme un tasto qualsiasi, i task verranno stoppati
            Console.WriteLine("Premi un tasto per stoppare i task...");
            Console.ReadKey();

            // Se ho premuto un tasto, il Main continua...
            // per stoppare i task:
            cts.Cancel();

            Console.WriteLine("Fine!");

        }

        static void DoWork(string nome)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(nome + ": " + i);
                Task.Delay(500).Wait(); // Non sono in un metodo asincrono, uso la Wait()!
                // Se no posso usare Thread.Sleep!
            }
        }
    }
}