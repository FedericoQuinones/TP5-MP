using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MP_TP
{

    public class ProxyAlumno : IAlumno {
        private IAlumno alumnoReal=null;
        private string nombre;

        public ProxyAlumno(string n) { nombre = n; }

        public string getNombre() { return nombre; }

        //Metodos que delego y se ejecutan despues de crear al alumno
        public string mostrarCalificación() { return alumnoReal.mostrarCalificación(); }
        public void CambiarEstrategia(EstrategiaDeComparacion e) { alumnoReal.CambiarEstrategia(e); }
        public bool sosIgual(Comparable c) { return alumnoReal.sosIgual(c); }
        public bool sosMenor(Comparable c) { return alumnoReal.sosMenor(c); }
        public bool sosMayor(Comparable c) { return alumnoReal.sosMayor(c); }
        public Numero getCalificacion() { return alumnoReal.getCalificacion(); }
        public Numero getLegajo() { return alumnoReal.getLegajo(); }
        public void setCalificacion(Numero n) { alumnoReal.setCalificacion(n); }

        //Metodos que resuelve el alumno real
        public int responderPregunta(int p) {
            if (alumnoReal == null)
                alumnoReal = (Alumno) FabricaDeComparables.crearComparable(2, false);
            return alumnoReal.responderPregunta(p); 
        }
    }

    public class ProxyAlumnoMuyEstudioso : IAlumno
    {
        private IAlumno alumnoReal = null;
        private string nombre;

        public ProxyAlumnoMuyEstudioso(string n) { nombre = n; }

        public string getNombre() { return nombre; }

        //Metodos que delego y se ejecutan despues de crear al alumno
        public string mostrarCalificación() { return alumnoReal.mostrarCalificación(); }
        public void CambiarEstrategia(EstrategiaDeComparacion e) { alumnoReal.CambiarEstrategia(e); }
        public bool sosIgual(Comparable c) { return alumnoReal.sosIgual(c); }
        public bool sosMenor(Comparable c) { return alumnoReal.sosMenor(c); }
        public bool sosMayor(Comparable c) { return alumnoReal.sosMayor(c); }
        public Numero getCalificacion() { return alumnoReal.getCalificacion(); }
        public Numero getLegajo() { return alumnoReal.getLegajo(); }
        public void setCalificacion(Numero n) { alumnoReal.setCalificacion(n); }

        //Metodos que resuelve el alumno real
        public int responderPregunta(int p)
        {
            if (alumnoReal == null)
                alumnoReal = (Alumno)FabricaDeComparables.crearComparable(2, false);
            return alumnoReal.responderPregunta(p);
        }
    }
}
