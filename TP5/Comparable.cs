using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MP_TP
{
    public interface Comparable
    {
        bool sosIgual(Comparable c);
        bool sosMenor(Comparable c);
        bool sosMayor(Comparable c);
    }

    public class Numero : Comparable
    {
        int numero;
        public Numero(int n) { numero = n; }
        public int getValor() { return numero; }
        public override string ToString() { return this.getValor().ToString(); }

        public bool sosIgual(Comparable c) { return this.getValor() == ((Numero)c).getValor(); }
        public bool sosMenor(Comparable c) { return this.getValor() < ((Numero)c).getValor(); }
        public bool sosMayor(Comparable c) { return this.getValor() > ((Numero)c).getValor(); }
    }
}
