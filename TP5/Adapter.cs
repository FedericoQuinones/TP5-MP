using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MP_TP
{
    //Adapter
    public class AlumnoAdpater : Student, Comparable
    {

        private IAlumno alumno; //adaptable

        public AlumnoAdpater(IAlumno a) { alumno = a; alumno.CambiarEstrategia(new EstrategiaPorNombre()) ; }

        //traduccion
        public string getName() { return alumno.getNombre(); }
        public int yourAnswerIs(int question) { return alumno.responderPregunta(question); }
        public void setScore(int score) { alumno.setCalificacion(new Numero(score)); }
        public string showResult() { return alumno.mostrarCalificación(); }
        public IAlumno getAlumno() { return alumno; }

        public bool equals(Student student) { return alumno.sosIgual( ((AlumnoAdpater)student).getAlumno()); }
        public bool lessThan(Student student) { return alumno.sosMenor( ((AlumnoAdpater)student).getAlumno()); }
        public bool greaterThan(Student student) { return alumno.sosMayor( ((AlumnoAdpater)student).getAlumno() ) ; }

        public bool sosIgual(Comparable c) { throw new NotImplementedException(); } 
        public bool sosMayor(Comparable c) { throw new NotImplementedException(); } 
        public bool sosMenor(Comparable c) { throw new NotImplementedException(); } 
    }


    //Decorator
    
    public interface IAlumno : Comparable{ 
        string getNombre();
        string mostrarCalificación();
        Numero getCalificacion();
        Numero getLegajo();
        void setCalificacion(Numero n);
        int responderPregunta(int p);
        void CambiarEstrategia(EstrategiaDeComparacion e);
        bool sosIgual(Comparable c);
        bool sosMenor(Comparable c);
        bool sosMayor(Comparable c);
    }

    public abstract class DecoradorAlumno : IAlumno {
        private IAlumno adicional;
        public DecoradorAlumno(IAlumno a) { adicional=a; }
        public string getNombre() { return adicional.getNombre();}
        public Numero getCalificacion() { return adicional.getCalificacion(); ;}
        public Numero getLegajo() { return adicional.getLegajo();}
        public void setCalificacion(Numero n) { adicional.setCalificacion(n); }
        public int responderPregunta(int p) { return (int)(new GeneradorDeDatosAleatorios(4, 0).getNum().getValor()); }
        public void CambiarEstrategia(EstrategiaDeComparacion e) { adicional.CambiarEstrategia(e); }
        public bool sosIgual(Comparable c) { return adicional.sosIgual(c); }
        public bool sosMenor(Comparable c) { return adicional.sosMenor(c); }
        public bool sosMayor(Comparable c) { return adicional.sosMayor(c); }
        public virtual string mostrarCalificación() { return ""+ adicional.getNombre()+ "\t" + adicional.getCalificacion().getValor() ; }
    }

    public class DecoradorLegajo : DecoradorAlumno 
    {
        private IAlumno adicional;
        public DecoradorLegajo(IAlumno a):base(a) { adicional = a; }

        public override string mostrarCalificación() { 
            string resultado = adicional.mostrarCalificación() + "\t Legajo: " + adicional.getLegajo();
            return resultado; 
        }
    }

    public class DecoradorNotasLetras : DecoradorAlumno
    {
        private IAlumno adicional;
        public DecoradorNotasLetras(IAlumno a) : base(a) { adicional = a; }

        override public string mostrarCalificación()
        {
            string resultado = adicional.mostrarCalificación();

            switch (adicional.getCalificacion().getValor()) {
                case 0: return ($"{resultado} (CERO)");
                case 1: return ($"{resultado} (UNO)");
                case 2: return ($"{resultado} (DOS)");
                case 3: return ($"{resultado} (TRES)");
                case 4: return ($"{resultado} (CUATRO)");
                case 5: return ($"{resultado} (CINCO)");
                case 6: return ($"{resultado} (SEIS)");
                case 7: return ($"{resultado} (SIETE)");
                case 8: return ($"{resultado} (OCHO)");
                case 9: return ($"{resultado} (NUEVE)");
                case 10: return ($"{resultado} (DIEZ)");
            }
            return resultado;
        }
    }

    public class DecoradorCalificacion : DecoradorAlumno
    {
        private IAlumno adicional;
        public DecoradorCalificacion(IAlumno a) : base(a) { adicional = a; }

        override public string mostrarCalificación()
        {

            if(adicional.getCalificacion().getValor() >= 7) {
                return  $"{adicional.mostrarCalificación()} Promocionado" ;
            }
            else if (adicional.getCalificacion().getValor() >= 4 && adicional.getCalificacion().getValor() <= 7 ) {
                return adicional.mostrarCalificación() + " Aprobado";
            }
            else {
            return $"{adicional.mostrarCalificación()} Desaprobado";
        }
        }
    }

    public class DecoradorAsteriscos : DecoradorAlumno {
        private IAlumno adicional;
        public DecoradorAsteriscos(IAlumno a) : base(a) { adicional = a; }

        override public string mostrarCalificación()
        {
            string resultado = "***********************************************************\n*" + adicional.mostrarCalificación() + "*\n***********************************************************";
            return resultado;
        }
    }
    

}