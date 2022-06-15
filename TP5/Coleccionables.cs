using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MP_TP
{
    public interface Coleccionable : Iterable
    {
        int cuantos();
        Comparable minimo();
        Comparable maximo();
        void agregar(Comparable c);
        bool contiene(Comparable c);
    }

    public class Pila : Coleccionable,Ordenable
    {
        private List<Comparable> lista;
        public Pila() { lista = new List<Comparable>(); }

        //Command
        private OrdenEnAula1_OrdenInicio ordenInicio=null;
        private OrdenEnAula2_OrdenLlegaAlumno ordenAlumno=null;
        private OrdenEnAula1_OrdenAulaLlena ordenFin=null;
        public void setOrdenInicio(OrdenEnAula1_OrdenInicio o) { ordenInicio=o; }
        public void setOrdenLlegaAlumno(OrdenEnAula2_OrdenLlegaAlumno o) { ordenAlumno=o; }
        public void setOrdenAulaLlena(OrdenEnAula1_OrdenAulaLlena o) { ordenFin=o; }


        public void agregarPila(Comparable c) { 
            lista.Add(c);

            if (lista.Count == 1) { 
                if(ordenInicio!=null)
                    ordenInicio.ejecutar();
            }

            if (ordenAlumno != null) { 
                    ordenAlumno.ejecutar( (Alumno)c );
            }

            if (lista.Count >= 40) { 
                if(ordenFin!=null)
                    ordenFin.ejecutar();
            }
        }

        public Comparable quitarPila()
        {
            Comparable a = lista[lista.Count - 1];
            lista.RemoveAt(lista.Count - 1);
            return a;
        }

        public List<Comparable> getPila() { return lista; }

        public Comparable minimo()
        {
            Comparable x = lista[0];
            foreach (Comparable elem in lista)
            {
                if (elem.sosMenor(x))
                    x = elem;
            }
            return x;
        }
        public Comparable maximo()
        {
            Comparable x = lista[0];
            foreach (Comparable elem in lista)
            {
                if (elem.sosMayor(x))
                    x = elem;
            }
            return x;
        }
        public void agregar(Comparable c) { agregarPila(c); }

        public bool contiene(Comparable c)
        {
            for (int i = 0; i < this.cuantos(); i++)
            {
                if (lista[i].sosIgual(c))
                    return true;
            }
            return false;
        }

        public int cuantos() { return lista.Count; }

        public Iterador crearIterador() { return new IteratorLista(lista); }

        
    }

    public class Cola : Coleccionable, Iterable, Ordenable
    {

        private List<Comparable> cola;
        public Cola() { cola = new List<Comparable>(); }

        //Command
        private OrdenEnAula1_OrdenInicio ordenInicio=null;
        private OrdenEnAula2_OrdenLlegaAlumno ordenAlumno=null;
        private OrdenEnAula1_OrdenAulaLlena ordenFin=null;
        public void setOrdenInicio(OrdenEnAula1_OrdenInicio o) { ordenInicio=o; }
        public void setOrdenLlegaAlumno(OrdenEnAula2_OrdenLlegaAlumno o) { ordenAlumno=o; }
        public void setOrdenAulaLlena(OrdenEnAula1_OrdenAulaLlena o) { ordenFin=o; }

        public void agregarCola(Comparable c) {
            cola.Add(c);

            if (cola.Count == 1) { 
                if(ordenInicio!=null)
                    ordenInicio.ejecutar();
            }
            if (ordenAlumno != null) {
                    ordenAlumno.ejecutar( (Alumno)c );
            }
            if (cola.Count >= 40) { 
                if(ordenFin!=null)
                    ordenFin.ejecutar();
            }
        }
        public void agregar(Comparable c) { agregarCola(c); }

        public Comparable quitarCola() {
            Comparable a = cola[0];
            cola.RemoveAt(0);
            return a;
        }

        public Comparable minimo()
        {
            Comparable x = cola[0];
            foreach (Comparable elem in cola)
            {
                if (elem.sosMenor(x))
                    x = elem;
            }
            return x;
        }
        public Comparable maximo()
        {
            Comparable x = cola[0];
            foreach (Comparable elem in cola)
            {
                if (elem.sosMayor(x))
                    x = elem;
            }
            return x;
        }
        
        
        public int cuantos() { return cola.Count; }
        public bool contiene(Comparable c)
        {
            for (int i = 0; i < this.cuantos(); i++)
            {
                if (cola[i].sosIgual(c))
                    return true;
            }
            return false;
        }
        public Iterador crearIterador() { return new IteratorLista(cola); }
        public List<Comparable> getCola() { return cola; }
    }

    public class ColeccionMultiple : Coleccionable
    {
        private Pila pila;
        private Cola cola;
        public ColeccionMultiple(Pila p, Cola c)
        {
            pila = p;
            cola = c;
        }
        public int cuantos() { return (pila.cuantos() + cola.cuantos()); }

        public Comparable minimo()
        {
            Comparable a = cola.minimo();
            Comparable b = pila.minimo();
            if (a.sosMenor(b))
                return a;
            else
                return b;
        }

        public Comparable maximo()
        {
            Comparable a = cola.maximo();
            Comparable b = pila.maximo();
            if (a.sosMayor(b))
                return a;
            else
                return b;
        }

        public void agregar(Comparable c)
        {
            //no hace nada 
            Console.WriteLine("");
        }
        public bool contiene(Comparable c)
        {
            if (pila.contiene(c) || cola.contiene(c))
                return true;
            else
                return false;
        }

        public List<Comparable> unaLista() { 
        List<Comparable>p = this.pila.getPila();
            while( cola.cuantos() != 0)
                p.Add(cola.quitarCola());
            return p;
        }
        public Iterador crearIterador() { return new IteratorLista(unaLista()); }
    }

    public class Conjunto : Coleccionable
    {

        private List<Comparable> conjunto;
        public Conjunto() { conjunto = new List<Comparable>(); }

        //Command
        private OrdenEnAula1_OrdenInicio ordenInicio=null;
        private OrdenEnAula2_OrdenLlegaAlumno ordenAlumno=null;
        private OrdenEnAula1_OrdenAulaLlena ordenFin=null;
        public void setOrdenInicio(OrdenEnAula1_OrdenInicio o) { ordenInicio=o; }
        public void setOrdenLlegaAlumno(OrdenEnAula2_OrdenLlegaAlumno o) { ordenAlumno=o; }
        public void setOrdenAulaLlena(OrdenEnAula1_OrdenAulaLlena o) { ordenFin=o; }

        public void agregarConjunto(Comparable c) { 
            conjunto.Add(c);

            if (conjunto.Count == 1) { 
                if(ordenInicio!=null)
                    ordenInicio.ejecutar();
            }
            if (ordenAlumno != null) { 
                    ordenAlumno.ejecutar( (Alumno)c );
            }
            if (conjunto.Count >= 40) { 
                if(ordenFin!=null)
                    ordenFin.ejecutar();
            }
        }

        public void agregar(Comparable c) {
            if (!pertenece(c, conjunto))
                agregarConjunto(c);
        }
        public bool pertenece(Comparable c, List<Comparable> l)
        {
            foreach (Comparable elem in conjunto)
            {
                if (elem.sosIgual(c))
                    return true;
            }
            return false;
        }

        public int cuantos() { return conjunto.Count; }
        public Comparable minimo()
        {
            Comparable x = conjunto[0];
            foreach (Comparable elem in conjunto)
            {
                if (elem.sosMenor(x))
                    x = elem;
            }
            return x;
        }
        public Comparable maximo()
        {
            Comparable x = conjunto[0];
            foreach (Comparable elem in conjunto)
            {
                if (elem.sosMayor(x))
                    x = elem;
            }
            return x;
        }
        public bool contiene(Comparable c)
        {
            for (int i = 0; i < this.cuantos(); i++)
            {
                if (conjunto[i].sosIgual(c))
                    return true;
            }
            return false;
        }
        public List<Comparable> getConjunto() { return conjunto; }
        public Iterador crearIterador() { return new IteratorDiccionario(conjunto); }
    }
    public class ClaveValor : Comparable
    {
        private Comparable clave, valor;
        private EstrategiaDeComparacionClaves e;
        public ClaveValor(Comparable clave, Comparable valor)
        {
            this.clave = clave;
            this.valor = valor;
            e = new EstrategiaPorClave();
        }

        public Comparable getValor() { return valor; }
        public void setValor(Comparable c) { valor = c; }
        public Comparable valorClave() { return clave; }
        public void CambiarEstrategia(EstrategiaDeComparacionClaves e) { this.e = e; }
        public bool sosIgual(Comparable c) { return e.sosIgual(this, (ClaveValor)c); }
        public bool sosMenor(Comparable c) { return e.sosMenor(this, (ClaveValor)c); }
        public bool sosMayor(Comparable c) { return e.sosMayor(this, (ClaveValor)c); }
    }
    public class Diccionario : Coleccionable
    {

        private List<Comparable> coleccion;
        private ClaveValor clavevalor;
        private int contadorClaves;
        public Diccionario() { coleccion = new List<Comparable>(); contadorClaves = 0; }

        //Command
        private OrdenEnAula1_OrdenInicio ordenInicio=null;
        private OrdenEnAula2_OrdenLlegaAlumno ordenAlumno=null;
        private OrdenEnAula1_OrdenAulaLlena ordenFin=null;
        public void setOrdenInicio(OrdenEnAula1_OrdenInicio o) { ordenInicio=o; }
        public void setOrdenLlegaAlumno(OrdenEnAula2_OrdenLlegaAlumno o) { ordenAlumno=o; }
        public void setOrdenAulaLlena(OrdenEnAula1_OrdenAulaLlena o) { ordenFin=o; }

        public void agregarDiccionario(Comparable c) { 
            coleccion.Add(c);

            if (coleccion.Count == 1) { 
                if(ordenInicio!=null)
                    ordenInicio.ejecutar();
            }
            if (ordenAlumno != null) { 
                    ordenAlumno.ejecutar( (Alumno)c );
            }
            if (coleccion.Count >= 40) { 
                if(ordenFin!=null)
                    ordenFin.ejecutar();
            }
        }

        public void agregar(Comparable clave, Comparable valor)
        {
            bool x = false;
            if (coleccion.Count == 0){agregarDiccionario(new ClaveValor(clave, valor)); contadorClaves++;}
            else
            {
                foreach (Comparable elem in coleccion)          //Por cada ClaveValor de la coleccion, me fijo si alguna clave es la que me pasaron por parametro. SI esta la clave le cambio el valor
                {
                    if ( clave.sosIgual(((ClaveValor)elem).valorClave()) ) { ((ClaveValor)elem).setValor(valor); x = true; break; }
                }
                if (x == false) {                              //si no esta la agrego
                    agregarDiccionario(new ClaveValor(clave, valor)); contadorClaves++;
                }
            }
        }

        public List<Comparable> getDiccionario() { return coleccion; }

        public Comparable valorDe(Comparable clave)
        {
            clavevalor = new ClaveValor(clave, null);// creo esta clavevalor para poder compar la clave despues
            foreach (Comparable elem in coleccion)
            {

                ((ClaveValor)elem).CambiarEstrategia(new EstrategiaPorValor());//cambio la estrategia para poder compararlos por Valor

                if (((ClaveValor)elem).sosIgual(clavevalor)) { return ((ClaveValor)elem).getValor(); } //si la clave que recibi (clavevalor) es igual al elemento del conjunto, devuelve el valor
            }
            return null; //si no existe, retorna null
        }

        public int cuantos() { return coleccion.Count; }
        public Comparable minimo()
        {
            Comparable x = coleccion[0];
            foreach (Comparable elem in coleccion)
            {
                if (elem.sosMenor(x))
                    x = elem;
            }
            return x;
        }
        public Comparable maximo()
        {
            Comparable x = coleccion[0];
            foreach (Comparable elem in coleccion)
            {
                if (elem.sosMayor(x))
                    x = elem;
            }
            return x;
        }
        public void agregar(Comparable c) { agregar(c, new Numero(contadorClaves + 1)); }
        public bool contiene(Comparable c)
        {
            for (int i = 0; i < this.cuantos(); i++)
            {
                if (coleccion[i].sosIgual(c))
                    return true;
            }
            return false;
        }

        public Iterador crearIterador() { return new IteratorDiccionario(coleccion); }
    }
}
