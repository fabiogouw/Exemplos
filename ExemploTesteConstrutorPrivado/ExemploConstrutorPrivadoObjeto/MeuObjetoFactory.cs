using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExemploConstrutorPrivadoObjeto
{
    public class MeuObjetoFactory
    {
        public MeuObjeto CriarObjeto()
        {
            return new MeuObjeto()
            {
                Dependencia = new MinhaDependencia()
            };
        }
    }
}
