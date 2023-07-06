namespace PatternObserver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Partita InterMilan = new Partita("Inter-Milan");

            // Creo due osservatori
            Osservatore raiUno = new Osservatore("Rai Uno");
            Osservatore La7 = new Osservatore("La7");

            InterMilan.addOsservatore(raiUno);
            InterMilan.addOsservatore(La7);

             
            Thread.Sleep(3000);
            InterMilan.Notifica("1-0");

            Thread.Sleep(5000);
            InterMilan.Notifica("1-1");

            Thread.Sleep(3000);
            InterMilan.Notifica("punizione per l'Inter");

            Thread.Sleep(3000);
            InterMilan.Notifica("2-1");

            // Sul più bello esce raiUno
            InterMilan.removeOsservatore(raiUno);
            InterMilan.addOsservatore(new Osservatore("Canale 5"));

            Thread.Sleep(3000);
            InterMilan.Notifica("2-2");

            Thread.Sleep(5000);
            InterMilan.Notifica("2-3");
        }
    }
}