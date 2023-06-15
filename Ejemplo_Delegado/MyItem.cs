using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_Delegado
{
    internal class MyItem
    {
     
            string leyenda; 
            Type tipo;

            public MyItem(string pLeyenda, Type pTipo)
            {
                leyenda = pLeyenda;
                tipo = pTipo;
            }

            public string Leyenda() => leyenda; 
            public Type Tipo() => tipo; 

            public override string ToString() 
            {
                return Leyenda();
            }
        
    }
}
