using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB02_ED2.Class;
using System.IO;

namespace LAB02_ED2.Class
{
    public class Soda :  IFixedSizeText
    {
        public string Name { get; set; } //id
        public string Flavor { get; set; }
        public int Volum { get; set; }
        public double Price { get; set; }
        public string Made { get; set; } //its the house of create the flavor and made the final product


        public string ToFixedLengthString()
        {
            return $"{string.Format("{0,-20}", Name)}|{string.Format("{0,-20}", Flavor)}|" +
                $"{Volum.ToString("00000000;-00000000")}|{Price.ToString("00000000;-00000000")}|" +
                $"{string.Format("{0,-20}", Made)}";
        }

        public int FixedSizeText
        {
            get { return FixedSize; }
        }

        public static int FixedSize { get { return 82; } }
        // |cocacola|cola|00000080|00000010|cocaola|//

        public string path = @"C:\Users\walte\OneDrive\Escritorio\file.txt";

        public void Guardar()
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                foreach (var item in Soda)
                {
                    fs.Write(ByteGenerator.ConvertToBytes(item.ToFixedSizeString()), 0, Soda.FixedSize);
                }
            }

            var buffer = new byte[Soda.FixedSize];
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                fs.Seek((1) * Soda.FixedSize, SeekOrigin.Begin);
                fs.Read(buffer, 0, Soda.FixedSize);
            }
        }

    }



}
