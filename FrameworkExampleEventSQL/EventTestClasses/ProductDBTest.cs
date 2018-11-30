using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EventPropsClasses;
using EventDBClasses;

using System.Data;
using DBCommand = System.Data.SqlClient.SqlCommand;

namespace EventTestClasses
{
    [TestFixture]
    public class ProductDBTests
    {
        ProductProps props, testp;
        ProductSQLDB db;
        List<ProductProps> list;
        private string dataSource = "Data Source=LAPTOP-S3LF8NDH\\SQLEXPRESS;Initial Catalog=MMABooksUpdated;Integrated Security=True";

        [SetUp]
        public void Setup()
        {
            db = new ProductSQLDB(dataSource);
            props = new ProductProps();

            DBCommand command = new DBCommand();
            command.CommandText = "usp_testingResetData";
            command.CommandType = CommandType.StoredProcedure;
            db.RunNonQueryProcedure(command);

            testp = new ProductProps();
            testp.ID = 1;
            testp.quantity = 10;
            testp.code = "XXXX";
            testp.price = 99.99m;
            testp.description = "This is a test product";
            testp.ConcurrencyID = 1;
        }

        [Test]
        public void TestNewEventConstructor()
        {
            /*
            // not in Data Store - no id
            Event e = new Event(dataSource);
            Console.WriteLine(e.ToString());
            Assert.Greater(e.ToString().Length, 1);
            */
        }

        [Test]
        public void TestRetrieve()
        {
            props = (ProductProps)db.Retrieve(1);
            Assert.AreEqual("A4CS", props.code);
            Assert.AreEqual(56.50, props.price);
            //assert all
        }

        [Test]
        public void TestRetrieveAll()
        {
            list = (List<ProductProps>)db.RetrieveAll(props.GetType());
            Assert.AreEqual(list.Count, 16);
        }

        [Test]
        public void TestCreate()
        {
            ProductProps p2 = (ProductProps)db.Create(testp);
            Assert.AreEqual(p2.ID, 17);
            Assert.AreEqual(p2.ConcurrencyID, 1);

            props = (ProductProps)db.Retrieve(17);
            Assert.AreEqual("XXXX", props.code);
            Assert.AreEqual(99.99, props.price);
        }

        [Test]
        public void TestDelete()
        {
            
        }

        [Test]
        public void TestUpdate()
        {
            /*ProductProps p2 = (ProductProps)db.Update(testp);
            p2.ID = 17;
            p2.quantity = 50;
  
            Assert.AreEqual(p2.ID, 17);
            Assert.AreEqual(p2.ConcurrencyID, 1);
            Assert.AreEqual(p2.quantity, 50);

            props = (ProductProps)db.Retrieve(17);
            Assert.AreEqual("XXXX", props.code);
            Assert.AreEqual(50, props.quantity);
            */
        }
    }
}
