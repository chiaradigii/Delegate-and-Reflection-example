using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtro
{
    //para que sea personalizado debe tener ese[System.AttributeUsage(System.AttributeTargets.CLass)] → ahi le puse que se pueda usar en CLASES.Podria ser otra cosa como Structs, o ambas
    //dice ese attribute que se puede usar a nivel de Clases porque yo quiero etiquetar clases en este caso para identificarlas de otras clases para filtrar solo las que tienen el CUstom Attribute mostrable

         //Custom Attribute
         [System.AttributeUsage(System.AttributeTargets.Class)]

        public class Mostrable : System.Attribute  //heredo de Attribute
        {
            string leyenda;
            public Mostrable(string pleyenda) 
            { 
                leyenda = pleyenda; 
            }
            public string Leyenda() => leyenda;
        }
    
}
