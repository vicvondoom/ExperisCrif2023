using PatternStrategy.algoritmi;
using PatternStrategy.mezzi;

namespace PatternStrategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car bmw = new Car("Bmw X3");
            Helicopter polizia = new Helicopter("Elicottero Polizia");
            Jet airforceone = new Jet("Air Force One");

            bmw.Go();
            polizia.Go();
            airforceone.Go();

            // Posso modificare il funzionamento di un oggetto a run-time
            Car batmobile = new Car("BatMobile");
            batmobile.Go();
            batmobile.setAlgorithm(new GoByFlying());
            batmobile.Go();

            batmobile.setAlgorithm(new GoByWater());
            batmobile.Go();
        }
    }
}