using System;
using System.IO;

namespace ExemploMicrosoftFakes
{
    public class ClasseDeNegocio
    {
        public void ExcluriArquivoAntigo(string arquivo)
        {
            // verifica se o arquivo existe
            if (File.Exists(arquivo))
            {
                // verifica se ele é mais velho que 2 meses atrás (regra do sistema)
                if (File.GetCreationTime(arquivo) < DateTime.Now.AddMonths(-2))
                {
                    // sendo assim, exclui
                    File.Delete(arquivo);
                }
            }
        }
    }
}
