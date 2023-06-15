using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtro
{
    [Mostrable("Filtro para nombres con IGUAL cantidad de caracteres que corte")]

    internal class FiltroIgualQue : Filtro
    {

        
            public override IEnumerable<string> Filtrar(string[] pArray, int pCorte)
            {
                return pArray.Where<string>(x => x.Length == pCorte);  
            }
        

    }
}
