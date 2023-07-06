namespace Generics1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Array
            int[] numbers = new int[10];

            // Collection
            List<string> nomi;
            nomi = new List<string>();

            List<int> numeri = new List<int>();
            numeri.Add(1);
            Dictionary<int, string> dic = new Dictionary<int, string>();

            // i generici usano le parentesi angolari '<' e '>' per definire
            // che tipo usano al loro interno
            // il parametro, tra le angolari, è un tipo di dato!

            //Bidone<int> intero = new Bidone<int>(13);
            //Console.WriteLine("Contenuto: " + intero.Contenuto);

            //Bidone<string> parola = new Bidone<string>("Ciao!");
            //Console.WriteLine("Contenuto: " + parola.Contenuto);

            int[] numeri2 = { 1, 2, 3, 4, 5 };
            Bidone<int[]> bidonenumeri = new Bidone<int[]>(numeri2);

            List<int> numeriList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Bidone<List<int>> bidoneLista = new Bidone<List<int>>(numeriList);

        }
    }
}