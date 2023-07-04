namespace DelegatiNET
{
    internal class Program
    {
        delegate int Calcolatore(int a, int b);

        // Mi creo "sul momento" una funzione di utilità
        // FUNC
        public static int Aggiungi(int a, int b) => a + b;
        public static int Aggiungi2(int a, int b, int c) => a + b + c;

        public static string ConvertToString(int a) => a.ToString();

        // ACTION
        public static void ConsolePrint(string messaggio)
        {
            Console.WriteLine(messaggio);
        }

        // PREDICATE
        public static bool IsUpper(string parola)
        {
            return parola.Equals(parola.ToUpper());
        }

        static void Main(string[] args)
        {
            Calcolatore sum = Aggiungi;
            int res = sum(5, 6);

            // FUNC, è un delegato che esiste in NET, non devo dichiarlo
            // si aspetta fino a 16 parametri in ingresso, l'ultimo è di uscita
            Func<int, int, int> add = Aggiungi;
            res = add(4, 5);
            // mi "risparmio" di dichiarare un delegato apposta!

            Func<int, int, int, int> add2 = Aggiungi2;
            res = add2(3, 4, 5);

            // Uso Func sulla ConvertToString
            Func<int, string> cts = ConvertToString;
            string valore = cts(123);

            // Posso dichiararle con delegato anonimo, cioè definisco il metodo direttamente qui sotto
            // Questi due modi non hanno bisogno della "Aggiungi" dichiarata in alto!
            Func<int, int, int> addDelAnon = delegate (int a, int b)
            {
                return a + b;
            };
            res = addDelAnon(3, 4);

            // Posso dichiararle anche con una lambda expression
            Func<int, int, int> addLambdaExp = (int a, int b) =>
            {
                return a + b;
            };

            // ACTION, non ha parametri di uscita, solo fino a 16 in ingresso...
            Action<string> print = ConsolePrint;
            print("Hello!");
            // La dichiaro col delegato anonimo
            Action<string> printDelAnon = delegate (string msg)
            {
                Console.WriteLine(msg);
            };
            // La dichiaro con una lambda expression
            Action<string> printLambdaExp = (string msg) =>
            {
                Console.WriteLine(msg);
            };

            // PREDICATE, accetta un parametro in ingresso, un boolean in uscita
            Predicate<string> is_upper = IsUpper;
            Console.WriteLine(is_upper("Davide"));
            Console.WriteLine(is_upper("CIAO"));

            // La dichiaro con delegato anonimo
            Predicate<string> is_upper2 = delegate (string parola)
            {
                return parola.Equals(parola.ToUpper());
            };
            // La dichiaro con lambda expression
            Predicate<string> is_upper3 = (string parola) =>
            {
                return parola.Equals(parola.ToUpper());
            };
        }
    }
}