namespace EsercizioBanca
{
    internal class Program
    {
        delegate int Saldo();
        delegate bool Preleva(int soldi);
        delegate void Deposita(int soldi);

        static void Main(string[] args)
        {
            BancaITA bancaITA = new BancaITA();
            BankENG bankEng = new BankENG();

            // creo i delegati che, per ora, puntano alla banca italiana
            Saldo saldo = bancaITA.Saldo;
            Preleva preleva = bancaITA.Preleva;
            Deposita deposita = bancaITA.Deposita;

            int scelta = 0;
            while(scelta != 5)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Saldo");
                Console.WriteLine("2) Preleva");
                Console.WriteLine("3) Deposita");
                Console.WriteLine("4) Cambio conto");
                Console.WriteLine("5) Esci");

                scelta = Convert.ToInt32(Console.ReadLine());

                switch(scelta)
                {
                    case 1:
                        Console.WriteLine("Saldo: " + saldo() + " euro.");
                        break;
                    case 2:
                        Console.Write("Quanto vuoi prelevare: ");
                        int prelievo = Convert.ToInt32(Console.ReadLine());
                        if (preleva(prelievo))
                            Console.WriteLine("Prelievo effettuato con successo!");
                        else
                            Console.WriteLine("Fondi insufficenti...");
                        break;
                    case 3:
                        Console.Write("Quanto vuoi versare: ");
                        int versamento = Convert.ToInt32(Console.ReadLine());
                        deposita(versamento);
                        break;
                    case 4:
                        if(saldo == bancaITA.Saldo)
                        {
                            saldo = bankEng.Balance;
                            preleva = bankEng.PickUp;
                            deposita = bankEng.Deposit;
                            Console.WriteLine("Conto attuale: Bank ENG");
                        }
                        else
                        {
                            saldo = bancaITA.Saldo;
                            preleva = bancaITA.Preleva;
                            deposita = bancaITA.Deposita;
                            Console.WriteLine("Conto attuale: Banca ITA");
                        }
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}