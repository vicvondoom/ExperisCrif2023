namespace IniezioneDipendenze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DocumentoWord doc = new DocumentoWord();

            Stampante epson = new Stampante();

            epson.Stampa(doc);

            DocumentoPDF pdf = new DocumentoPDF();

            epson.Stampa(pdf);

            //Non tocco più la classe Stampante
            DocumentoTXT txt = new DocumentoTXT();
            epson.Stampa(txt);
        }
    }
}