using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IO;

namespace LAB02_ED2.Class
{
    internal class NodoB<T> where T : ITextoTamañoFijo
    {
        public const int OrdenMinimo = 5;
        public const int OrdenMaximo = 99;
        internal int Orden { get; private set; }
        internal int Posicion { get; private set; }
        internal int Padre { get; set; }
        internal List<int> Hijos { get; set; }
        internal List<int> Llaves { get; set; }
        internal List<T> Datos { get; set; }

        internal int CantidadDatos
        {
            get
            {
                int i = 0;
                while (i < Llaves.Count && Llaves[i] != Utilidades.ApuntadorVacio)
                {
                    i++;
                }
                return i;
            }
        }
        internal bool Underflow
        {
            get
            {
                return (CantidadDatos < ((Orden / 2) - 1));
            }
        }
        internal bool Lleno
        {
            get
            {
                return (CantidadDatos >= Orden - 1);
            }
        }
        internal bool EsHoja
        {
            get
            {
                bool EsHoja = true;
                for (int i = 0; i < Hijos.Count; i++)
                {
                    if (Hijos[i] != Utilidades.ApuntadorVacio)
                    {
                        EsHoja = false;
                        break;
                    }
                }
                return EsHoja;
            }
        }

        internal int TamañoEnTexto
        {
            get
            {
                int tamañoEnTexto = 0;
                tamañoEnTexto += Utilidades.TextoEnteroTamaño + 1; // Tamaño del indicador de Posición
                tamañoEnTexto += Utilidades.TextoEnteroTamaño + 1; // Tamaño apuntador al Padre
                tamañoEnTexto += 2; // Separadores adicionales
                tamañoEnTexto += (Utilidades.TextoEnteroTamaño + 1) * Orden; // Tamaño Hijos
                tamañoEnTexto += 2; // Separadores adicionales
                tamañoEnTexto += (Utilidades.TextoEnteroTamaño + 1) * (Orden - 1); // Tamaño Llaves
                tamañoEnTexto += 2; // Separadores adicionales
                tamañoEnTexto += (Datos[0].TamañoEnTexto + 1) * (Orden - 1); // Tamaño Datos
                tamañoEnTexto += Utilidades.TextoNuevaLineaTamaño; // Tamaño del Enter
                return tamañoEnTexto;
            }
        }
        internal int TamañoEnBytes
        {
            get
            {
                return TamañoEnTexto * Utilidades.BinarioCaracterTamaño;
            }
        }

        public object Utilidades { get; private set; }

        private int CalcularPosicionEnDisco(int tamañoEncabezado)
        {
            return tamañoEncabezado + (Posicion * TamañoEnBytes);
        }
        private string ConvertirATextoTamañoFijo()
        {
            StringBuilder datosCadena = new StringBuilder();
            datosCadena.Append(Utilidades.FormatearEntero(Posicion));
            datosCadena.Append(Utilidades.TextoSeparador);
            datosCadena.Append(Utilidades.FormatearEntero(Padre));
            datosCadena.Append(Utilidades.TextoSeparador);
            datosCadena.Append(Utilidades.TextoSeparador);
            datosCadena.Append(Utilidades.TextoSeparador);
            for (int i = 0; i < Hijos.Count; i++)
            {
                datosCadena.Append(Utilidades.FormatearEntero(Hijos[i]));
                datosCadena.Append(Utilidades.TextoSeparador);
            }

            datosCadena.Append(Utilidades.TextoSeparador);
            datosCadena.Append(Utilidades.TextoSeparador);
            for (int i = 0; i < Llaves.Count; i++)
            {
                datosCadena.Append(Utilidades.FormatearEntero(Llaves[i]));
                datosCadena.Append(Utilidades.TextoSeparador);
            }
            datosCadena.Append(Utilidades.TextoSeparador);
            datosCadena.Append(Utilidades.TextoSeparador);
            for (int i = 0; i < Datos.Count; i++)
            {
                datosCadena.Append(Datos[i].ConvertirATextoTamañoFijo().Replace(Utilidades.TextoSeparador,
               Utilidades.TextoSustitutoSeparador));
                datosCadena.Append(Utilidades.TextoSeparador);
            }
            datosCadena.Append(Utilidades.TextoNuevaLinea);
            return datosCadena.ToString();
        }
        private byte[] ObtenerBytes()
        {
            byte[] datosBinarios = null;
            datosBinarios = Utilidades.ConvertirBinarioYTexto(ConvertirATextoTamañoFijo());
            return datosBinarios;
        }
        private void LimpiarNodo(IFabricaTextoTamañoFijo<T> fabrica)
        {
            Hijos = new List<int>();
            for (int i = 0; i < Orden; i++)
            {
                Hijos.Add(Utilidades.ApuntadorVacio);
            }
            Llaves = new List<int>();
            for (int i = 0; i < Orden - 1; i++)
            {
                Llaves.Add(Utilidades.ApuntadorVacio);
            }
            Datos = new List<T>();
            for (int i = 0; i < Orden - 1; i++)
            {
                Datos.Add(fabrica.FabricarNulo());
            }
        }

        internal NodoB(int orden, int posicion, int padre, IFabricaTextoTamañoFijo<T> fabrica)
        {
            if ((orden < OrdenMinimo) || (orden > OrdenMaximo))
            {
                throw new ArgumentOutOfRangeException("orden");
            }
            if (posicion < 0)
            {
                throw new ArgumentOutOfRangeException("posicion");
            }
            Orden = orden;
            Posicion = posicion;
            Padre = padre;
            LimpiarNodo(fabrica);
        }



    }
}
