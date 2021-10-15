using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using ClassLibrary;

namespace AsterixDecoder
{
    public class AsterixFile
    {
        string path;
        List<CAT10> listaCAT10 = new List<CAT10>();
        List<CAT21> listaCAT21 = new List<CAT21>();
        DataTable tablaCAT10 = new DataTable();
        DataTable tablaCAT21 = new DataTable();



        public AsterixFile(string nombre)
        {
            this.path = nombre;
            Console.WriteLine("Hello World");
            leer();
        }

        public List<CAT10> getListCAT10()
        {
            return listaCAT10;
        }

        public List<CAT21> getListCAT21()
        {
            return listaCAT21;
        }

        public void leer()
        {

            byte[] fileBytes = File.ReadAllBytes(path);
            List<byte[]> listabyte = new List<byte[]>();
            int i = 0;
            int contador = fileBytes[2];

            while (i < fileBytes.Length)
            {
                byte[] array = new byte[contador];
                for (int j = 0; j < array.Length; j++)
                {
                    array[j] = fileBytes[i];
                    i++;
                }
                listabyte.Add(array);
                if (i + 2 < fileBytes.Length)
                {
                    contador = fileBytes[i + 2];
                }


            }



            for (int q = 0; q < listabyte.Count; q++)
            {
                byte[] arraystring = listabyte[q];
                
                int CAT = arraystring[0];
                if (CAT == 10)
                {
                    CAT10 newcat10 = new CAT10(arraystring);
                    listaCAT10.Add(newcat10);

                }

                else if (CAT == 21)
                {
                    CAT21 newcat21 = new CAT21(arraystring);
                    listaCAT21.Add(newcat21);


                }

            }

        }


        public DataTable getTablaCAT10()
        {
            return tablaCAT10;
        }

        public DataTable getTablaCAT21()
        {
            return tablaCAT21;
        }
    }

}

