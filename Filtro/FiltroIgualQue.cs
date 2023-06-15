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
                return pArray.Where<string>(x => x.Length == pCorte);  //Uso Where porq era una que daba IEnumerable
                                                                       //x representa cada string en ese array de string
                                                                       //a la derecha del lamda hay una propociocion para filtrar (devuelve verdadero si x.Length >=pCorte)
                                                                       //recibe un string, devuelve un booleano
                                                                       //los elementos que va aiterar el IEnumerable son en base a ese filtro que puse
            }
        

    }
}
