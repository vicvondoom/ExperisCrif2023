namespace PatternSingleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Devo, per tutto un mio progetto, accedere a username e password
            // Se ho bisogno di Username e PAssword, uso la classe statica
            string username = ConfigStatic.Username;
            string password = ConfigStatic.Password;

            // Non va bene, innanzitutto ho i dati schiantati nel codice, se passo a 
            // produzione devo ricompilare..
            // Il peggio è che qualcuno potrebbe fare così:
            ConfigStatic.Password = "67890";
            // non ho controllo sui dati, non accedo più

            // Allora uso la ConfigFile
            ConfigFile cf = new ConfigFile();
            username = cf.Username;
            password = cf.Password;
            // ma anche qui, qualcuno può modificare il file di config e mi trovo comportamenti
            // del software inattesi


            // Allora uso un Singleton
            //SingletonConfig sc = new SingletonConfig(); // è privato il costruttore, non posso istanziarlo direttamente!
            SingletonConfig sc1 = SingletonConfig.Instance;
            username = sc1.Username;
            password = sc1.Password;


            // In altro punto del codice cosa succede? Se mi cambiano il file?
            SingletonConfig sc2 = SingletonConfig.Instance;
            username = sc2.Username;
            password = sc2.Password;
            // Tutto a posto, finchè riavvio l'app e allora rilegge il file

        }
    }
}