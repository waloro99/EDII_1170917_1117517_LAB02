using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB02_ED2.Class;

namespace LAB02_ED2.Class
{
    public class BTree_A <TKey, T> where TKey : IComparable<TKey>
    {

        public NodoB root { get; set; }

        public int Grado { get; private set; }

        public int Altura { get; private set; }

        public BTree_A(int grado)
        {
            if (grado < 2)
            {
                throw new ArgumentException("Error", "grado");
            }
            this.root = new NodoB(grado);
            this.Grado = grado;
            this.Altura = 1;
        }


        public NodoB Search(TKey Llave)
        {
            return this.BusquedaInterna(root, Llave);
        }

        private NodoB BusquedaInterna(NodoB root, TKey llave)
        {
            throw new NotImplementedException();
        }

        public void Insertar(TKey nuevaLlave, T nuevoApuntador)
        {
            InsertarRecursivo(root, nuevaLlave, nuevoApuntador, null);

        }

        private void InsertarRecursivo(NodoB root, TKey nuevaLlave, T nuevoApuntador, object p)
        {
            throw new NotImplementedException();
        }

 
    }
}
