using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MP_TP
{
    public interface IObservador { void actualizar(IObservado o); }
    public interface IObservado
    {
        void agregarObservador(IObservador o);
        void quitarObservador(IObservador o);
        void notificar();
    }
}
