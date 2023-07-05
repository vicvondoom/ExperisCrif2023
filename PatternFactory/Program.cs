namespace PatternFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // FACTORY
            // Problema: devo istanziare delle classi che rappresentano delle figure geometriche
            // ma ogni classe deve essere inizializzata con un valore incrementale
            // sulla 'new' dovrei potergli passare questo valore, ma dove tengo conto di quanto vale?

            // Fare come sotto non va bene, non so mai che id dare....
            //Cerchio c1 = new Cerchio(1);
            //Rettangolo r1 = new Rettangolo(2);

            // Allora uso la factory
            FabbricaFigure fab = new FabbricaFigure();
            Cerchio c1 = (Cerchio)fab.getFigura(TipoFigura.Cerchio);
            Rettangolo ret1 = (Rettangolo)fab.getFigura(TipoFigura.Rettangolo);

            // scrivere IFigura quad1 vuol dire che la variabile quad1 può
            // 'ospitare' qualunque oggetto che implementi l'interfaccia IFigura
            IFigura quad1;
            quad1 = fab.getFigura(TipoFigura.Quadrato);
            Quadrato quad2 = (Quadrato)fab.getFigura(TipoFigura.Quadrato);

            //quad1.disegna();
            //quad2.disegna();

            // C'è bisogno di raccogliere tutti questi oggetti
            List<Cerchio> cerchi = new List<Cerchio>();
            List<Quadrato> quadrati = new List<Quadrato>();
            // NO!!
            // Posso creare una List di tipo interfaccia!
            List<IFigura> figure = new List<IFigura>();
            figure.Add(c1);
            figure.Add(ret1);
            figure.Add(quad1);
            figure.Add(quad2);

            foreach(var figura in figure)
            {
                figura.disegna();
            }

        }
    }
}