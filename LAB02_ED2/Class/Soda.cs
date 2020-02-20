using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB02_ED2.Class
{
    public class Soda : IComparable, IFixedSizeText
    {
        public string Name { get; set; } //id
        public string Flavor { get; set; }
        public int Volum { get; set; }
        public double Price { get; set; }
        public string Made { get; set; } //its the house of create the flavor and made the final product

        public string ToFixedSizeString()
        {
            return $"{string.Format("{0,-20}", Name)}|{string.Format("{0,-20}", Flavor)}|" +
                $"{Volum.ToString("00000000;-00000000")}|{Price.ToString("00000000;-00000000")}|" +
                $"{string.Format("{0,-20}", Made)}";
        }

        public int FixedSizeText
        {
            get { return FixedSize; }
        }

        public static int FixedSize { get { return 82; } } // |cocacola|cola|00000080|00000010|cocaola|



    }



    //interface all type dates have a fixed size text
    public  interface IFixedSizeText
    {
        int FixedSizeText { get; set; }
        string ToFixedLengthString();
    }

}
