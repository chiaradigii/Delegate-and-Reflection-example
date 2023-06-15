using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Filtro
{
    [Mostrable("Filtro para nombres con mas o igual cantidad de caracteres que corte")]

    public class FiltroMayorQue : Filtro
    {
        public override IEnumerable<string> Filtrar(string[] pArray, int pCorte)
        {
            return pArray.Where<string>(x => x.Length >= pCorte); 
        }
    }
}
