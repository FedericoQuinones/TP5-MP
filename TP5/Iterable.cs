using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MP_TP
{
    public interface Iterador
    {
        void primero();
        void siguiente();
        bool fin();
        Comparable actual();
    }
    public class IteratorLista : Iterador {  //iterador para lista cola y conjunto
        private List<Comparable> lista;
        private int i;
        public IteratorLista(List<Comparable> l) { lista = l; i = 0; }
        public void primero() { i = 0; }
        public void siguiente() { i++; }
        public bool fin() { return i >= lista.Count; }
        public Comparable actual() { return lista[i]; }
    }
    public interface Iterable { Iterador crearIterador(); }

    public class IteratorDiccionario : Iterador {
        private List<Comparable> lista;
        private int i;
        public IteratorDiccionario(List<Comparable> l) { lista = l; i = 0; }
        public void primero() { i = 0; }
        public void siguiente() { i++; }
        public bool fin() { return i >= lista.Count; }
        public Comparable actual() { return ((ClaveValor)lista[i]).getValor(); }
    }
}
