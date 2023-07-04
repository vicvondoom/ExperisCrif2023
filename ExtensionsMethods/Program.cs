using MieiMetodiEstensione;

namespace ExtensionsMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nome = "Davide";
            string nomeM = nome.ToMaiuscolo();

            // voglio un metodo ToMaiuscolo() nella classe string
            // vorrei poter estenderla, ma non posso!

            int numero = 5;
            int altro = numero.AggiungiTre();

            int numeroTotale = numero.AggiungiNumero(10);

        }
    }
}