using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MP_TP
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("---------------TP5---------------");
            Console.WriteLine("--Ejer02--");

            Teacher teacher = new Teacher();

            for (int i = 0; i < 10; i++)
            {
                Random random = new Random();
                IAlumno a = new AlumnoMuyEstudioso("AlumnoEstudioso " + i, new Numero(random.Next(100, 200)), new Numero(i), new Numero(random.Next(7, 10)));
                a = new DecoradorNotasLetras(a);
                a = new DecoradorCalificacion(a);
                a = new DecoradorLegajo(a);
                a = new DecoradorAsteriscos(a);
                Student student = new AlumnoAdpater(a);
                teacher.goToClass(student);
            }

            for (int i = 0; i < 10; i++)
            {
                Random random = new Random();
                IAlumno a = new Alumno("Alumno " + i, new Numero(random.Next(100, 200)), new Numero(10 + i), new Numero(random.Next(0, 10)));
                a = new DecoradorNotasLetras(a);
                a = new DecoradorCalificacion(a);
                a = new DecoradorLegajo(a);
                a = new DecoradorAsteriscos(a);
                Student student = new AlumnoAdpater(a);
                teacher.goToClass(student);
            }

            teacher.teachingAClass();

            IAlumno b = new AlumnoMuyEstudioso("AlumnoEstudioso 40", new Numero(4), new Numero(4), new Numero(10));

            IAlumno d1 = new DecoradorNotasLetras(b);
            IAlumno d2 = new DecoradorCalificacion(d1);
            IAlumno d3 = new DecoradorLegajo(d2);
            IAlumno d4 = new DecoradorAsteriscos(d3);

            Student st = new AlumnoAdpater(d4);

            Console.WriteLine(st.showResult());

            Console.WriteLine("--Ejer10--");

            Pila pila1 = new Pila();
            Aula aula1 = new Aula();
            pila1.setOrdenInicio(new OrdenEnAula1_OrdenInicio(aula1));
            pila1.setOrdenLlegaAlumno(new OrdenEnAula2_OrdenLlegaAlumno(aula1));
            pila1.setOrdenAulaLlena(new OrdenEnAula1_OrdenAulaLlena(aula1));

            llenar(pila1, 2);
            //llenar(pila1, 4);

            Console.WriteLine("\n Hello World!");
            Console.Read();
        }

        private static void llenar(Coleccionable c, int nroFabrica)
        {
            for (int i = 0; i < 20; i++)
            {
                Comparable comp = FabricaDeComparables.crearComparable(nroFabrica, false);
                c.agregar(comp);
            }
            Console.WriteLine("Se lleno todo");
        }

        private static void llenarPersonas(Coleccionable c)
        {
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                Persona p = new Persona("Persona " + i, new Numero(random.Next(100, 200)));
                c.agregar(p);
            }
        }

        private static void llenarAlumnos(Coleccionable c)
        {
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                Persona a = new Alumno("Alumno " + i, new Numero(random.Next(100, 200)), new Numero(i), new Numero(random.Next(0, 10)));
                c.agregar(a);
            }
        }

        private static void informar(Coleccionable c, int nroFabrica)
        {
            Console.WriteLine(c.cuantos());
            Console.WriteLine(c.minimo());
            Console.WriteLine(c.maximo());

            Comparable comp = FabricaDeComparables.crearComparable(nroFabrica, true);
            if (c.contiene(comp))
                Console.WriteLine("El elemento leido esta en la coleccion");
            else
                Console.WriteLine("El elemento leido NO esta en la coleccion");
        }

        private static void imprimirElementos(Iterador c)
        {
            while (!c.fin())
            {
                Comparable elemento = c.actual();
                Console.WriteLine(elemento);
                c.siguiente();
            }
        }
        private static void cambiarEstrategia(Coleccionable c, EstrategiaDeComparacion e) //cambio la estrategia dada una cola/pila/conjunto de estudiantes (pero antes hay que hacer iterable la cola)
        {
            Iterador it = c.crearIterador();

            while (!it.fin())
            {
                ((Alumno)it.actual()).CambiarEstrategia(e);
                it.siguiente();
            }
        }

        private static void jornadaDeVentas(List<Comparable> c)
        {
            Random random = new Random(); //vuelvo a poner el random porque generarNumeroAleatorio me da siempre el mismo
            foreach (Comparable elem in c)
            {
                Numero monto = new Numero(random.Next(1, 7000));
                ((Vendedor)elem).venta(monto);
            }

        }
    }
}
