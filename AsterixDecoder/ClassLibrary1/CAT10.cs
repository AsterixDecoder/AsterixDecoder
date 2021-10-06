using System;

namespace ClassLibrary
{
   
    public class CAT10
    {

        string[] arraystring = new string[200];


        public CAT10(string[] arraystring)
        {
            int len = arraystring.Length;
            this.arraystring = new string[len]; ///mirar si se iguala el tamaño automaticamente
            this.arraystring = arraystring;
             
        }

        




}
}
