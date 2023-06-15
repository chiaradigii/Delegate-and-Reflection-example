using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtro
{

         //Custom Attribute
         [System.AttributeUsage(System.AttributeTargets.Class)]

        public class Mostrable : System.Attribute 
        {
            string leyenda;
            public Mostrable(string pleyenda) 
            { 
                leyenda = pleyenda; 
            }
            public string Leyenda() => leyenda;
        }
    
}
