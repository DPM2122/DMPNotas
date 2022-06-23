using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMPNotas
{
    /// <summary>
    ///<para>Clase que calcula las estadíaticas de un conjunto de notas</para> 
    ///<para>Contabiliza el número de suspensos, aprobados, notables y sobresalientes</para>
    /// </summary>
    public class ClaseEstadisticasNotas //esta clase nos calcula las estadisticas de un conjunto de notas
    {
        /// <summary>
        /// Variables constantes para determinar el tope de notas para las calificaciones
        /// </summary>
        public const int TopeSuspensos = 5;
        public const int TopeAprobados = 7;
        public const int TopeNotables = 9;
        /// <summary>
        /// Declaración de variables
        /// </summary>
        private int suspensos;
        private int aprobados;
        private int notables;
        private int sobresalientes;
        private double media;
       
        /// <summary>
        /// Se inician los getters y los setters
        /// </summary>
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

        /// <summary>
        /// Se inician las variables a 0
        /// </summary>
        public ClaseEstadisticasNotas ()
        {
            Suspensos = 0;
            Aprobados = 0;
            Notables = 0;
            Sobresalientes = 0;
            Media = 0;
        }

        /// <summary>
        /// Se inicia la Lista donde se van a almacenar las notas que se introduzcan
        /// </summary>
        /// <param name="ListaNotas">La notas de los alumnos que se irán introduciendo</param>
        /// <remarks>Se  hace la llamada al método CalcularEstadísticas</remarks>
        public ClaseEstadisticasNotas(List<int> ListaNotas)
        {
            CalcularEstadisticas(ListaNotas);
        }

        /// <summary>
        /// Método calcula la estadistica de un conjunto de notas 
        /// </summary>
        /// <param name="ListaNotas">Notas que se van introduciendo</param>
        /// <remarks>Y contabiliza el número de suspensos, aprobados, notables y sobresalientes de la lista de notas y la media de dicha lista de notas</remarks>
        /// <returns>Se obtiene el número de suspensos<see cref=">Suspensos"/>, aprobados<see cref=">Aprobados"/>, notables<see cref=">Notables"/>
        /// y sobresalientes<see cref=">Sobresalientes"/> de la lista de notas y la media<see cref=">Media"/> de dicha lista de notas</returns>

        private void CalcularEstadisticas(List<int> ListaNotas)
        {
            Media = 0.0;

            for (int i = 0; i < ListaNotas.Count; i++)
            {
                if (ListaNotas[i] < TopeSuspensos) Suspensos++;
                else if (ListaNotas[i] >= TopeSuspensos && ListaNotas[i] < TopeAprobados) Aprobados++;
                else if (ListaNotas[i] >= TopeAprobados && ListaNotas[i] < TopeNotables) Notables++;
                else if (ListaNotas[i] >= TopeNotables) Sobresalientes++;
                Media = Media + ListaNotas[i];
            }
            Media = Media / ListaNotas.Count;
        }

        /// <summary>
        /// Método que calcula media de una lista de notas
        /// </summary>
        /// <param name="ListaNotas">Lista donde se almacenan las notas introducidas</param>
        /// <returns>Nos devuelve la media de todas las notas que se introducen en la lista<see cref=">ListaNotas"/></returns>
        /// <exception cref="Exception">Salta una excepción si la lista está vacía</exception>
        /// <exception cref="ArgumentOutOfRangeException">Salta la excepción si los valores introducidos son menor de 0 o mayor de 10</exception>
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
