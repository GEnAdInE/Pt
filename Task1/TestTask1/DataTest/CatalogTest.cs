using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.DataLayer;

namespace TestTask1.DataTest
{
    [TestClass]
    public class CatalogTest
    {

        [TestMethod]
        public void CatalogBasicTest()
        {
            Catalog nCatalog = new Catalog("Book1", "Author1");
            Assert.AreEqual("Book1", nCatalog.Title);
            Assert.AreEqual("Author1",nCatalog.Author);
        }


    }
}
