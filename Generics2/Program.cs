namespace Generics2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Acqua h2o = new Acqua();
            Console.WriteLine(h2o);

            Vino vino = new Vino();
            Console.WriteLine(vino);

            // Creo una bottiglia di vino
            Bottiglia<Vino> chianti = new Bottiglia<Vino>(vino);
            Console.WriteLine(chianti);

            // Creo una bottiglia di acqua
            Bottiglia<Acqua> perrier = new Bottiglia<Acqua>(h2o);
            Console.WriteLine(perrier);

            Bevitore gino = new Bevitore("Gino");
            Console.WriteLine( gino.Beve<Vino>(chianti));
            Console.WriteLine(gino.Beve<Acqua>(perrier));

            //Creo una bottiglia di birra
            Bottiglia<Birra> bud = new Bottiglia<Birra>(new Birra());
            Console.WriteLine(gino.Beve<Birra>(bud));

            // Vincolando all'interfaccia IBevanda i liquidi, funziona!
            //Bottiglia<string> boh = new Bottiglia<string>("Stringa");
            //Console.WriteLine(gino.Beve<string>(boh));

            Caraffa<Birra> caraffaBirra = new Caraffa<Birra>(new Birra());

            Console.WriteLine(gino.Beve<Birra>(caraffaBirra));




        }
    }
}