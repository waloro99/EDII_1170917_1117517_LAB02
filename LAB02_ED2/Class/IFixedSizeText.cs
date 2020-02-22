using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB02_ED2.Class;

namespace LAB02_ED2.Class
{
     interface IFixedSizeText     //interface all type dates have a fixed size text
    {
        int FixedSizeText { get; }
        string ToFixedLengthString();
    }
}
