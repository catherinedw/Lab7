using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using EventClasses;
using EventPropsClasses;
using EventDBClasses;
using ToolsCSharp;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

using System.Data;
using System.Data.SqlClient;

using DBCommand = System.Data.SqlClient.SqlCommand;

namespace EventTestClasses
{
    [TestFixture]
    public class ProductTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestRetrieveExistingProduct()
        {
            /*
            Product p = new Product(1, dataSource);
            Assert.AreEqual(p.ID, 1);
            Assert.AreEqual(p.ProductCode, "A4CS");
            Assert.AreEqual(p.UnitPrice, 56.50m);
            Assert.AreEqual(p.Quantity, 4637);
            Console.WriteLine(p.ToString());
            */
        }

        [Test]
        public void TestCreateNewProduct()
        {
            /*
            Product p = new Product(dataSource);

            p.Code = "ABCD";
            p.Description = "This is a test product";
            p.UnitPrice = 25.99m;
            p.Quantity = 10;

            p.Save();

            ProductDBTests p2 = TestCreateNewProduct(p.ID, dataSource);
            Assert.AreEqual(p.ID, p2.ID);
            Assert.AreEqual(p.Code, p2.Code);
            Assert.AreEqual(p.ProductCode, "ABCD");
            Assert.AreEqual(p.UnitPrice, 25.99m);
            Assert.AreEqual(p.Quantity, 10);

            Console.WriteLine(p.ToString());
            */
        }
    }
}
