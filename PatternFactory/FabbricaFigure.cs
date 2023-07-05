using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFactory
{
    public enum TipoFigura { Cerchio, Quadrato, Rettangolo }
    internal class FabbricaFigure
    {
        private int _id = 1;

        public IFigura getFigura(TipoFigura tipo)
        {
            switch(tipo)
            {
                case TipoFigura.Cerchio:
                    return new Cerchio(this._id++);
                    break;
                case TipoFigura.Quadrato:
                    return new Quadrato(this._id++);
                    break;
                case TipoFigura.Rettangolo:
                    return new Rettangolo(this._id++);
                    break;
                default:
                    return null;
            }
        }
    }
}
