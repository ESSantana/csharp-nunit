using NUnit.Framework;
using System;
using Moq;
using Banco;

namespace BancoTest
{
    [TestFixture]
    public class BancoTest_UnitTest
    {
        private readonly IAprovarCredito aprove;
        private Conta GetConta(string cpf, int sald, string cont)
        {
            var sut = new Conta(cpf,sald,cont,aprove);
            return sut;
        }

        private string GetCpfConta(Conta conta)
        {
            return conta.cpf;
        }

        [TestCase("22147126",2144,"9874")]
        [TestCase("14872948174",4145,"0023")]
        [TestCase("47818924",8210,"4184")]
        [TestCase("4124184714987",5981,"0948")]
        [TestCase("1241841242",512787,"5878")]
        [TestCase("2462148147126",1000900,"0804")]
        public void ConsultarCredito_CreditoAprovado_RetornaTrue_Moq(string cpf, int sald, string cont){

            Mock<IAprovarCredito> aprove = new Mock<IAprovarCredito>();
            var sut = GetConta(cpf,sald,cont);
            aprove.Setup(credit => credit.VerificarRegularidadeCPF(It.IsAny<string>())).Returns(true);
            var result = sut.consultarCredito(GetCpfConta(sut));
            Assert.IsTrue(result);

        }

        [TestCase("22147126",2144,"9874")]
        [TestCase("1872948174",4145,"0023")]
        [TestCase("47818924",8210,"4184")]
        [TestCase("4124184714987",5981,"0948")]
        [TestCase("1241841242",512787,"5878")]
        [TestCase("2462148147126",1000900,"0804")]       
        public void VerificarTamanhoCPF_TamanhoIncorreto_RetornaExcecao(string cpf, int sald, string cont)
        {
            var sut = GetConta(cpf,sald,cont);

            var ex = Assert.Throws<SystemException>(() => sut.VerificarTamanhoCPF(GetCpfConta(sut)));
            Assert.AreEqual(ex.Message, "CPF is incorrect!");
            
        }

        [TestCase("22147126858",2144,"9874")]
        [TestCase("14872948174",4145,"0023")]
        [TestCase("47818924858",8210,"4184")]
        [TestCase("41241847187",5981,"0948")]
        [TestCase("12418412442",512787,"5878")]
        [TestCase("24621481126",1000900,"0804")] 
        public void VerificarTamanhoCPF_TamanhoCorreto_RetornaString(string cpf, int sald, string cont)
        {
            var sut = GetConta(cpf,sald,cont);

            Assert.AreEqual(sut.VerificarTamanhoCPF(GetCpfConta(sut)), cpf);
            
        }


    }
}