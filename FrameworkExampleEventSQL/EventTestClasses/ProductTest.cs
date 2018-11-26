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
        private string dataSource = "Data Source=LAPTOP-S3LF8NDH\\SQLEXPRESS;Initial Catalog=MMABooksUpdated;Integrated Security=True";

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestRetrieveExistingProduct()
        {
            Product p = new Product(1, dataSource);
            Assert.AreEqual(p.ID, 1);
            Assert.AreEqual(p.ProductCode, "A4CS");
            Assert.AreEqual(p.Price, 56.50m);
            Assert.AreEqual(p.OnHandQuantity, 4637);
            Console.WriteLine(p.ToString());
        }

        [Test]
        public void TestCreateNewProduct()
        {
            Product p = new Product(dataSource);

            p.ProductCode = "ABCD";
            p.Description = "This is a test product";
            p.Price = 25.99m;
            p.OnHandQuantity = 10;

            p.Save();
        
            ProductDBTests p2 = TestCreateNewProduct(p.ID, dataSource);
            /*
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
