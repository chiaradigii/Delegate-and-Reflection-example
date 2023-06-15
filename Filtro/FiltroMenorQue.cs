using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtro
{
    [Mostrable("Filtro para nombres con menos o igual cantidad de caracteres que corte")]

    public class FiltroMenorQue : Filtro
    {
        public override IEnumerable<string> Filtrar(string[] pArray, int pCorte)
        {
            return pArray.Where<string>(x => x.Length <= pCorte);
        
            //lo mismo que filtroMayorQue pero filtra mayor que
        }
    }
}
