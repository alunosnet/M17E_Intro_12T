using M17E_Intro_12T.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testes
{
    [TestClass]
    public class UnitTest1
    {
        /* testar a ligação à bd*/
        [TestMethod]
        public void TestMethod1()
        {
            Utilizadores utilizadores = new Utilizadores();
            Assert.IsNotNull(utilizadores);
        }
        /* testar login que deve funcionar*/
        [TestMethod]
        public void TestMethod2()
        {
            Utilizadores utilizadores = new Utilizadores();
            utilizadores.email = "admin@gmail.com";
            utilizadores.palavra_passe = "54321";
            Assert.IsTrue(utilizadores.VerificaLogin());
        }
        /* testar login que deve falhar*/
        [TestMethod]
        public void TestMethod3()
        {
            Utilizadores utilizadores = new Utilizadores();
            utilizadores.email = "admin@gmail.com";
            utilizadores.palavra_passe = "istonãoexiste";
            Assert.IsFalse(utilizadores.VerificaLogin());
        }
        /* testar login que deve ?*/
        [TestMethod]
        public void TestMethod4()
        {
            Utilizadores utilizadores = new Utilizadores();
            utilizadores.email = "ADMIN@gmail.com";
            utilizadores.palavra_passe = "54321";
            Assert.IsTrue(utilizadores.VerificaLogin());
        }
    }
}
