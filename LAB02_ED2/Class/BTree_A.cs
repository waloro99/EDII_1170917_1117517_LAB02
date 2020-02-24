using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB02_ED2.Class;

namespace LAB02_ED2.Class
{
    public class BTree_A <TKey, T> where TKey : IComparable<TKey>
    {

        public NodoB<TKey, T> Raiz { get; set; }

        public int Grado { get; private set; }

        public int Altura { get; private set; }



    }
}
