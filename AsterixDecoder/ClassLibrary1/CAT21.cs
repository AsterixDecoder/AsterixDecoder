using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class CAT21
    {

        string[] arraystring = new string[200];


        public CAT21(string[] arraystring)
        {
            int len = arraystring.Length;
            this.arraystring = new string[len]; ///mirar si se iguala el tamaño automaticamente
            this.arraystring = arraystring;

        }


    }
}
