using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MP_TP
{
    public interface IFabricaDeComparables
    {
        Comparable crearAleatorio();
        Comparable crearPorTeclado();
    }
    public abstract class FabricaDeComparables : IFabricaDeComparables
    {
        public static Comparable crearComparable(int nroFabrica, bool queFuncion)  //implemente bool queFuncion para decidir como crear el comparable: (false, crea aleatorio) (true, crea por teclado)
        {
            FabricaDeComparables fabrica = null;
            switch (nroFabrica)
            {
                case 1: fabrica = new FabricaDeNumeros(); break;
                case 2: fabrica = new FabricaDeAlumnos(); break;
                case 3: fabrica = new FabricaDeVendedores(); break;
                case 4: fabrica = new FabricaDeAlumnosMuyEstudioso(); break;
            }
            if (queFuncion == false)
                return fabrica.crearAleatorio();
            else
                return fabrica.crearPorTeclado();
        }

        public abstract Comparable crearAleatorio();
        public abstract Comparable crearPorTeclado();
    }
    public class FabricaDeNumeros : FabricaDeComparables
    {
        override public Comparable crearAleatorio()
        {
            GeneradorDeDatosAleatorios a = new GeneradorDeDatosAleatorios(20, 3); //genero un numero aleatorio entre 0 y 20
            return a.getNum();
        }
        override public Comparable crearPorTeclado()
        {
            Console.WriteLine("Ingrese el un numero que desea transformarlo en comparable: ");
            Numero n = new Numero(int.Parse(Console.ReadLine()));
            return n;
        }
    }
    public class FabricaDeAlumnos : FabricaDeComparables
    {
        override public Comparable crearAleatorio()
        {
            Alumno n = new Alumno("Alumno" + new GeneradorDeDatosAleatorios(0, 1).getString(), new GeneradorDeDatosAleatorios(100, 0).getNum(), new GeneradorDeDatosAleatorios(20, 0).getNum(), new GeneradorDeDatosAleatorios(10, 0).getNum()); // nombre: Alumno (letraAleatoria), dni: N.aleatorio, legajo= N.aleatorio, prom= N.aleatorio
            return n;
        }

        override public Comparable crearPorTeclado()
        {
            Numero dni, legajo, promedio;
            Console.WriteLine("Ingrese nombre del alumno"); string n = Console.ReadLine();
            Console.WriteLine("Ingrese DNI del alumno"); dni = new Numero(int.Parse(Console.ReadLine()));
            Console.WriteLine("Ingrese legajo del alumno"); legajo = new Numero(int.Parse(Console.ReadLine()));
            Console.WriteLine("Ingrese promedio del alumno"); promedio = new Numero(int.Parse(Console.ReadLine()));

            Alumno a = new Alumno(n, dni, legajo, promedio);
            return a;
        }
    }

    public class FabricaDeVendedores : FabricaDeComparables
    {
        override public Comparable crearAleatorio()
        {
            Random random = new Random(); int x = random.Next(0, 29); string alfabeto = "ABCDEFGHIJKLNQLMNOPQXRSTUVWXYZ";

            Vendedor v = new Vendedor("Vendedor" + alfabeto[x], new GeneradorDeDatosAleatorios(10, 0).getNum(), new GeneradorDeDatosAleatorios(500, 0).getNum()); return v;
        }

        override public Comparable crearPorTeclado()
        {
            Numero dni, sueldo;
            Console.WriteLine("Ingrese nombre del vendedor"); string n = Console.ReadLine();
            Console.WriteLine("Ingrese DNI del vendedor"); dni = new Numero(int.Parse(Console.ReadLine()));
            Console.WriteLine("Ingrese sueldo del vendedor"); sueldo = new Numero(int.Parse(Console.ReadLine()));

            Vendedor v = new Vendedor(n, dni, sueldo);
            return v;
        }
    }
    public class FabricaDeAlumnosMuyEstudioso : FabricaDeComparables
    {
        override public Comparable crearAleatorio()
        {
            Alumno n = new AlumnoMuyEstudioso("Alumno" + new GeneradorDeDatosAleatorios(0, 1).getString(), new GeneradorDeDatosAleatorios(100, 0).getNum(), new GeneradorDeDatosAleatorios(20, 0).getNum(), new GeneradorDeDatosAleatorios(10, 0).getNum()); // nombre: Alumno (letraAleatoria), dni: N.aleatorio, legajo= N.aleatorio, prom= N.aleatorio
            return n;
        }

        override public Comparable crearPorTeclado()
        {
            Numero dni, legajo, promedio;
            Console.WriteLine("Ingrese nombre del alumno"); string n = Console.ReadLine();
            Console.WriteLine("Ingrese DNI del alumno"); dni = new Numero(int.Parse(Console.ReadLine()));
            Console.WriteLine("Ingrese legajo del alumno"); legajo = new Numero(int.Parse(Console.ReadLine()));
            Console.WriteLine("Ingrese promedio del alumno"); promedio = new Numero(int.Parse(Console.ReadLine()));

            Alumno a = new AlumnoMuyEstudioso(n, dni, legajo, promedio);
            return a;
        }
    }
}
