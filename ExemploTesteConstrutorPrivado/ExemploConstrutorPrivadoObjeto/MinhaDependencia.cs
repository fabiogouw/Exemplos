using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExemploConstrutorPrivadoObjeto
{
    // faz de conta que é um objeto muito custoso para criar
    public class MinhaDependencia : IMinhaDependencia
    {
        public int Calcular()
        {
            return 1;
        }
    }
}
