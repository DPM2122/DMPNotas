using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMPNotas
{
   
    public class ClaseEstadisticasNotas //esta clase nos calcula las estadisticas de un conjunto de notas
    {
        public const int kSuspensos = 5;
        public const int kAprobados = 7;
        public const int kNotables = 9;

        private int suspensos;
        private int aprobados;
        private int notables;
        private int sobresalientes;
        private double media;
       

        public int Suspensos
        {
            get { return suspensos; }
            set { suspensos = value; }
        }
       
        public int Aprobados
        {
            get { return aprobados; }
            set { aprobados = value; }
        }
        public int Notables
        {
            get { return notables; }
            set { notables = value; }
        }
        public int Sobresalientes
        {
            get { return sobresalientes; }
            set { sobresalientes = value; }
        }
        public double Media
        {
            get { return media; }
            set { media = value; }
        }

        public ClaseEstadisticasNotas ()
        {
            Suspensos = 0;
            Aprobados = 0;
            Notables = 0;
            Sobresalientes = 0;
            Media = 0;
        }

        public ClaseEstadisticasNotas(List<int> ListaNotas)
        {
            CalcularEstadisticas(ListaNotas);
        }

        private void CalcularEstadisticas(List<int> ListaNotas)
        {
            Media = 0.0;

            for (int i = 0; i < ListaNotas.Count; i++)
            {
                if (ListaNotas[i] < kSuspensos) Suspensos++;
                else if (ListaNotas[i] >= kSuspensos && ListaNotas[i] < kAprobados) Aprobados++;
                else if (ListaNotas[i] >= kAprobados && ListaNotas[i] < kNotables) Notables++;
                else if (ListaNotas[i] >= kNotables) Sobresalientes++;
                Media = Media + ListaNotas[i];
            }
            Media = Media / ListaNotas.Count;
        }

        public double CalcularMedia (List<int> ListaNotas)
        {
           

            if (ListaNotas.Count <= 0)
            {
                throw new Exception("La lista no puede estar vacía");
            }

            for (int i = 0; i < ListaNotas.Count; i++)
            {
                if (ListaNotas[i] < 0 || ListaNotas[i] > 10)
                {
                    throw new ArgumentOutOfRangeException("Notas", i, "Las notas deben estar comprendidas entre 0 y 10");
                }
            }
               
            CalcularEstadisticas(ListaNotas);

            return Media;
        }


    }
}
