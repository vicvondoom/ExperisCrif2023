namespace AsyncAwait1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //int numero = Test();
            //Console.WriteLine(numero);

            //// questa riga qua sotto va in un thread
            //int res = await TestAsync(); // E' come se facessi, con un thread, Start() e poi Join()
            //Console.WriteLine("Chiamo un altra volta la TestAsync..");
            //res = await TestAsync();
            //Console.WriteLine("Risultato: " + res);
            //// Quindi vengono eseguite in thread diversi, ma una dopo l'altra!

            //// Cambio il modo di fare la chiamata:
            //Task<int> res2 = TestAsync();
            //// Qui il Main prosegue!
            //Console.WriteLine("Ma qui aspetta o no?");
            //Thread.Sleep(1000);
            //Console.WriteLine("Dopo un secondo...");
            //Thread.Sleep(500);
            //Console.WriteLine("Dopo mezzo secondo...");

            //// Ma questa qui sotto ASPETTA il risultato!!!
            //Console.WriteLine("Risultato: " + res2.Result);


            // Versione async/await della DoWork della classe Job
            Job job1 = new Job("Job 1");
            Job job2 = new Job("Job 2");

            //int res3 = await job1.DoWork(); //Questa, se la chiamo così, fà aspettare il resto delle righe sotto!
            //int res4 = await job2.DoWork();

            // Per farle lavorare in parallelo, devo fare così:
            var resJob1 = job1.DoWork();
            var resJob2 = job2.DoWork();
            // Ora son partite in parallelo!
            Console.WriteLine("Jobs partiti!!!");

            Console.WriteLine("Risultati:");
            Console.WriteLine("resJob1: " + resJob1.Result);
            Console.WriteLine("resJob2: " + resJob2.Result);

        }

        static int Test()
        {
            int i = 0;
            for(i= 0; i < 10; i++)
            {
                Console.WriteLine("Test, step " + i);
                Thread.Sleep(250);
            }
            return i;
        }

        // Metodo asincrono, cioè viene lanciato in un thread
        // non uso la classe Thread direttamente
        // 1) dichiaro il metodo 'async'
        // 2) il tipo di ritorno deve passare attraverso Task<> (se è void scrivo anche solo Task o void)
        static async Task<int> TestAsync()
        {
            int i = 0;
            for (i = 0; i < 10; i++)
            {
                Console.WriteLine("Test, step " + i);
                //Thread.Sleep(250);
                await Task.Delay(250);
            }
            return i;
        }
    }
}