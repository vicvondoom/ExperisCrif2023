namespace AsyncAwait2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /*
            Sia la classe Thread che la classe Task vengono utilizzate per la programmazione parallela in C#.
            Un Thread è un implementazione di livello inferiore, mentre Task è di livello superiore.
            Ci vogliono risorse per un Task, mentre per un Thread no. Fornisce inoltre maggiore controllo rispetto
            alla classe Task.
            Un Thread dovrebbe essere preferito per qualsiasi operazione di lunga durata, mentre un Task
            dovrebbe essere preferito per qualsiasi altra operazione asincrona.
            */

            // Un altra maniera di lanciare Task in parallelo
            Task t1 = Task.Factory.StartNew(
                    ()          // funziona anonima
                    =>          // 'che diventa'
                    DoWork("Job 1") 
                );
            Task t2 = Task.Factory.StartNew(() => DoWork("Job 2"));

            // Gira sincrona, non è awaitable (perchè non lo è il Main!)
            //Task.WaitAll(t1, t2);

            // Se invece ho il Main async
            await Task.WhenAll(t1, t2);

            Console.WriteLine("Fine!");
        }


        // Metodo NON async
        static void DoWork(string nome)
        {
            for(int i=0; i<10; i++)
            {
                Console.WriteLine(nome + ": " + i);
                Task.Delay(250).Wait(); // Non sono in un metodo asincrono, uso la Wait()!
                // Se no posso usare Thread.Sleep!
            }
        }
    }
}