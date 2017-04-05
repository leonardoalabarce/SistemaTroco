using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaTroco.Utils;

namespace SistemaTrocoTeste
{
    [TestClass]
    public class TrocoTeste
    {
        [TestMethod]
        public void TestarcalculaTroco()
        {
            TrocoHelper.calculaTroco(1, 2);
        }
    }
}
