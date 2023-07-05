namespace PatternDecorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Devo preparare un software per gestire i componenti di un computer
            // quindi macchina base, ram, monitor vari, dischi
            // se usassi ereditarietà fra le varie componenti otterrei una gerarchi di classi che esplode!
            // Quindi uso il pattern decorator!
            // Creo la macchina base, il pc (senza ram, disco e monitor)
            // Tutti gli altri componenti diventano decorazioni della macchina base.

            // Ipotizzo che arriva un cliente a cui chiedo che pezzi vuole comprare

            Computer pc = new Computer();

            // Scelta RAM
            Console.Write("Vuoi 8Gb RAM (a) oppure 16Gb RAM (b) ?");
            string ris = Console.ReadLine();
            if (ris.StartsWith("a"))
                pc = new Ram8Gb(pc);
            else
                pc = new Ram16Gb(pc);

            // Scelta Hard Disk
            Console.Write("Vuoi Hard Disk 500Gb (a) oppure SSD 500Gb (b) ?");
            ris = Console.ReadLine();
            if (ris.StartsWith("a"))
                pc = new HardDisk500Gb(pc);
            else
                pc = new SSD500Gb(pc);

            // Scelta Monitor
            Console.Write("Vuoi monitor classico (a) oppure Monitor HD (b) oppure Monitor 4K (c) ?");
            ris = Console.ReadLine();
            if (ris.StartsWith("a"))
                pc = new Monitor(pc);
            else if (ris.StartsWith("b"))
                pc = new MonitorHD(pc);
            else
                pc = new Monitor4K(pc);

            Console.WriteLine();
            Console.WriteLine("Configurazione finale:");
            Console.WriteLine(pc.Descrizione());
            Console.WriteLine("Prezzo: " + pc.Prezzo() + " euro.");
        }
    }
}