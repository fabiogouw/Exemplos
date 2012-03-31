using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes; // para ShimsContext
using System.IO.Fakes;  // para o ShimFile
using System.Fakes; // para o ShimDateTime


namespace ExemploMicrosoftFakes
{
    [TestClass]
    public class TesteDeUnidade
    {
        [TestMethod]
        public void ClasseDeNegocio_ConsultarConteudoArquivo_NaoDeveExcluirArquivoInexistente()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                bool excluido = false;
                ShimFile.ExistsString = (s) => false;
                ShimFile.DeleteString = (s) => excluido = true;
                var alvo = new ClasseDeNegocio();
                // Act
                alvo.ExcluriArquivoAntigo("xxx");
                // Assert
                Assert.AreEqual(false, excluido);
            }
        }

        [TestMethod]
        public void ClasseDeNegocio_ConsultarConteudoArquivo_DeveExcluirArquivoMaisAntigoQue2MesesDaDataAtual()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                ShimDateTime.NowGet = () => DateTime.Parse("2011-04-01");
                bool excluido = false;
                ShimFile.ExistsString = (s) => true;
                ShimFile.GetCreationTimeString = (s) => DateTime.Parse("2011-01-01");
                ShimFile.DeleteString = (s) => excluido = true;
                var alvo = new ClasseDeNegocio();
                // Act
                alvo.ExcluriArquivoAntigo("xxx");
                // Assert
                Assert.AreEqual(true, excluido);
            }
        }

        [TestMethod]
        public void ClasseDeNegocio_ConsultarConteudoArquivo_NaoDeveExcluirComAte2MesesDaDataAtual()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                ShimDateTime.NowGet = () => DateTime.Parse("2011-04-01");
                bool excluido = false;
                ShimFile.ExistsString = (s) => true;
                ShimFile.GetCreationTimeString = (s) => DateTime.Parse("2011-03-01");
                ShimFile.DeleteString = (s) => excluido = true;
                var alvo = new ClasseDeNegocio();
                // Act
                alvo.ExcluriArquivoAntigo("xxx");
                // Assert
                Assert.AreEqual(false, excluido);
            }
        }
    }
}
