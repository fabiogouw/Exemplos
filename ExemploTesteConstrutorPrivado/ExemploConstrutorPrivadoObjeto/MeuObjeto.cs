using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExemploConstrutorPrivadoObjeto
{
    public class MeuObjeto
    {
        public IMinhaDependencia Dependencia { get; set; }

        internal MeuObjeto()
        {
            // internal para garantir que apenas a factory possa criar este objeto
        }

        public int RetornarCalculo(int a)
        {
            return Dependencia.Calcular() + a;
        }
    }
}
