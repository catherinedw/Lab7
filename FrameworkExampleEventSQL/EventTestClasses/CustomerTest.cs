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

namespace CustomerTestClasses
{
    [TestFixture]
    public class CustomerTest
    {
        private string dataSource = "Data Source=LAPTOP-S3LF8NDH\\SQLEXPRESS;Initial Catalog=MMABooksUpdated;Integrated Security=True";

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestRetrieveExistingCustomer()
        {
            Customer c = new Customer(1, dataSource);
            Assert.AreEqual(c.CustomerID, 1);
            Console.WriteLine(c.ToString());
        }

        [Test]
        public void TestCreateNewCustomer()
        {
            Customer c = new Customer(dataSource);

            c.CustomerName = "Daisy Duck";
            c.Address = "12 Banana Ave";


            c.Save();

            Customer c2 = new Customer(c.CustomerID, dataSource);
            Assert.AreEqual(c.CustomerID, c2.CustomerID);
            Assert.AreEqual(c.Address, c2.Address);
            Assert.AreEqual(c.CustomerName, "Daisy Duck");

            Console.WriteLine(c.ToString());
            Assert.Greater(c.ToString().Length, 1);
        }


        [Test]
        public void TestUpdate()
        {
            Customer c = new Customer(17, dataSource);

            c.CustomerCode = "ABCD";
            c.Description = "This is a test Customer";
            c.Price = 25.99m;
            c.OnHandQuantity = 10;

            c.Save();

            Assert.AreEqual(c.CustomerCode, "ABCD");

            c.CustomerCode = "EFGH";

            Assert.AreEqual(c.ID, 17);
            Assert.AreEqual(c.CustomerCode, "EFGH");
            Console.WriteLine(c.ToString());
        }
        [Test]
        public void TestDelete()
        {
            Customer c = new Customer(16, dataSource);

            c.Delete();

            c.Save();

            Assert.Throws<Exception>(() => new Customer(16, dataSource));
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
