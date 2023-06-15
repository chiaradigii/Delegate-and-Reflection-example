using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtro
{
    public abstract class Filtro
    {
        public abstract IEnumerable<string> Filtrar(string[] pArray, int pCorte); //respecting Delegate signature
    }
}
