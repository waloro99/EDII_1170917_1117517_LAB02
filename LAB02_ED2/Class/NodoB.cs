using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IO;

namespace LAB02_ED2.Class
{
    public class NodoB
    {
        public const int OrdenMinimo = 5;
        public const int OrdenMaximo = 99;
        internal int Orden { get; private set; }
        internal int Posicion { get; private set; }
        public NodoB Padre { get; set; }
        internal List<NodoB> Hijos { get; set; }
        internal List<int> Llaves { get; private set; }


        public NodoB(int valor)
        {
            Llaves = new List<int>();
            Llaves.Add(valor);
            Hijos = new List<NodoB>();
        }

        public int Encontrado(string valor)
        {
            for (int i = 0; i < Llaves.Count; i++)
            {
                if (Llaves[i].CompareTo(valor) == 0)
                {
                    return 1;
                }
            }
            return -1;
        }

        public int CompareTo(object obj, int x)
        {
            return this.Hijos[x].Llaves[0].CompareTo(((NodoB)obj).Llaves[0]);
        }



        internal int CantidadDatos
        {
            get
            {
                int i = 0;
                while (i < Llaves.Count )
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


        public void InsertarHijo(NodoB son)
        {
            for (int x = 0; x < Hijos.Count; x++)
            {
                if (this.CompareTo(son, x) > 0)
                {
                    Hijos.Insert(x, son);
                    return;
                }
            }

            Hijos.Add(son);
            son.Padre = this;
        }

    }
}
