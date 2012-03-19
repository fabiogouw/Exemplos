using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExemploConstrutorPrivadoObjeto;
using Moq;

namespace ExemploConstrutorPrivadoTeste
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Ignore]
        public void TestMethod1()
        {
            //var obj = new MeuObjeto(); -- isso dá erro de compilação
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            var mock = new Mock<IMinhaDependencia>();
            mock.Setup(m => m.Calcular()).Returns(1);
            var po = new PrivateObject(typeof(MeuObjeto));
            var obj = (MeuObjeto)po.Target;
            obj.Dependencia = mock.Object;
            // Act
            var resultado = obj.RetornarCalculo(2);
            // Assert
            Assert.AreEqual(3, resultado);
        }
    }
}
