using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MP_TP
{
    public interface EstrategiaDeComparacion
    {
        bool sosIgual(Comparable a, Comparable c);
        bool sosMenor(Comparable a, Comparable c);
        bool sosMayor(Comparable a, Comparable c);
    }

    public interface EstrategiaDeComparacionClaves
    {
        bool sosIgual(ClaveValor a, ClaveValor b);
        bool sosMenor(ClaveValor a, ClaveValor b);
        bool sosMayor(ClaveValor a, ClaveValor b);
    }

    public class EstrategiaPorLegajo : EstrategiaDeComparacion
    {
        public bool sosIgual(Comparable a, Comparable c) { return ((Alumno)a).getLegajo().sosIgual(((Alumno)c).getLegajo()); }
        public bool sosMenor(Comparable a, Comparable c) { return ((Alumno)a).getLegajo().sosMayor(((Alumno)c).getLegajo()); }
        public bool sosMayor(Comparable a, Comparable c) { return ((Alumno)a).getLegajo().sosMenor(((Alumno)c).getLegajo()); }
    }

    public class EstrategiaPorNombre : EstrategiaDeComparacion
    {
        public bool sosIgual(Comparable a, Comparable c) { return ((Persona)a).getNombre().Equals(((Persona)c).getNombre()); }
        public bool sosMenor(Comparable a, Comparable c)
        {
            if (((Persona)a).getNombre().CompareTo(((Persona)c).getNombre()) == 1)
                return true;
            else
                return false;
        }
        public bool sosMayor(Comparable a, Comparable c)
        {
            if (((Persona)a).getNombre().CompareTo(((Persona)c).getNombre()) == 0)
                return true;
            else
                return false;
        }
    }

    public class EstrategiaPorDNI : EstrategiaDeComparacion
    {
        public bool sosIgual(Comparable a, Comparable c) { return ((Persona)a).getDNI().sosIgual(((Persona)c).getDNI()); }
        public bool sosMenor(Comparable a, Comparable c) { return ((Persona)a).getDNI().sosMayor(((Persona)c).getDNI()); }
        public bool sosMayor(Comparable a, Comparable c) { return ((Persona)a).getDNI().sosMenor(((Persona)c).getDNI()); }
    }

    public class EstrategiaPorPromedio : EstrategiaDeComparacion
    {
        public bool sosIgual(Comparable a, Comparable c) { return ((Alumno)a).getPromedio().sosIgual(((Alumno)c).getPromedio()); }
        public bool sosMenor(Comparable a, Comparable c) { return ((Alumno)a).getPromedio().sosMayor(((Alumno)c).getPromedio()); }
        public bool sosMayor(Comparable a, Comparable c) { return ((Alumno)a).getPromedio().sosMenor(((Alumno)c).getPromedio()); }
    }

    public class EstrategiaPorValor : EstrategiaDeComparacionClaves
    {
        public bool sosIgual(ClaveValor a, ClaveValor b) { return a.getValor().sosIgual(b.getValor()); }
        public bool sosMenor(ClaveValor a, ClaveValor b) { return a.getValor().sosMayor(b.getValor()); }
        public bool sosMayor(ClaveValor a, ClaveValor b) { return a.getValor().sosMenor(b.getValor()); }
    }

    public class EstrategiaPorClave : EstrategiaDeComparacionClaves
    {
        public bool sosIgual(ClaveValor a, ClaveValor b) { return a.valorClave().sosIgual(b.valorClave()); }
        public bool sosMenor(ClaveValor a, ClaveValor b) { return a.valorClave().sosMayor(b.valorClave()); }
        public bool sosMayor(ClaveValor a, ClaveValor b) { return a.valorClave().sosMenor(b.valorClave()); }
    }
    public class EstrategiaPorBonus : EstrategiaDeComparacion
    {
        public bool sosIgual(Comparable a, Comparable b) { return ((Vendedor)a).getBonus().sosIgual(((Vendedor)b).getBonus()); }
        public bool sosMenor(Comparable a, Comparable b) { return ((Vendedor)a).getBonus().sosMayor(((Vendedor)b).getBonus()); }
        public bool sosMayor(Comparable a, Comparable b) { return ((Vendedor)a).getBonus().sosMenor(((Vendedor)b).getBonus()); }
    }
}
