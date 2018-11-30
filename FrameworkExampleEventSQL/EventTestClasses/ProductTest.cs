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

            Product p2 =new Product(p.ID, dataSource);
            Assert.AreEqual(p.ID, p2.ID);
            Assert.AreEqual(p.ProductCode, p2.ProductCode);
            Assert.AreEqual(p.ProductCode, "ABCD");
            Assert.AreEqual(p.Price, 25.99m);
            Assert.AreEqual(p.OnHandQuantity, 10);

            Console.WriteLine(p.ToString());
            Assert.Greater(p.ToString().Length, 1);
        }


        [Test]
        public void TestUpdate()
        {
            Product p = new Product(17, dataSource);

            p.ProductCode = "ABCD";
            p.Description = "This is a test product";
            p.Price = 25.99m;
            p.OnHandQuantity = 10;
           
            p.Save();

            Assert.AreEqual(p.ProductCode, "ABCD");

            p.ProductCode = "EFGH";

            Assert.AreEqual(p.ID, 17);
            Assert.AreEqual(p.ProductCode, "EFGH");

        }
        [Test]
        public void TestDelete()
        {
            Product p = new Product(17, dataSource);

            p.ProductCode = "ABCD";
            p.Description = "This is a test product";
            p.Price = 25.99m;
            p.OnHandQuantity = 10;

            p.Save();

            Assert.AreEqual(p.ID, 17);

            p.Delete();

            // Assert.Throws<Exception>(() => new Product(17, dataSource));

        }

        [Test]
        public void TestStaticDelete()
        {
            /*
            Event.Delete(2, dataSource);
            Assert.Throws<Exception>(() => new Event(2, dataSource));
            */
        }
    }
}
