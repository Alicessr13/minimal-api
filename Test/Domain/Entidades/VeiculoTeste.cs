using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Domain.Entidades;

namespace Test.Domain.Entidades
{
     [TestClass]
    public class VeiculoTeste
    {
        [TestMethod]
        public void TestarGetSetPropriedades()
        {
            //arrange
            var veiculo = new Veiculo();

            //act 
            veiculo.Id = 1;
            veiculo.Nome = "teste";
            veiculo.Marca = "teste";
            veiculo.Ano = 2003;

            //assert
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("teste", veiculo.Nome);
            Assert.AreEqual("teste", veiculo.Marca);
            Assert.AreEqual(2003, veiculo.Ano);
        }
    }
}