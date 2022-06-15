using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MP_TP
{
    public class Persona : Comparable
    {
        string nombre;
        Numero dni;

        public Persona(string n, Numero d) { nombre = n; dni = d; }

        public string getNombre() { return nombre; }
        public Numero getDNI() { return dni; }

        public virtual bool sosIgual(Comparable c) { return c.sosIgual(this.getDNI()); }
        public virtual bool sosMenor(Comparable c) { return c.sosMenor(this.getDNI()); }
        public virtual bool sosMayor(Comparable c) { return c.sosMayor(this.getDNI()); }
    }

    public class Alumno : Persona, IAlumno
    {
        private Numero legajo, promedio, calificacion;
        private EstrategiaDeComparacion e;

        public Alumno(string n, Numero d, Numero legajo, Numero promedio) : base(n, d)
        {
            this.legajo = legajo;
            this.promedio = promedio;
            calificacion = new Numero(0);
            e = new EstrategiaPorLegajo();
        }
        public Numero getLegajo() { return legajo; }
        public Numero getPromedio() { return promedio; }
        public Numero getCalificacion() { return calificacion; }
        public void setCalificacion(Numero n) { calificacion = n; }

        public void CambiarEstrategia(EstrategiaDeComparacion e) { this.e = e; }

        public override bool sosIgual(Comparable c) { return e.sosIgual(this, c); }
        public override bool sosMenor(Comparable c) { return e.sosMenor(this, c); }
        public override bool sosMayor(Comparable c) { return e.sosMayor(this, c); }

        //TP4
        virtual public int responderPregunta(int p) { return (int)(new GeneradorDeDatosAleatorios(4, 0).getNum().getValor()); }
        public string mostrarCalificación() { return this.getNombre() + " " + calificacion.getValor(); }
    }
    public class AlumnoMuyEstudioso : Alumno
    {
        private Numero calificacion;
        private EstrategiaDeComparacion e;
        public AlumnoMuyEstudioso(string n, Numero d, Numero legajo, Numero promedio) : base(n, d, legajo, promedio) { this.calificacion = new Numero(10); e = new EstrategiaPorLegajo(); }
        override public int responderPregunta(int p) { return 3; }
    }

    public class GeneradorDeDatosAleatorios
    {
        private Numero n;
        private string s;


        public GeneradorDeDatosAleatorios(int n, int s)
        {
            Random random = new Random();
            this.n = new Numero(random.Next(1, n));

            string alfabeto = "ABCDEFGHIJKLNQLMNOPQXRSTUVWXYZ";

            for (int i = 0; i < s; i++)
            {
                n = random.Next(0, alfabeto.Length);
                this.s += alfabeto[n];
            }
        }
        public Numero getNum() { return n; }
        public string getString() { return s; }
    }
    public class LectorDeDatos
    {
        private Numero n;
        private string s;
        public LectorDeDatos(Numero n, string s) { this.n = n; this.s = s; }
        public Numero numeroPorTeclado() { return n; }
        public string stringPorTeclado() { return s; }
    }

    public class Vendedor : Persona, IObservado
    {
        private Numero sueldo_basico, bonus, monto;
        private EstrategiaDeComparacion e;
        public Vendedor(string n, Numero d, Numero sueldo_basico) : base(n, d)
        {
            this.sueldo_basico = sueldo_basico;
            this.bonus = new Numero(1);
            this.e = new EstrategiaPorBonus();
        }
        public Numero getSueldoB() { return sueldo_basico; }
        public Numero getBonus() { return bonus; }
        public Numero getMonto() { return monto; }

        public void venta(Numero n)
        {
            monto = n;
            Console.WriteLine(" El vendedor recibio un monto de " + monto.getValor() + "$"); this.notificar();
        }
        public void aumentaBonus()
        {
            int n = bonus.getValor();
            bonus = new Numero((int)(n + n * 0.1)); //lo aumento en entero para no cambiar la clase Numero 
        }
        public override bool sosIgual(Comparable c) { return e.sosIgual(this, c); }
        public override bool sosMenor(Comparable c) { return e.sosMenor(this, c); }
        public override bool sosMayor(Comparable c) { return e.sosMayor(this, c); }

        //Observer

        List<IObservador> lObservadores = new List<IObservador>();
        public void agregarObservador(IObservador o) { lObservadores.Add(o); }
        public void quitarObservador(IObservador o) { lObservadores.Remove(o); }
        public void notificar()
        {
            foreach (IObservador o in lObservadores)
                o.actualizar(this);
        }
    }
    public class Gerente : IObservador
    {
        private Conjunto mejores;
        public Gerente() { mejores = new Conjunto(); }
        public Conjunto getMejores() { return mejores; }
        public void cerrar()
        {
            Console.WriteLine("\n El/Los mejores vendedores de la jornada fueron:\n");
            foreach (Vendedor elem in mejores.getConjunto())
                Console.WriteLine(" " + elem.getNombre() + " con un bonus acomulado de " + elem.getBonus());
        }
        public void venta(Numero monto, Vendedor v)
        {
            if (monto.sosMayor(new Numero(5000)))
            {
                v.aumentaBonus();
                mejores.agregar(v);
            }
        }
        public void actualizar(IObservado o) { this.venta(((Vendedor)o).getMonto(), (Vendedor)o); }
    }

    public class Aula 
    {
        private Teacher t;
        public void comenzar() {
            Console.WriteLine("Comenzo la clase");
            t= new Teacher();
        }
        public void nuevoAlumno(Alumno a) { t.goToClass( new AlumnoAdpater(a)); }
        public void claselista() { t.teachingAClass(); }
    }

    public interface OrdenEnAula1 { void ejecutar(); }

    public class OrdenEnAula1_OrdenInicio
    {
        private Aula a;
        public OrdenEnAula1_OrdenInicio(Aula a) { this.a=a; }

        public void ejecutar() { a.comenzar(); }
    }

    public class OrdenEnAula1_OrdenAulaLlena
    {
        private Aula a;
        public OrdenEnAula1_OrdenAulaLlena(Aula a) { this.a=a; }

        public void ejecutar() { a.claselista() ;}
    }

    public interface OrdenEnAula2 { void ejecutar(Comparable c); }

    public class OrdenEnAula2_OrdenLlegaAlumno
    {
        private Aula a;
        public OrdenEnAula2_OrdenLlegaAlumno(Aula a) { this.a=a;}

        public void ejecutar(Alumno al) { a.nuevoAlumno(al) ;}
    }

    public interface Ordenable { 
        void setOrdenInicio(OrdenEnAula1_OrdenInicio o);
        void setOrdenLlegaAlumno(OrdenEnAula2_OrdenLlegaAlumno o);
        void setOrdenAulaLlena(OrdenEnAula1_OrdenAulaLlena o);
    }
}
