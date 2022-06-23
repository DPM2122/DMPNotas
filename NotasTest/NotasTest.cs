using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using DMPNotas;

namespace NotasTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NotasCorrectas()
        {
            ClaseEstadisticasNotas notas = new ClaseEstadisticasNotas();
            List<int> ListaNotas = new List<int>();
   
            ListaNotas.Add(9);
            ListaNotas.Add(9);
            ListaNotas.Add(9);
            ListaNotas.Add(9);
            ListaNotas.Add(9);
            ListaNotas.Add(9);
            ListaNotas.Add(9);

            notas.CalcularMedia(ListaNotas);

            int suspensosEsperados = 0;
            int aprobadosEsperados = 0;
            int notablesEsperados = 0;
            int sobresalientesEsperados = 7;
            double mediaEsperada = 9;

            Assert.AreEqual(suspensosEsperados, notas.Suspensos, "El valor no es el esperado1");
            Assert.AreEqual(aprobadosEsperados, notas.Aprobados, "El valor no es el esperado2");
            Assert.AreEqual(notablesEsperados, notas.Notables, "El valor no es el esperado3");
            Assert.AreEqual(sobresalientesEsperados, notas.Sobresalientes, "El valor no es el esperado");
            Assert.AreEqual(mediaEsperada, notas.Media, "El valor no es el esperado4");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "No puden haber notas negativas")]
        public void NotasIncorrectasNegativas()
        {
            ClaseEstadisticasNotas Notas = new ClaseEstadisticasNotas();
            List<int> ListaNotas = new List<int>();

            ListaNotas.Add(-1);
            ListaNotas.Add(-2);
            ListaNotas.Add(3);
            ListaNotas.Add(4);
           
            Notas.CalcularMedia(ListaNotas);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "La lista no puede estar vacía")]
        public void SinNotas()
        {
            ClaseEstadisticasNotas Notas = new ClaseEstadisticasNotas();
            List<int> ListaNotas = new List<int>();
            Notas.CalcularMedia(ListaNotas);
        }

        [TestMethod]
        public void NotasNegativasTryCatch ()
        {
            ClaseEstadisticasNotas Notas = new ClaseEstadisticasNotas();
            List<int> ListaNotas = new List<int>();
            ListaNotas.Add(-1);
            ListaNotas.Add(-2);
            ListaNotas.Add(3);
            ListaNotas.Add(7);
            ListaNotas.Add(8);
            ListaNotas.Add(29);
            ListaNotas.Add(10);
            try
            {
                Notas.CalcularMedia(ListaNotas);
            }
            catch(ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "Las notas deben estar comprendidas entre 0 y 10");
            }   
        }
    }
}
