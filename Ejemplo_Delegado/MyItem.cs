using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_Delegado
{
    internal class MyItem
    {
     
            string leyenda; //el constructor recibe esto y los almacena en estos dos campos
            Type tipo;

            public MyItem(string pLeyenda, Type pTipo)
            {
                leyenda = pLeyenda;
                tipo = pTipo;
            }

            public string Leyenda() => leyenda; //funcion que retorna leyenda
            public Type Tipo() => tipo; //funcion que retorna el tipo

            public override string ToString() //sobreescribe el metodo ToSTring para que devuelva la leyenda ¿porque? porque quiero personalizarlo para q devuelva la leyenda cargada
            {
                return Leyenda();
            }
        
    }
}
